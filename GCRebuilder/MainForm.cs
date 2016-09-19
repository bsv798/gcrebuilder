//started 27.05.2009

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
        public string resPath = "";
        public string imgPath = "";

        private bool resChecked = false;
        private bool imgChecked = false;
        private bool rootOpened = true;

        //debug options----------------------------------------------------------------------
        private bool retrieveFilesInfo = true;
        private bool appendImage = true;
        private bool addressRebuild = true;
        private bool ignoreBannerAlpha = true;
        private bool updateImageTOC = true;
        private bool canEditTOC = false;
        private int filesMod = 2048;
        private int maxImageSize = 1459978240;
        //debug options----------------------------------------------------------------------

        private bool isRebuilding = false;
        private bool isWipeing = false;
        private bool isImpExping = false;
        private bool stopCurrProc = false;
        private bool escapePressed = false;
        private bool loading = true;
        private bool bannerLoaded = false;
        private bool fileNameSort = true;
        private char region = 'n';

        TreeNode selNode;

        System.Threading.ThreadStart ths;
        System.Threading.Thread th;

        private string[] args;
        private bool showLastDialog;

        public MainForm(string[] args)
        {
            this.args = args;

            InitializeComponent();

            this.tbBDShortName.TextChanged += new EventHandler(bnrInfoChanged);
            this.tbBDShortMaker.TextChanged += new EventHandler(bnrInfoChanged);
            this.tbBDLongName.TextChanged += new EventHandler(bnrInfoChanged);
            this.tbBDLongMaker.TextChanged += new EventHandler(bnrInfoChanged);
            this.tbBDDescription.TextChanged += new EventHandler(bnrInfoChanged);

            this.Icon = GCRebuilder.Properties.Resources.ico;

            this.imageList.Images.Add(GCRebuilder.Properties.Resources.root);
            this.imageList.Images.Add(GCRebuilder.Properties.Resources.dir_cl);
            this.imageList.Images.Add(GCRebuilder.Properties.Resources.dir_op);
            this.imageList.Images.Add(GCRebuilder.Properties.Resources.fil);

            this.cbBDLanguage.SelectedIndex = 0;

            loading = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (args.Length > 0)
                LoadArgs(args[0]);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (isRebuilding || isWipeing || isImpExping)
            {
                if (MessageBox.Show("Are yoy sure you want to close the program?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    th.Abort();
                else
                    e.Cancel = true;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                escapePressed = true;
        }

        private bool CheckResPath()
        {
            sio.DirectoryInfo di;
            sio.FileInfo[] fis;
            string sysDir = "&&systemdata";
            string[] sysFiles = new string[] { "apploader.ldr", "game.toc", "iso.hdr", "start.dol" };
            int i, j;

            try
            {
                di = new sio.DirectoryInfo(resPath + sysDir);
                if (!di.Exists)
                {
                    MessageBox.Show(string.Format("Folder '{0}' not found", sysDir), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                fis = di.GetFiles();
                for (i = 0; i < sysFiles.Length; i++)
                {
                    for (j = 0; j < fis.Length; j++)
                        if (sysFiles[i] == fis[j].Name.ToLower())
                            break;
                    if (j == fis.Length)
                    {
                        MessageBox.Show(string.Format("File '{0}' not found in '{1}' folder", sysFiles[i], sysDir), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (miOptionsDoNotUseGameToc.Checked)
                {
                    if (fis.Length > 4)
                    {
                        MessageBox.Show(string.Format("Misc files are not allowed in '{0}' folder", sysDir), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (di.GetDirectories().Length > 0)
                    {
                        MessageBox.Show(string.Format("Subfolders are not allowed in '{0}' folder", sysDir), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool CheckImage()
        {
            sio.FileStream fs = null;
            sio.BinaryReader br = null;
            bool error = false;

            try
            {
                fs = new sio.FileStream(imgPath, sio.FileMode.Open, sio.FileAccess.Read, sio.FileShare.Read);
                br = new sio.BinaryReader(fs, ste.Default);

                fs.Position = 0x1c;
                if (br.ReadInt32() != 0x3d9f33c2)
                {
                    MessageBox.Show("Not a GameCube image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;

            }

            finally
            {
                if (br != null) br.Close();
                if (fs != null) fs.Close();
            }

            return !error;
        }

        public bool IsImagePath(string arg)
        {
            sio.FileInfo fi;

            fi = new sio.FileInfo(arg);

            if (fi.Exists)
                return true;
            return false;
        }

        public bool IsRootPath(string arg)
        {
            sio.DirectoryInfo di;

            di = new sio.DirectoryInfo(arg);

            if (di.Exists)
                return true;
            return false;
        }

        private void LoadArgs(string arg)
        {
            try
            {
                if (IsImagePath(arg))
                    ImageOpen(arg);
                else if (IsRootPath(arg))
                    RootOpen(arg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetControls()
        {
            bannerLoaded = false;
            region = 'n';

            gbStruct.Text = "Structure";

            tvTOC.Enabled = false;
            tvTOC.Nodes.Clear();
            rbSortFileName.Enabled = false;
            rbSortAddress.Enabled = false;
            tbStartIdx.Enabled = false;
            tbEndIdx.Enabled = false;
            tbStartIdx.Text = "";
            tbEndIdx.Text = "";

            miExpFT.Visible = false;
            miExport.Visible = false;
            miImpFT.Visible = false;
            miImport.Visible = false;
            miRename.Visible = false;
            misep1.Visible = false;
            misep2.Visible = false;

            tbIDName.Text = "";
            tbIDName.Enabled = false;
            tbIDDiscID.Text = "";
            tbIDDiscID.Enabled = false;
            tbIDGameCode.Text = "";
            tbIDGameCode.Enabled = false;
            tbIDRegion.Text = "";
            tbIDRegion.Enabled = false;
            tbIDMakerCode.Text = "";
            tbIDMakerCode.Enabled = false;
            tbIDDate.Text = "";
            tbIDDate.Enabled = false;

            cbBDFile.Items.Clear();
            cbBDFile.Enabled = false;
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
        }

        public void RootOpen(string path)
        {
            FolderBrowserDialog fbd;
            string PrevPath = resPath;
            bool success = false;


            if (path.Length == 0)
            {
                fbd = new FolderBrowserDialog() { Description = "Choose root folder", ShowNewFolderButton = false };
                if (resPath != "")
                    fbd.SelectedPath = resPath;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    resPath = fbd.SelectedPath;
                    path = resPath;
                }
            }

            if (path.Length == 0)
                return;

            resPath = path;

            if (resPath.LastIndexOf('\\') != resPath.Length - 1)
                resPath += '\\';

            success = CheckResPath();
            if (success)
                if (miOptionsDoNotUseGameToc.Checked)
                    success = GenerateTOC();
                else
                    if (success)
                    success = ReadTOC();

            if (success)
            {
                rootOpened = true;
                if (!fileNameSort && canEditTOC)
                    gbStruct.Text = "Structure (editable)";
                miImage.Enabled = false;
                miOptions.Enabled = true;
                miOptionsDoNotUseGameToc.Enabled = false;
                miRootClose.Enabled = true;
                miRootOpen.ToolTipText = resPath;
                //miRename.Visible = true;
                resChecked = true;
                if (resChecked && imgChecked)
                    miRootStart.Enabled = true;
            }
            else
                resPath = PrevPath;
        }

        public void ImageOpen(string path)
        {
            OpenFileDialog ofd;

            if (path.Length == 0)
            {
                ofd = new OpenFileDialog() { Filter = "GameCube ISO (*.iso)|*.iso|GameCube Image File (*.gcm)|*.gcm|All files (*.*)|*.*", Title = "Open image" };
                if (imgPath != "")
                    ofd.FileName = imgPath;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgPath = ofd.FileName;
                    path = imgPath;
                }
            }

            if (path.Length == 0)
                return;

            imgPath = path;

            if (CheckImage())
                if (ReadImageTOC())
                {
                    miImageOpen.ToolTipText = imgPath;
                    miImageClose.Enabled = true;
                    miImageWipeGarbage.Enabled = true;
                    miRoot.Enabled = false;
                    miOptions.Enabled = false;
                    miImport.Visible = true;
                    miExport.Visible = true;
                    rootOpened = false;
                    gbStruct.Text = "Structure";
                }
        }

        private void cmsTVTOC_Opening(object sender, CancelEventArgs e)
        {
            if (tvTOC.SelectedNode == null)
                e.Cancel = true;
            else
                if (!rootOpened)
                if (toc.fils[Convert.ToInt32(selNode.Name)].isDir)
                    miImport.Enabled = false;
                else
                    miImport.Enabled = true;
        }

        private void tvTOC_MouseDown(object sender, MouseEventArgs e)
        {
            selNode = tvTOC.GetNodeAt(e.X, e.Y);

            if (selNode != null)
                tvTOC.SelectedNode = selNode;
            else
                tvTOC.SelectedNode = null;
        }

        private void tvTOC_KeyDown(object sender, KeyEventArgs e)
        {

            if (selNode == null)
                return;

            //if (!fileNameSort && canEditTOC)
            //    if (selNode.Level == 1)
            //        if (e.Shift)
            //        {
            //            string text, name;
            //            int tag;
            //            int idx;
            //            int nodeIdx = selNode.Index;
            //            int nodeCount = tvTOC.Nodes[0].Nodes.Count;

            //            if (e.KeyCode == Keys.Up)
            //            {
            //                if (nodeIdx - 1 > 3 && !(isRebuilding || !rootOpened))
            //                {
            //                    idx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx - 2].Name);
            //                    toc.fils[idx].nextIdx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx].Name);
            //                    if (nodeIdx + 1 < nodeCount)
            //                    {
            //                        idx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx - 1].Name);
            //                        toc.fils[idx].nextIdx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx + 1].Name);
            //                    }
            //                    idx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx].Name);
            //                    toc.fils[idx].nextIdx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx - 1].Name);

            //                    text = tvTOC.Nodes[0].Nodes[nodeIdx].Text;
            //                    name = tvTOC.Nodes[0].Nodes[nodeIdx].Name;
            //                    tag = (int)tvTOC.Nodes[0].Nodes[nodeIdx].Tag;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx].Text = tvTOC.Nodes[0].Nodes[nodeIdx - 1].Text;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx].Name = tvTOC.Nodes[0].Nodes[nodeIdx - 1].Name;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx].Tag = tvTOC.Nodes[0].Nodes[nodeIdx - 1].Tag;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx - 1].Text = text;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx - 1].Name = name;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx - 1].Tag = (object)tag;
            //                }
            //                else
            //                    e.SuppressKeyPress = true;
            //            }
            //            if (e.KeyCode == Keys.Down)
            //            {
            //                if ((nodeIdx + 1 < nodeCount && nodeIdx > 3) && !(isRebuilding || !rootOpened))
            //                {
            //                    idx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx - 1].Name);
            //                    toc.fils[idx].nextIdx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx + 1].Name);
            //                    idx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx + 1].Name);
            //                    toc.fils[idx].nextIdx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx].Name);
            //                    if (nodeIdx + 2 < tvTOC.Nodes[0].Nodes.Count)
            //                    {
            //                        idx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx].Name);
            //                        toc.fils[idx].nextIdx = Convert.ToInt32(tvTOC.Nodes[0].Nodes[nodeIdx + 2].Name);
            //                    }

            //                    text = tvTOC.Nodes[0].Nodes[nodeIdx].Text;
            //                    name = tvTOC.Nodes[0].Nodes[nodeIdx].Name;
            //                    tag = (int)tvTOC.Nodes[0].Nodes[nodeIdx].Tag;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx].Text = tvTOC.Nodes[0].Nodes[nodeIdx + 1].Text;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx].Name = tvTOC.Nodes[0].Nodes[nodeIdx + 1].Name;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx].Tag = tvTOC.Nodes[0].Nodes[nodeIdx + 1].Tag;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx + 1].Text = text;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx + 1].Name = name;
            //                    tvTOC.Nodes[0].Nodes[nodeIdx + 1].Tag = (object)tag;
            //                }
            //                else
            //                    e.SuppressKeyPress = true;
            //            }
            //        }

            //if (selNode.IsEditing)
            //{
            //    if (e.KeyCode == Keys.Enter)
            //        selNode.EndEdit(false);
            //    if (e.KeyCode == Keys.Escape)
            //        selNode.EndEdit(true);
            //}

            //if (!(selNode.IsEditing || isRebuilding))
            //    if (e.KeyCode == Keys.F2)
            //        selNode.BeginEdit();
        }

        private void tvTOC_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int idx;

            selNode = tvTOC.SelectedNode;
            if (selNode == null)
                return;

            idx = Convert.ToInt32(selNode.Name);
            if (toc.fils[idx].isDir)
            {
                lblStartIdx.Text = "Start index:";
                lblEndIdx.Text = "End index:";
            }
            else
            {
                lblStartIdx.Text = "File start:";
                lblEndIdx.Text = "File length:";
            }

            tbStartIdx.Text = toc.fils[idx].pos.ToString();
            tbEndIdx.Text = toc.fils[idx].len.ToString();
        }

        private void tvTOC_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //int idx;
            //int i;

            //if (e.Label != null)
            //{
            //    idx = (int)e.Node.Tag;
            //    i = toc.fils[idx].gamePath.LastIndexOf(toc.fils[idx].name);
            //    toc.fils[idx].gamePath = toc.fils[idx].gamePath.Remove(i, toc.fils[idx].name.Length);
            //    toc.fils[idx].name = e.Label;
            //    toc.fils[idx].gamePath = toc.fils[idx].gamePath.Insert(i, toc.fils[idx].name);
            //}
        }

        private void miImport_Click(object sender, EventArgs e)
        {
            int idx;

            if (selNode == null)
                return;

            idx = Convert.ToInt32(selNode.Name);
            if (toc.fils[idx].isDir)
                ImportDir(idx, "");
            else
                Import(idx, "");
        }

        private void miExport_Click(object sender, EventArgs e)
        {
            int idx;

            if (selNode == null)
                return;

            idx = Convert.ToInt32(selNode.Name);
            if (toc.fils[idx].isDir)
            {
                //ExportDir(idx, "");
                miImage.Enabled = false;
                miImport.Visible = false;
                miExport.Visible = false;
                miCancel.Visible = true;
                cbBDFile.Enabled = false;
                btnBDSave.Enabled = false;
                stopCurrProc = false;
                isImpExping = true;

                expImpIdx = idx;
                expImpPath = "";
                ths = new System.Threading.ThreadStart(ExportDir);
                th = new System.Threading.Thread(ths);
                th.Start();
            }
            else
                Export(idx, "");
        }

        public void SetSelectedNode(string name)
        {
            string fullName = name.Replace(sio.Path.AltDirectorySeparatorChar, sio.Path.DirectorySeparatorChar);
            string[] parts = fullName.Split(sio.Path.DirectorySeparatorChar);
            TreeNode node = GetNodeByText(null, parts[0]);

            for (int i = 1; i < parts.Length; i++)
            {
                if (node == null)
                    break;

                node = GetNodeByText(node, parts[i]);
            }
            selNode = node;
        }

        private TreeNode GetNodeByText(TreeNode node, string text)
        {
            TreeNodeCollection collection = (node == null) ? tvTOC.Nodes : node.Nodes;

            foreach (TreeNode item in collection)
            {
                if (item.Text.Equals(text))
                    return item;
            }
            return null;
        }

        private void miImpFT_Click(object sender, EventArgs e)
        {

        }

        private void miExpFT_Click(object sender, EventArgs e)
        {

        }

        private void miRename_Click(object sender, EventArgs e)
        {
            //tvTOC.SelectedNode.BeginEdit();
        }

        #region Main menu

        private void miRootOpen_Click(object sender, EventArgs e)
        {
            RootOpen("");
        }

        private void miRootSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "GameCube ISO (*.iso)|*.iso|GameCube Image File (*.gcm)|*.gcm", Title = "Save image" };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                imgPath = sfd.FileName;
                miRootSave.ToolTipText = imgPath;
                showLastDialog = true;
                imgChecked = true;
                if (resChecked && imgChecked)
                    miRootStart.Enabled = true;
            }
        }

        private void miRootClose_Click(object sender, EventArgs e)
        {
            miImage.Enabled = true;
            miOptionsDoNotUseGameToc.Enabled = true;
            ResetControls();
            miRootClose.Enabled = false;
            miRootStart.Enabled = false;
            resChecked = false;
        }

        private void miRootStart_Click(object sender, EventArgs e)
        {
            if (isRebuilding)
            {
                stopCurrProc = true;
                return;
            }

            gbStruct.Text = "Structure";
            //tvTOC.LabelEdit = false;
            miRename.Enabled = false;
            miRootOpen.Enabled = false;
            miRootSave.Enabled = false;
            miRootClose.Enabled = false;
            miRootStart.Text = "Cancel";
            miRootStart.Image = GCRebuilder.Properties.Resources.root_stop;
            miOptions.Enabled = false;
            cbBDFile.Enabled = false;
            btnBDSave.Enabled = false;
            stopCurrProc = false;
            isRebuilding = true;

            ths = new System.Threading.ThreadStart(Rebuild);
            th = new System.Threading.Thread(ths);
            th.Start();
        }

        private void miRootExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miImageOpen_Click(object sender, EventArgs e)
        {
            ImageOpen("");
        }

        private void miImageClose_Click(object sender, EventArgs e)
        {
            miRoot.Enabled = true;
            miOptions.Enabled = true;
            ResetControls();
            miImageClose.Enabled = false;
            miImageWipeGarbage.Enabled = false;
        }

        private void miImageWipeGarbage_Click(object sender, EventArgs e)
        {
            if (isWipeing)
            {
                stopCurrProc = true;
                return;
            }

            gbStruct.Text = "Structure";
            //tvTOC.LabelEdit = false;
            miImport.Enabled = false;
            miImageOpen.Enabled = false;
            miImageClose.Enabled = false;
            miImport.Visible = false;
            miExport.Visible = false;
            miImageWipeGarbage.Text = "Cancel";
            miImageWipeGarbage.Image = GCRebuilder.Properties.Resources.root_stop;
            cbBDFile.Enabled = false;
            btnBDSave.Enabled = false;
            stopCurrProc = false;
            isWipeing = true;

            ths = new System.Threading.ThreadStart(WipeGarbage);
            th = new System.Threading.Thread(ths);
            th.Start();
        }

        private void miImageExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miHelpAbout_Click(object sender, EventArgs e)
        {
            string msg = "Nintendo GameCube images rebuilder v1.1\r\n"
                + "Created by BSV (bsv798@gmail.com)\r\n"
                + "\r\n"
                + "Supported command line parameters:\r\n"
                + "    export file/folder from image: iso_path [node_path e file_or_folder]\r\n"
                + "    import file into image: iso_path [node_path i file_or_folder]\r\n"
                + "    rebuild image: root_path [iso_path]\r\n";

            MessageBox.Show(msg, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Info

        private void cbBDFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isRebuilding)
                LoadBannerInfo(cbBDFile.SelectedIndex, !rootOpened);
        }

        private void cbBDLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbBDLanguage.Enabled)
            {
                cbBDLanguage.SelectedIndex = 0;
                return;
            }

            if (!loading)
                LoadBannerLang(cbBDLanguage.SelectedIndex);
        }

        private void pbBDBanner_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                e.Graphics.ScaleTransform(2, 2);
                e.Graphics.DrawImage(img, new Point(0, 0));
            }
        }

        private void btnBDImport_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Windows Bitmap (*.bmp)|*.bmp", Title = "Import banner" };

            if (ofd.ShowDialog() == DialogResult.OK)
                SaveBannerImage(ofd.FileName);
        }

        private void btnBDExport_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Windows Bitmap (*.bmp)|*.bmp", Title = "Export banner" };

            if (sfd.ShowDialog() == DialogResult.OK)
                img.Save(sfd.FileName);
        }

        private void btnBDSave_Click(object sender, EventArgs e)
        {
            SaveBannerInfo(cbBDFile.SelectedIndex, !rootOpened);
        }

        private void bnrInfoChanged(object sender, EventArgs e)
        {
            SaveBannerLang(cbBDLanguage.SelectedIndex);
        }

        #endregion

        private void rbSortFileName_CheckedChanged(object sender, EventArgs e)
        {
            fileNameSort = rbSortFileName.Checked;

            if (!fileNameSort)
            {
                if (!isRebuilding && rootOpened && canEditTOC)
                    gbStruct.Text = "Structure (editable)";
            }
            else
                gbStruct.Text = "Structure";

            GenerateTreeView(fileNameSort);
        }

        private void rbSortAddress_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void miCancel_Click(object sender, EventArgs e)
        {
            if (isImpExping)
            {
                stopCurrProc = true;
                return;
            }
        }

    }
}
