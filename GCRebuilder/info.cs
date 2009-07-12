using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using sio = System.IO;
using ste = System.Text.Encoding;

namespace GCRebuilder
{

    public partial class MainForm : Form
    {
        sio.MemoryStream bnr = null;
        sio.BinaryReader bnrr = null;
        sio.BinaryWriter bnrw = null;
        Encoding bannerEnc;

        System.Drawing.Image img;

        private void LoadInfo(bool image)
        {
            LoadISOInfo(image);

            GetBanners(image);
        }

        private void LoadISOInfo(bool image)
        {
            sio.FileStream fs;
            sio.BinaryReader br;
            string loadPath;
            byte b;
            byte[] bb;

            loadPath = (image) ? imgPath : toc.fils[2].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);

            bb = br.ReadBytes(4);
            tbIDGameCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            switch (Convert.ToString(ste.Default.GetChars(new byte[] { bb[3] })[0]).ToLower())
            {
                case "e":
                    tbIDRegion.Text = "USA/NTSC";
                    region = 'u';
                    break;
                case "j":
                    tbIDRegion.Text = "JAP/NTSC";
                    region = 'j';
                    break;
                case "p":
                    tbIDRegion.Text = "EUR/PAL";
                    region = 'e';
                    break;
                default:
                    tbIDRegion.Text = "UNK";
                    region = 'n';
                    break;
            }
            bb = br.ReadBytes(2);
            tbIDMakerCode.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            b = br.ReadByte();
            tbIDDiscID.Text = string.Format("0x{0:x2}", b);
            fs.Position += 0x19;
            tbIDName.Text = br.ReadStringNT();

            br.Close();
            fs.Close();

            loadPath = (image) ? imgPath : toc.fils[3].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (image) fs.Position = toc.fils[3].pos;

            tbIDDate.Text = br.ReadStringNT();

            br.Close();
            fs.Close();

            tbIDName.Enabled = true;
            tbIDDiscID.Enabled = true;
            tbIDGameCode.Enabled = true;
            tbIDRegion.Enabled = true;
            tbIDMakerCode.Enabled = true;
            tbIDDate.Enabled = true;
        }

        private void GetBanners(bool image)
        {
            int bnrC = 0;
            string sPat1 = "opening";
            string sPat2 = ".bnr";
            string tag = "";

            cbBDFile.Items.Clear();

            for (int i = 0; i < toc.fils.Count; i++)
            {
                if (!toc.fils[i].isDir)
                    if (toc.fils[i].name.IndexOf(sPat1) == 0)
                        if (toc.fils[i].name.LastIndexOf(sPat2) == toc.fils[i].name.Length - 4)
                        {
                            cbBDFile.Items.Add(toc.fils[i].name);
                            tag += string.Format("x{0:d2}{1:d6}", bnrC, i);
                            bnrC += 1;
                        }
            }

            if (bnrC > 0)
            {
                cbBDFile.Tag = tag;
                cbBDFile.Enabled = true;
                cbBDFile.SelectedIndex = 0;
            }
        }

