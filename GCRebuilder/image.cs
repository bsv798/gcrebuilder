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
        private int expImpIdx;
        private string expImpPath;

        private delegate string ShowMTFolderDialogCB(string path);
        private delegate bool ShowMTMBoxCB(string text, string caption, MessageBoxButtons btns, MessageBoxIcon icon, MessageBoxDefaultButton defBtn, DialogResult desRes);

        private bool ReadImageTOC()
        {
            TOCItemFil tif;
            sio.FileStream fsr;
            sio.BinaryReader brr;
            sio.MemoryStream msr;
            sio.BinaryReader mbr;
            long prevPos, newPos;

            int namesTableEntryCount;
            int namesTableStart;
            int itemNamePtr;
            bool itemIsDir = false;
            int itemPos;
            int itemLen;
            string itemName;
            string itemGamePath = "";
            string itemPath;

            int itemNum;
            int shift;
            //int dirIdx = 0;
            //int endIdx = 999999;
            int[] dirEntry = new int[512];
            int dirEntryCount = 0;
            dirEntry[1] = 99999999;

            int mod = 1;
            bool error = false;
            string errorText = "";
            int i, j;

            toc = new TOCClass(resPath);
            itemNum = toc.fils.Count;
            shift = toc.fils.Count - 1;

            fsr = new sio.FileStream(imgPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            brr = new sio.BinaryReader(fsr, ste.Default);

            if (fsr.Length > 0x0438)
            {
                fsr.Position = 0x0400;
                toc.fils[2].pos = 0x0;
                toc.fils[2].len = 0x2440;
                toc.fils[3].pos = 0x2440;
                toc.fils[3].len = brr.ReadInt32BE();
                fsr.Position += 0x1c;
                toc.fils[4].pos = brr.ReadInt32BE();
                toc.fils[5].pos = brr.ReadInt32BE();
                toc.fils[5].len = brr.ReadInt32BE();
                toc.fils[4].len = toc.fils[5].pos - toc.fils[4].pos;
                fsr.Position += 0x08;
                toc.dataStart = brr.ReadInt32BE();

                toc.totalLen = (int)fsr.Length;
            }
            else
            {
                errorText = "Image is too short";
                error = true;
            }

            if (fsr.Length < toc.dataStart)
            {
                errorText = "Image is too short";
                error = true;
            }

            if (!error)
            {
                fsr.Position = toc.fils[5].pos;
                msr = new sio.MemoryStream(brr.ReadBytes(toc.fils[5].len));
                mbr = new sio.BinaryReader(msr, ste.Default);

                i = mbr.ReadInt32();
                if (i != 1)
                {
                    error = true;
                    errorText = "Multiple FST image?\r\nPlease mail me info about this image";
                }

                i = mbr.ReadInt32();
                if (i != 0)
                {
                    error = true;
                    errorText = "Multiple FST image?\r\nPlease mail me info about this image";
                }

                namesTableEntryCount = mbr.ReadInt32BE() - 1;
                namesTableStart = (namesTableEntryCount * 12) + 12;

                if (retrieveFilesInfo)
                {
                    sspbProgress.Minimum = 0;
                    sspbProgress.Maximum = 100;
                    sspbProgress.Step = 1;
                    sspbProgress.Value = 0;
                    mod = (int)Math.Floor((float)(namesTableEntryCount + itemNum) / sspbProgress.Maximum);
                    if (mod == 0)
                    {
                        sspbProgress.Maximum = namesTableEntryCount + itemNum;
                        mod = 1;
                    }
                }

                for (int cnt = 0; cnt < namesTableEntryCount; cnt++)
                {
                    itemNamePtr = mbr.ReadInt32BE();
                    if (itemNamePtr >> 0x18 == 1)
                        itemIsDir = true;
                    itemNamePtr &= 0x00ffffff;
                    itemPos = mbr.ReadInt32BE();
                    itemLen = mbr.ReadInt32BE();
                    prevPos = msr.Position;
                    newPos = namesTableStart + itemNamePtr;
                    msr.Position = newPos;
                    itemName = mbr.ReadStringNT();
                    msr.Position = prevPos;

                    while (dirEntry[dirEntryCount + 1] <= itemNum)
                        dirEntryCount -= 2;

                    if (itemIsDir)
                    {
                        dirEntryCount += 2;
                        dirEntry[dirEntryCount] = (itemPos > 0) ? itemPos + shift : itemPos;
                        itemPos += shift;
                        itemLen += shift;
                        dirEntry[dirEntryCount + 1] = itemLen;
                        toc.dirCount += 1;
                    }
                    else
                        toc.filCount += 1;

                    itemPath = itemName;
                    j = dirEntry[dirEntryCount];
                    for (i = 0; i < 256; i++)
                    {
                        if (j == 0)
                        {
                            itemGamePath = itemPath;
                            itemPath = resPath + itemPath;
                            break;
                        }
                        else
                        {
                            itemPath = itemPath.Insert(0, toc.fils[j].name + '\\');
                            j = toc.fils[j].dirIdx;
                        }
                    }
                    if (itemIsDir)
                        itemPath += '\\';

                    if (retrieveFilesInfo)
                    {
                        if (!itemIsDir)
                            if (fsr.Length < itemPos + itemLen)
                            {
                                errorText = string.Format("File '{0}' not found", itemPath);
                                error = true;
                            }

                        if (error)
                            break;

                        if (itemNum % mod == 0)
                        {
                            if (sspbProgress.Value < sspbProgress.Maximum)
                                sspbProgress.Value += 1;
                            //sslblAction.Text = string.Format("Check: '{0}'…", itemPath.Replace(resPath, ""));
                        }
                    }

                    tif = new TOCItemFil(itemNum, dirEntry[dirEntryCount], itemPos, itemLen, itemIsDir, itemName, itemGamePath, itemPath);
                    toc.fils.Add(tif);
                    toc.fils[0].len = toc.fils.Count;

                    if (itemIsDir)
                    {
                        dirEntry[dirEntryCount] = itemNum;
                        itemIsDir = false;
                    }

                    itemNum += 1;

                }
                mbr.Close();
                msr.Close();
            }

            brr.Close();
            fsr.Close();

            if (retrieveFilesInfo)
                sspbProgress.Value = 0;

            if (error)
            {
                MessageBox.Show(errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //sslblAction.Text = "Ready";
                return false;
            }

            CalcNextFileIds();

            ////sslblAction.Text = "Building Structure…";
            error = GenerateTreeView(fileNameSort);
            ////sslblAction.Text = "Ready";

            rootOpened = false;
            LoadInfo(!rootOpened);

            //toc.fils.Sort((IComparer<TOCItemFil>)toc);

            return error;
        }

        private void ExportDir()
        {
            //FolderBrowserDialog fbd;
            sio.DirectoryInfo di;
            int idx = expImpIdx;
            string expPath = expImpPath;
            string excPath;
            int[] dirLens = new int[256];
            string[] dirNames = new string[256];
            int dirIdx = 1;
            bool showMsg = false;
            bool error = false;
            string errorText = "";
            int i;

            if (expPath.Length == 0)
            {
                expPath = ShowMTFolderDialog(toc.fils[idx].name);
                if (expPath != "-1")
                    showMsg = true;
                else
                    expPath = "";
                //fbd = new FolderBrowserDialog() { Description = "Export folder" };
                //fbd.SelectedPath = toc.fils[idx].name;
                //if (fbd.ShowDialog() == DialogResult.OK)
                //{
                //    expPath = fbd.SelectedPath;
                //    showMsg = true;
                //}
            }

            if (expPath.Length == 0)
            {
                error = true;
                errorText = "";
            }

            if (!error)
            {
                ResetProgressBar(0, toc.fils[idx].len - idx, 0);

                expPath = (expPath[expPath.Length - 1] == '\\') ? expPath : expPath + '\\';

                if (idx == 0)
                {
                    expPath += "root";
                    excPath = "root:";
                }
                else
                {
                    i = toc.fils[idx].gamePath.LastIndexOf('\\', toc.fils[idx].gamePath.Length - 2);
                    if (i < 0)
                        excPath = "root:";
                    else
                        excPath = "root:\\" + toc.fils[idx].gamePath.Substring(0, i);
                }

                dirLens[dirIdx] = -1;

                for (i = idx; i < toc.fils[idx].len; i++)
                {
                    while (i == dirLens[dirIdx])
                        dirIdx -= 1;

                    if (toc.fils[i].isDir)
                    {
                        di = new sio.DirectoryInfo(expPath + (("root:\\" + toc.fils[i].gamePath).Replace(excPath, "")));
                        if (!di.Exists)
                            di.Create();
                        dirIdx += 1;
                        dirLens[dirIdx] = toc.fils[i].len;
                        dirNames[dirIdx] = (di.FullName[di.FullName.Length - 1] == '\\') ? di.FullName : di.FullName + '\\';
                    }
                    else
                        Export(i, dirNames[dirIdx] + toc.fils[i].name);

                    UpdateProgressBar(1);
                    UpdateActionLabel(string.Format("Export: '{0}'", toc.fils[i].gamePath));

                    if (stopCurrProc)
                        break;
                }
            }

            if (!showMsg)
                errorText = null;

            ResetControlsWipeing(error, errorText);

            isImpExping = false;
            stopCurrProc = false;
        }

        private void Export(int idx, string expPath)
        {
            SaveFileDialog sfd;
            sio.FileStream fsr;
            sio.BinaryReader brr;
            sio.FileStream fsw;
            sio.BinaryWriter bww;
            long endPos;
            int maxBR, curBR, temBR;
            bool showMsg = false;
            byte[] b;

            escapePressed = false;

            if (expPath.Length == 0)
            {
                sfd = new SaveFileDialog() { Filter = "All files (*.*)|*.*", Title = "Export file" };
                sfd.FileName = toc.fils[idx].name;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    expPath = sfd.FileName;
                    showMsg = true;
                }
            }

            if (expPath.Length == 0)
                return;

            fsr = new sio.FileStream(imgPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            brr = new sio.BinaryReader(fsr, ste.Default);
            fsw = new sio.FileStream(expPath, sio.FileMode.Create, sio.FileAccess.Write, sio.FileShare.None);
            bww = new sio.BinaryWriter(fsw, ste.Default);

            fsr.Position = toc.fils[idx].pos;
            endPos = toc.fils[idx].pos + toc.fils[idx].len;

            maxBR = 0x8000;
            temBR = toc.fils[idx].len;

            while (fsr.Position < endPos)
            {
                temBR -= maxBR;
                if (temBR < 0)
                    curBR = maxBR + temBR;
                else
                    curBR = maxBR;
                b = brr.ReadBytes(curBR);
                bww.Write(b);

                if (escapePressed)
                    if (ShowMTMBox("Cancel current process?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, DialogResult.Yes))
                        stopCurrProc = true;

                if (stopCurrProc)
                    break;
            }

            bww.Close();
            fsw.Close();
            brr.Close();
            fsr.Close();

            if (showMsg)
                MessageBox.Show("Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ImportDir(int idx, string impPath)
        {
        }

        private void Import(int idx, string impPath)
        {
            OpenFileDialog ofd;
            sio.FileInfo fi;
            sio.FileStream fsr;
            sio.BinaryReader brr;
            sio.FileStream fsw;
            sio.BinaryWriter bww;
            int oidx, nidx;
            int maxLen;
            long endPos;
            int maxBR, curBR, temBR;
            bool showMsg = false;
            byte[] b;

            escapePressed = false;

            if (impPath.Length == 0)
            {
                ofd = new OpenFileDialog() { Filter = "All files (*.*)|*.*", Title = "Import file" };
                ofd.FileName = toc.fils[idx].name;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    impPath = ofd.FileName;
                    showMsg = true;
                }
            }

            if (impPath.Length == 0)
                return;

            fi = new sio.FileInfo(impPath);
            oidx = toc.fils[idx].prevIdx;
            for (nidx = oidx + 1; nidx < toc.fils.Count - 1; nidx++)
                if (!toc.fils[nidx].isDir) break;
            maxLen = toc.fils[toc.fils[nidx].nextIdx].pos;
            maxLen = (nidx == toc.lastIdx) ? toc.totalLen - toc.fils[idx].pos : maxLen - toc.fils[idx].pos;
            endPos = toc.fils[idx].pos + maxLen;
            if (fi.Length > maxLen)
            {
                MessageBox.Show("File to import is too large", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fsr = new sio.FileStream(impPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
            brr = new sio.BinaryReader(fsr, ste.Default);
            fsw = new sio.FileStream(imgPath, sio.FileMode.Open, sio.FileAccess.Write, sio.FileShare.None);
            bww = new sio.BinaryWriter(fsw, ste.Default);

            fsw.Position = toc.fils[idx].pos;

            maxBR = 0x8000;
            temBR = (int)fi.Length;

            while (true)
            {
                temBR -= maxBR;
                if (temBR < 0)
                    curBR = maxBR + temBR;
                else
                    curBR = maxBR;
                if (curBR < 0)
                    break;
                b = brr.ReadBytes(curBR);
                bww.Write(b);

                if (escapePressed)
                    if (ShowMTMBox("Cancel current process?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, DialogResult.Yes))
                        stopCurrProc = true;

                if (stopCurrProc)
                    break;
            }

            if (!stopCurrProc)
            {
                while (fsw.Position < endPos)
                    bww.Write((byte)0);

                toc.fils[idx].len = (int)fi.Length;

                if (updateImageTOC)
                {
                    idx -= 5;
                    fsw.Position = toc.fils[5].pos + (idx << 3) + (idx << 2) + 8;
                    bww.WriteInt32BE((int)fsr.Length);
                }
            }

            bww.Close();
            fsw.Close();
            brr.Close();
            fsr.Close();

            if (showMsg)
                MessageBox.Show("Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WipeGarbage()
        {
            sio.FileStream fsw = null;
            sio.BinaryWriter bww = null;
            int[] posLen = new int[0x8000];
            int posLenCount = 0;
            int len;
            int idx;
            int totalBytes = 0;
            int currentBytes = 0;
            int mod, modAct;
            int maxBR = 0x8000, temBR;
            int rem = 0;
            byte[] bb = new byte[maxBR];
            int j;
            bool error = false;
            string errorText = "";

            escapePressed = false;

            idx = 5; // was 2!!
            for (int i = 5; i < toc.fils.Count; i++) // was 1!!
            {
                if (!toc.fils[i].isDir)
                {
                    posLen[posLenCount] = toc.fils[idx].pos + toc.fils[idx].len;
                    posLenCount += 1;
                    idx = toc.fils[i].nextIdx;
                    posLen[posLenCount] = toc.fils[idx].pos - posLen[posLenCount - 1];
                    totalBytes += posLen[posLenCount];
                    posLenCount += 1;
                }
            }
            posLenCount -= 2;
            posLen[posLenCount] = toc.fils[idx].pos + toc.fils[idx].len;
            posLenCount += 1;
            totalBytes -= posLen[posLenCount];
            posLen[posLenCount] = toc.totalLen - posLen[posLenCount - 1];
            totalBytes += posLen[posLenCount];
            posLenCount += 1;

            ResetProgressBar(0, 100, 0);
            mod = (int)Math.Floor((float)totalBytes / sspbProgress.Maximum);
            mod = (mod | (maxBR - 1)) + 1;
            j = (int)Math.Ceiling((float)totalBytes / mod);
            if (j < 100)
                ResetProgressBar(0, j, 0);
            modAct = (int)Math.Floor((float)totalBytes / 1000);
            modAct = (modAct | (maxBR - 1)) + 1;

            try
            {
                fsw = new sio.FileStream(imgPath, sio.FileMode.Open, sio.FileAccess.Write, sio.FileShare.None);
                bww = new sio.BinaryWriter(fsw, ste.Default);
            }
            catch (Exception ex)
            {
                error = true;
                errorText = ex.Message;
            }

            UpdateActionLabel(string.Format("Wiping garbage: {0}/{1} bytes wiped", currentBytes, totalBytes));

            if (!error)
                for (int i = 0; i < posLenCount; i += 2)
                {
                    len = posLen[i + 1];
                    if (len > 0)
                    {
                        fsw.Position = posLen[i];
                        for (j = 0; j < len; j += maxBR)
                        {
                            if (j + maxBR < len)
                            {
                                temBR = maxBR - (currentBytes % maxBR);
                                if (rem == 0)
                                    rem = currentBytes % maxBR;
                            }
                            else
                                temBR = len % maxBR;

                            currentBytes += temBR;
                            fsw.Write(bb, 0, temBR);

                            if (currentBytes % modAct == 0)
                                UpdateActionLabel(string.Format("Wiping garbage: {0}/{1} bytes wiped", currentBytes, totalBytes));

                            if (currentBytes % mod == 0)
                                UpdateProgressBar(1);

                            if (escapePressed)
                                if (ShowMTMBox("Cancel current process?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, DialogResult.Yes))
                                    stopCurrProc = true;

                            if (stopCurrProc)
                                break;
                        }
                        if (rem > 0)
                            fsw.Write(bb, 0, rem);
                        rem = 0;
                    }
                }

            if (bww != null) bww.Close();
            if (fsw != null) fsw.Close();

            ResetControlsWipeing(error, errorText);

            isWipeing = false;
            stopCurrProc = false;
        }

        //private void SaveTOC()
        //{
        //    sio.FileStream fs;
        //    sio.StreamWriter sw;

        //    fs = new sio.FileStream(@"c:\temp.txt", sio.FileMode.Create, sio.FileAccess.Write);
        //    sw = new sio.StreamWriter(fs, ste.Default);

        //    for (int i = 0; i < toc.fils.Count; i++)
        //        if (!toc.fils[i].isDir)
        //            sw.WriteLine("{0:d10} ; {1:d10} ; '{2}'", toc.fils[i].pos, toc.fils[i].nextIdx, toc.fils[i].path);

        //    sw.Close();
        //    fs.Close();
        //}

        private void ResetControlsWipeing(bool error, string errorText)
        {
            if (this.statusStrip.InvokeRequired)
            {
                ResetControlsCB d = new ResetControlsCB(ResetControlsWipeing);
                this.Invoke(d, new object[] { error, errorText });
            }
            else
            {
                if (errorText != null)
                    if (error)
                        MessageBox.Show(this, errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if (stopCurrProc)
                            MessageBox.Show(this, "Process cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                            MessageBox.Show("Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                miImage.Enabled = true;
                miImageOpen.Enabled = true;
                miImageClose.Enabled = true;
                miImport.Visible = true;
                miExport.Visible = true;
                miCancel.Visible = false;
                miImageWipeGarbage.Text = "Wipe garbage";
                miImageWipeGarbage.Image = GCRebuilder.Properties.Resources.wipe;
                if (bannerLoaded)
                {
                    cbBDFile.Enabled = true;
                    btnBDSave.Enabled = true;
                }
                sslblAction.Text = "Ready";
                if (bannerLoaded)
                {
                    cbBDFile.Enabled = true;
                    btnBDSave.Enabled = true;
                }
                this.sspbProgress.Value = 0;
            }
        }

        private string ShowMTFolderDialog(string path)
        {
            FolderBrowserDialog fbd;
            string res = "-1";

            if (this.statusStrip.InvokeRequired)
            {
                ShowMTFolderDialogCB d = new ShowMTFolderDialogCB(ShowMTFolderDialog);
                res = (string)this.Invoke(d, new object[] { path });
                return res;
            }
            else
            {
                fbd = new FolderBrowserDialog() { Description = "Export folder" };
                fbd.SelectedPath = path;
                if (fbd.ShowDialog() == DialogResult.OK)
                    res = fbd.SelectedPath;
            }

            return res;
        }

        private bool ShowMTMBox(string text, string caption, MessageBoxButtons btns, MessageBoxIcon icon, MessageBoxDefaultButton defBtn, DialogResult desRes)
        {
            bool res = false;

            if (this.statusStrip.InvokeRequired)
            {
                ShowMTMBoxCB d = new ShowMTMBoxCB(ShowMTMBox);
                res = (bool)this.Invoke(d, new object[] { text, caption, btns, icon, defBtn, desRes });
                return res;
            }
            else
                if (MessageBox.Show(this, text, caption, btns, icon, defBtn) == desRes)
                    res = true;

            escapePressed = false;

            return res;
        }
    }
}