        private void LoadBannerInfo(int fIdx, bool image)
        {
            sio.FileStream fs;
            sio.BinaryReader br;
            sio.FileInfo fi;
            string loadPath;
            string tag;
            byte[] bb = new byte[4];
            bool error = false;

            tag = (string)cbBDFile.Tag;
            fIdx = tag.IndexOf(string.Format("x{0:d2}", fIdx));
            if (fIdx == -1)
            {
                MessageBox.Show("Banner index not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fIdx = Convert.ToInt32(tag.Substring(fIdx + 3, 6));
            if (!image)
            {
                fi = new sio.FileInfo(toc.fils[fIdx].path);
                if (!fi.Exists)
                {
                    MessageBox.Show(string.Format("Banner '{0}' not found", toc.fils[fIdx].path), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (bnr != null)
            {
                bnrr.Close();
                bnrw.Close();
                bnr.Close();
            }

            loadPath = (image) ? imgPath : toc.fils[fIdx].path;

            fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            if (image)
                if (fs.Length < toc.fils[fIdx].pos + toc.fils[fIdx].len)
                {
                    MessageBox.Show(string.Format("Banner '{0}' not found", toc.fils[fIdx].path), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if (image) fs.Position = toc.fils[fIdx].pos;
            bnr = new sio.MemoryStream(br.ReadBytes(toc.fils[fIdx].len));
            bnrr = new sio.BinaryReader(bnr, ste.Default);
            bnrw = new sio.BinaryWriter(bnr, ste.Default);
            br.Close();
            fs.Close();

            bnr.Read(bb, 0, 4);
            tbBDVersion.Text = SIOExtensions.ToStringC(ste.Default.GetChars(bb));
            if (tbBDVersion.Text.Length < 3) error = true;
            if (!error)
                if (tbBDVersion.Text.ToLower().Substring(0, 3) != "bnr") error = true;
            if (error)
            {
                bannerLoaded = false;
                cbBDLanguage.Enabled = false;
                tbBDVersion.Text = "";
                tbBDVersion.Enabled = false;
                tbBDShortName.Text = "";
                tbBDShortName.Enabled = false;
                tbBDShortMaker.Text = "";
                tbBDShortMaker.Enabled = false;
                tbBDLongName.Text = "";
                tbBDLongName.Enabled = false;
                tbBDLongMaker.Text = "";
                tbBDLongMaker.Enabled = false;
                tbBDDescription.Text = "";
                tbBDDescription.Enabled = false;

                btnBDImport.Enabled = false;
                btnBDExport.Enabled = false;
                btnBDSave.Enabled = false;

                img = null;
                pbBDBanner.Invalidate();

                MessageBox.Show("This is not banner file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            tbBDVersion.Enabled = true;

            if (region == 'j')
                bannerEnc = ste.GetEncoding(932);
            else
                bannerEnc = ste.GetEncoding(1252);

            if (cbBDLanguage.Items.IndexOf("Japan") == 0)
                cbBDLanguage.Items.RemoveAt(0);

            if (region == 'j')
                cbBDLanguage.Items.Insert(0, "Japan");

            if (bb[3] == 0x32)
            {
                if (cbBDLanguage.Items.IndexOf("Japan") == 0)
                    cbBDLanguage.Items.RemoveAt(0);
                bannerEnc = ste.GetEncoding(1252);
                cbBDLanguage.Enabled = true;
            }
            else
            {
                cbBDLanguage.Enabled = false;
                LoadBannerLang(0);
            }

            if (cbBDLanguage.SelectedIndex == 0)
                LoadBannerLang(0);
            else
                cbBDLanguage.SelectedIndex = 0;

            LoadBannerImage();
        }

        private void LoadBannerLang(int lIdx)
        {
            int pos;
            byte[] bb;

            if (bnr == null)
                return;

            bannerLoaded = false;

            pos = 0x1820 + (lIdx * 0x140);
            bnr.Position = pos;

            bb = bnrr.ReadBytes(0x20);
            tbBDShortName.Text = SIOExtensions.ToStringC(bannerEnc.GetChars(bb));
            bb = bnrr.ReadBytes(0x20);
            tbBDShortMaker.Text = SIOExtensions.ToStringC(bannerEnc.GetChars(bb));
            bb = bnrr.ReadBytes(0x40);
            tbBDLongName.Text = SIOExtensions.ToStringC(bannerEnc.GetChars(bb));
            bb = bnrr.ReadBytes(0x40);
            tbBDLongMaker.Text = SIOExtensions.ToStringC(bannerEnc.GetChars(bb));
            bb = bnrr.ReadBytes(0x80);
            tbBDDescription.Text = SIOExtensions.ToStringC(bannerEnc.GetChars(bb));

            tbBDShortName.Enabled = true;
            tbBDShortMaker.Enabled = true;
            tbBDLongName.Enabled = true;
            tbBDLongMaker.Enabled = true;
            tbBDDescription.Enabled = true;
            bannerLoaded = true;
        }

        private void LoadBannerImage()
        {
            int tileMaxW = 4;
            int tileMaxH = 4;
            int tileMaxS = tileMaxW * tileMaxH;
            int tileW = 0;
            int tileH = -1;
            int imgMaxTileW = 24;
            int imgMaxTileH = 8;
            int imgMaxTileS = imgMaxTileW * imgMaxTileH;
            int imgTileW = 0;
            int imgTileH = -1;
            int bmpShift = 0x36;
            int bmpH = imgMaxTileH * tileMaxW;
            byte[] bmp = new byte[bmpShift + 0x1800];
            int bmpLineLen = imgMaxTileW * tileMaxW * 2;
            byte[] bmpLine = new byte[bmpLineLen];
            int bmpSize = bmpLineLen * imgMaxTileH * tileMaxH + bmpShift;
            int bmpPos = 0;
            int pix;
            byte b1, b2, b3, b4;
            int i, j;

            Array.Copy(GCRebuilder.Properties.Resources.bmp15, bmp, GCRebuilder.Properties.Resources.bmp15.Length);
            bnr.Position = 0x20;

            for (i = 0; i < imgMaxTileS; i++)
            {
                if (i % imgMaxTileW == 0)
                {
                    imgTileW = 0;
                    imgTileH += 1;
                }
                bmpPos = ((imgTileW * tileMaxW) * 2 + (imgTileH * tileMaxH * bmpLineLen)) + bmpShift;
                //bmpPos = bmpSize - (bmpLineLen * tileMaxH) - (((imgTileW * tileMaxW) * 2 + (imgTileH * tileMaxH * bmpLineLen)) + bmpShift);
                for (j = 0; j < tileMaxS; j++)
                {
                    if (j % tileMaxW == 0)
                    {
                        tileW = 0;
                        tileH += 1;
                        if (tileH > 0)
                            bmpPos += bmpLineLen;
                    }
                    pix = bnrr.ReadInt16BE();
                    if ((pix & 0x8000) != 0x8000)
                    {
                        b1 = (byte)((pix >> 0x0c) & 0x0f);
                        b2 = (byte)((pix >> 0x08) & 0x0f);
                        b3 = (byte)((pix >> 0x04) & 0x0f);
                        b4 = (byte)(pix & 0x0f);
                        pix = (b2 << 0x0b) | (b3 << 0x06) | (b4 << 0x01);
                    }
                    else
                        pix &= 0x7fff;
                    bmp[bmpPos + (tileW * 2)] = (byte)(pix & 0xff);
                    bmp[bmpPos + (tileW * 2) + 1] = (byte)(pix >> 0x8);
                    tileW += 1;
                }
                tileH = -1;
                imgTileW += 1;
            }

            for (i = bmpH / 2; i < bmpH; i++)
            {
                Array.Copy(bmp, (i * bmpLineLen) + bmpShift, bmpLine, 0, bmpLineLen);
                Array.Copy(bmp, ((bmpH - i - 1) * bmpLineLen) + bmpShift, bmp, (i * bmpLineLen) + bmpShift, bmpLineLen);
                Array.Copy(bmpLine, 0, bmp, ((bmpH - i - 1) * bmpLineLen) + bmpShift, bmpLineLen);
            }

            img = System.Drawing.Image.FromStream(new sio.MemoryStream(bmp));

            btnBDImport.Enabled = true;
            btnBDExport.Enabled = true;
            btnBDSave.Enabled = true;

            pbBDBanner.Invalidate();
        }

        private void SaveBannerInfo(int fIdx, bool image)
        {
            sio.FileStream fs = null;
            sio.FileInfo fi;
            string loadPath;
            string tag;

            tag = (string)cbBDFile.Tag;
            fIdx = tag.IndexOf(string.Format("x{0:d2}", fIdx));
            if (fIdx == -1)
            {
                MessageBox.Show("Banner index not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fIdx = Convert.ToInt32(tag.Substring(fIdx + 3, 6));
            if (!image)
            {
                fi = new sio.FileInfo(toc.fils[fIdx].path);
                if (!fi.Exists)
                {
                    MessageBox.Show(string.Format("Banner '{0}' not found", toc.fils[fIdx].path), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            loadPath = (image) ? imgPath : toc.fils[fIdx].path;

            try
            {
                fs = new sio.FileStream(loadPath, sio.FileMode.Open, sio.FileAccess.Write, sio.FileShare.None);
                if (image) fs.Position = toc.fils[fIdx].pos;
                bnr.WriteTo(fs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (fs != null) fs.Close();
        }

        private void SaveBannerLang(int lIdx)
        {
            int pos;

            if (!bannerLoaded)
                return;
            if (bnr == null)
                return;

            pos = 0x1820 + (lIdx * 0x140);
            bnr.Position = pos;

            bnrw.WriteStringNT(bannerEnc, tbBDShortName.Text, 0x20);
            bnrw.WriteStringNT(bannerEnc, tbBDShortMaker.Text, 0x20);
            bnrw.WriteStringNT(bannerEnc, tbBDLongName.Text, 0x40);
            bnrw.WriteStringNT(bannerEnc, tbBDLongMaker.Text, 0x40);
            bnrw.WriteStringNT(bannerEnc, tbBDDescription.Text, 0x80);
        }

        private void SaveBannerImage(string path)
        {
            sio.FileStream fs;
            sio.BinaryReader br;
            int tileMaxW = 4;
            int tileMaxH = 4;
            int tileMaxS = tileMaxW * tileMaxH;
            int tileW = 0;
            int tileH = -1;
            int imgMaxTileW = 24;
            int imgMaxTileH = 8;
            int imgMaxTileS = imgMaxTileW * imgMaxTileH;
            int imgTileW = 0;
            int imgTileH = -1;
            int bmpShift = 0x36;
            int bmpH = imgMaxTileH * tileMaxW;
            byte[] bmp;// = new byte[bmpShift + 0x1800];
            int bmpLineLen = imgMaxTileW * tileMaxW * 2;
            byte[] bmpLine = new byte[bmpLineLen];
            int bmpSize = bmpLineLen * imgMaxTileH * tileMaxH + bmpShift;
            int bmpPos = 0;
            int pix;
            int i, j;

            fs = new sio.FileStream(path, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            br = new sio.BinaryReader(fs, ste.Default);
            bmp = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            i = (bmp[1] << 0x08) + bmp[0];
            if (i != 0x4d42)
            {
                MessageBox.Show("Not BMP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            i = (bmp[0x1d] << 0x08) + bmp[0x1c];
            j = (bmp[0x1f] << 0x08) + bmp[0x1e];
            if (!(i == 0x10 && j == 0x00))
            {
                MessageBox.Show("Wrong BMP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            i = (bmp[0x15] << 0x18) + (bmp[0x14] << 0x10) + (bmp[0x13] << 0x08) + bmp[0x12];
            j = (bmp[0x19] << 0x18) + (bmp[0x18] << 0x10) + (bmp[0x17] << 0x08) + bmp[0x16];
            if (i != 0x60 || j != 0x20)
            {
                MessageBox.Show("Wrong width or height. Must be 96x32", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (i = bmpH / 2; i < bmpH; i++)
            {
                Array.Copy(bmp, (i * bmpLineLen) + bmpShift, bmpLine, 0, bmpLineLen);
                Array.Copy(bmp, ((bmpH - i - 1) * bmpLineLen) + bmpShift, bmp, (i * bmpLineLen) + bmpShift, bmpLineLen);
                Array.Copy(bmpLine, 0, bmp, ((bmpH - i - 1) * bmpLineLen) + bmpShift, bmpLineLen);
            }

            bnr.Position = 0x20;

            for (i = 0; i < imgMaxTileS; i++)
            {
                if (i % imgMaxTileW == 0)
                {
                    imgTileW = 0;
                    imgTileH += 1;
                }
                bmpPos = ((imgTileW * tileMaxW) * 2 + (imgTileH * tileMaxH * bmpLineLen)) + bmpShift;
                //bmpPos = bmpSize - (bmpLineLen * tileMaxH) - (((imgTileW * tileMaxW) * 2 + (imgTileH * tileMaxH * bmpLineLen)) + bmpShift);
                for (j = 0; j < tileMaxS; j++)
                {
                    if (j % tileMaxW == 0)
                    {
                        tileW = 0;
                        tileH += 1;
                        if (tileH > 0)
                            bmpPos += bmpLineLen;
                    }
                    pix = bmp[bmpPos + (tileW * 2)];
                    if (ignoreBannerAlpha)
                        pix |= 0x8000;
                    pix += bmp[bmpPos + (tileW * 2) + 1] << 0x08;
                    bnrw.WriteInt16BE(pix);
                    tileW += 1;
                }
                tileH = -1;
                imgTileW += 1;
            }
            LoadBannerImage();
        }

    }

}
