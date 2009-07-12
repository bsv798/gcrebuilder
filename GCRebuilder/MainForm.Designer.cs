namespace GCRebuilder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tvTOC = new System.Windows.Forms.TreeView();
            this.cmsTVTOC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miImport = new System.Windows.Forms.ToolStripMenuItem();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.misep1 = new System.Windows.Forms.ToolStripSeparator();
            this.miImpFT = new System.Windows.Forms.ToolStripMenuItem();
            this.miExpFT = new System.Windows.Forms.ToolStripMenuItem();
            this.misep2 = new System.Windows.Forms.ToolStripSeparator();
            this.miRename = new System.Windows.Forms.ToolStripMenuItem();
            this.miCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.gbStruct = new System.Windows.Forms.GroupBox();
            this.tbEndIdx = new System.Windows.Forms.TextBox();
            this.lblEndIdx = new System.Windows.Forms.Label();
            this.tbStartIdx = new System.Windows.Forms.TextBox();
            this.lblStartIdx = new System.Windows.Forms.Label();
            this.gbSort = new System.Windows.Forms.GroupBox();
            this.rbSortAddress = new System.Windows.Forms.RadioButton();
            this.rbSortFileName = new System.Windows.Forms.RadioButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.sslblAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.sspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.gbBannerDetails = new System.Windows.Forms.GroupBox();
            this.btnBDSave = new System.Windows.Forms.Button();
            this.btnBDExport = new System.Windows.Forms.Button();
            this.btnBDImport = new System.Windows.Forms.Button();
            this.pbBDBanner = new System.Windows.Forms.PictureBox();
            this.lblBDBanner = new System.Windows.Forms.Label();
            this.tbBDDescription = new System.Windows.Forms.TextBox();
            this.lblBDDescription = new System.Windows.Forms.Label();
            this.lblBDLanguage = new System.Windows.Forms.Label();
            this.cbBDLanguage = new System.Windows.Forms.ComboBox();
            this.lblBDFile = new System.Windows.Forms.Label();
            this.cbBDFile = new System.Windows.Forms.ComboBox();
            this.tbBDLongMaker = new System.Windows.Forms.TextBox();
            this.lblBDLongMaker = new System.Windows.Forms.Label();
            this.tbBDLongName = new System.Windows.Forms.TextBox();
            this.lblBDLongName = new System.Windows.Forms.Label();
            this.tbBDShortMaker = new System.Windows.Forms.TextBox();
            this.lblBDShortMaker = new System.Windows.Forms.Label();
            this.tbBDVersion = new System.Windows.Forms.TextBox();
            this.lblBDVersion = new System.Windows.Forms.Label();
            this.tbBDShortName = new System.Windows.Forms.TextBox();
            this.lblBDShortName = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.miRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.miRootOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miRootSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miRootClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miRootStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miRootExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miImage = new System.Windows.Forms.ToolStripMenuItem();
            this.miImageOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miImageClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miImageWipeGarbage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miImageExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.miOptionsModifySystemFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.miOptionsDoNotUseGameToc = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.gbISODetails = new System.Windows.Forms.GroupBox();
            this.tbIDDate = new System.Windows.Forms.TextBox();
            this.lblIDDate = new System.Windows.Forms.Label();
            this.tbIDDiscID = new System.Windows.Forms.TextBox();
            this.lblIDDiskID = new System.Windows.Forms.Label();
            this.tbIDMakerCode = new System.Windows.Forms.TextBox();
            this.lblIDMakerCode = new System.Windows.Forms.Label();
            this.tbIDRegion = new System.Windows.Forms.TextBox();
            this.lblIDRegion = new System.Windows.Forms.Label();
            this.tbIDGameCode = new System.Windows.Forms.TextBox();
            this.lblIDGameCode = new System.Windows.Forms.Label();
            this.tbIDName = new System.Windows.Forms.TextBox();
            this.lblIDName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmsTVTOC.SuspendLayout();
            this.gbStruct.SuspendLayout();
            this.gbSort.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gbBannerDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBDBanner)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.gbISODetails.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTOC
            // 
            this.tvTOC.ContextMenuStrip = this.cmsTVTOC;
            this.tvTOC.Enabled = false;
            this.tvTOC.ImageIndex = 0;
            this.tvTOC.ImageList = this.imageList;
            this.tvTOC.Location = new System.Drawing.Point(9, 71);
            this.tvTOC.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.tvTOC.Name = "tvTOC";
            this.tvTOC.SelectedImageIndex = 0;
            this.tvTOC.ShowNodeToolTips = true;
            this.tvTOC.Size = new System.Drawing.Size(403, 331);
            this.tvTOC.TabIndex = 8;
            this.tvTOC.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvTOC_AfterLabelEdit);
            this.tvTOC.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTOC_AfterSelect);
            this.tvTOC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTOC_MouseDown);
            this.tvTOC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvTOC_KeyDown);
            // 
            // cmsTVTOC
            // 
            this.cmsTVTOC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImport,
            this.miExport,
            this.misep1,
            this.miImpFT,
            this.miExpFT,
            this.misep2,
            this.miRename,
            this.miCancel});
            this.cmsTVTOC.Name = "cmsTVTOC";
            this.cmsTVTOC.Size = new System.Drawing.Size(166, 148);
            this.cmsTVTOC.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTVTOC_Opening);
            // 
            // miImport
            // 
            this.miImport.Name = "miImport";
            this.miImport.Size = new System.Drawing.Size(165, 22);
            this.miImport.Text = "Import…";
            this.miImport.Visible = false;
            this.miImport.Click += new System.EventHandler(this.miImport_Click);
            // 
            // miExport
            // 
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(165, 22);
            this.miExport.Text = "Export…";
            this.miExport.Visible = false;
            this.miExport.Click += new System.EventHandler(this.miExport_Click);
            // 
            // misep1
            // 
            this.misep1.Name = "misep1";
            this.misep1.Size = new System.Drawing.Size(162, 6);
            this.misep1.Visible = false;
            // 
            // miImpFT
            // 
            this.miImpFT.Name = "miImpFT";
            this.miImpFT.Size = new System.Drawing.Size(165, 22);
            this.miImpFT.Text = "Import from-to…";
            this.miImpFT.Visible = false;
            this.miImpFT.Click += new System.EventHandler(this.miImpFT_Click);
            // 
            // miExpFT
            // 
            this.miExpFT.Name = "miExpFT";
            this.miExpFT.Size = new System.Drawing.Size(165, 22);
            this.miExpFT.Text = "Export from-to…";
            this.miExpFT.Visible = false;
            this.miExpFT.Click += new System.EventHandler(this.miExpFT_Click);
            // 
            // misep2
            // 
            this.misep2.Name = "misep2";
            this.misep2.Size = new System.Drawing.Size(162, 6);
            this.misep2.Visible = false;
            // 
            // miRename
            // 
            this.miRename.Name = "miRename";
            this.miRename.Size = new System.Drawing.Size(165, 22);
            this.miRename.Text = "Rename";
            this.miRename.Visible = false;
            this.miRename.Click += new System.EventHandler(this.miRename_Click);
            // 
            // miCancel
            // 
            this.miCancel.Name = "miCancel";
            this.miCancel.Size = new System.Drawing.Size(165, 22);
            this.miCancel.Text = "Cancel";
            this.miCancel.Visible = false;
            this.miCancel.Click += new System.EventHandler(this.miCancel_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // gbStruct
            // 
            this.gbStruct.Controls.Add(this.tbEndIdx);
            this.gbStruct.Controls.Add(this.lblEndIdx);
            this.gbStruct.Controls.Add(this.tbStartIdx);
            this.gbStruct.Controls.Add(this.lblStartIdx);
            this.gbStruct.Controls.Add(this.gbSort);
            this.gbStruct.Controls.Add(this.tvTOC);
            this.gbStruct.Location = new System.Drawing.Point(458, 11);
            this.gbStruct.Name = "gbStruct";
            this.gbStruct.Size = new System.Drawing.Size(421, 442);
            this.gbStruct.TabIndex = 9;
            this.gbStruct.TabStop = false;
            this.gbStruct.Text = "Structure";
            // 
            // tbEndIdx
            // 
            this.tbEndIdx.Enabled = false;
            this.tbEndIdx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbEndIdx.Location = new System.Drawing.Point(309, 408);
            this.tbEndIdx.MaxLength = 4;
            this.tbEndIdx.Name = "tbEndIdx";
            this.tbEndIdx.ReadOnly = true;
            this.tbEndIdx.Size = new System.Drawing.Size(103, 20);
            this.tbEndIdx.TabIndex = 17;
            // 
            // lblEndIdx
            // 
            this.lblEndIdx.AutoSize = true;
            this.lblEndIdx.Location = new System.Drawing.Point(236, 412);
            this.lblEndIdx.Margin = new System.Windows.Forms.Padding(3);
            this.lblEndIdx.Name = "lblEndIdx";
            this.lblEndIdx.Size = new System.Drawing.Size(57, 13);
            this.lblEndIdx.TabIndex = 16;
            this.lblEndIdx.Text = "End index:";
            // 
            // tbStartIdx
            // 
            this.tbStartIdx.Enabled = false;
            this.tbStartIdx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbStartIdx.Location = new System.Drawing.Point(79, 408);
            this.tbStartIdx.MaxLength = 4;
            this.tbStartIdx.Name = "tbStartIdx";
            this.tbStartIdx.ReadOnly = true;
            this.tbStartIdx.Size = new System.Drawing.Size(103, 20);
            this.tbStartIdx.TabIndex = 15;
            // 
            // lblStartIdx
            // 
            this.lblStartIdx.AutoSize = true;
            this.lblStartIdx.Location = new System.Drawing.Point(6, 412);
            this.lblStartIdx.Margin = new System.Windows.Forms.Padding(3);
            this.lblStartIdx.Name = "lblStartIdx";
            this.lblStartIdx.Size = new System.Drawing.Size(60, 13);
            this.lblStartIdx.TabIndex = 14;
            this.lblStartIdx.Text = "Start index:";
            // 
            // gbSort
            // 
            this.gbSort.Controls.Add(this.rbSortAddress);
            this.gbSort.Controls.Add(this.rbSortFileName);
            this.gbSort.Location = new System.Drawing.Point(9, 19);
            this.gbSort.Name = "gbSort";
            this.gbSort.Size = new System.Drawing.Size(403, 45);
            this.gbSort.TabIndex = 9;
            this.gbSort.TabStop = false;
            this.gbSort.Text = "Sort method";
            // 
            // rbSortAddress
            // 
            this.rbSortAddress.AutoSize = true;
            this.rbSortAddress.Enabled = false;
            this.rbSortAddress.Location = new System.Drawing.Point(199, 19);
            this.rbSortAddress.Name = "rbSortAddress";
            this.rbSortAddress.Size = new System.Drawing.Size(100, 17);
            this.rbSortAddress.TabIndex = 1;
            this.rbSortAddress.Text = "Addresses table";
            this.rbSortAddress.UseVisualStyleBackColor = true;
            this.rbSortAddress.CheckedChanged += new System.EventHandler(this.rbSortAddress_CheckedChanged);
            // 
            // rbSortFileName
            // 
            this.rbSortFileName.AutoSize = true;
            this.rbSortFileName.Checked = true;
            this.rbSortFileName.Enabled = false;
            this.rbSortFileName.Location = new System.Drawing.Point(6, 19);
            this.rbSortFileName.Name = "rbSortFileName";
            this.rbSortFileName.Size = new System.Drawing.Size(101, 17);
            this.rbSortFileName.TabIndex = 0;
            this.rbSortFileName.TabStop = true;
            this.rbSortFileName.Text = "File names table";
            this.rbSortFileName.UseVisualStyleBackColor = true;
            this.rbSortFileName.CheckedChanged += new System.EventHandler(this.rbSortFileName_CheckedChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslblAction,
            this.sspbProgress});
            this.statusStrip.Location = new System.Drawing.Point(0, 487);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(886, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "Progress";
            // 
            // sslblAction
            // 
            this.sslblAction.AutoSize = false;
            this.sslblAction.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sslblAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sslblAction.Name = "sslblAction";
            this.sslblAction.Size = new System.Drawing.Size(256, 17);
            this.sslblAction.Tag = "Action: ";
            this.sslblAction.Text = "Ready";
            this.sslblAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sspbProgress
            // 
            this.sspbProgress.Name = "sspbProgress";
            this.sspbProgress.Size = new System.Drawing.Size(628, 16);
            this.sspbProgress.Step = 1;
            // 
            // gbBannerDetails
            // 
            this.gbBannerDetails.Controls.Add(this.btnBDSave);
            this.gbBannerDetails.Controls.Add(this.btnBDExport);
            this.gbBannerDetails.Controls.Add(this.btnBDImport);
            this.gbBannerDetails.Controls.Add(this.pbBDBanner);
            this.gbBannerDetails.Controls.Add(this.lblBDBanner);
            this.gbBannerDetails.Controls.Add(this.tbBDDescription);
            this.gbBannerDetails.Controls.Add(this.lblBDDescription);
            this.gbBannerDetails.Controls.Add(this.lblBDLanguage);
            this.gbBannerDetails.Controls.Add(this.cbBDLanguage);
            this.gbBannerDetails.Controls.Add(this.lblBDFile);
            this.gbBannerDetails.Controls.Add(this.cbBDFile);
            this.gbBannerDetails.Controls.Add(this.tbBDLongMaker);
            this.gbBannerDetails.Controls.Add(this.lblBDLongMaker);
            this.gbBannerDetails.Controls.Add(this.tbBDLongName);
            this.gbBannerDetails.Controls.Add(this.lblBDLongName);
            this.gbBannerDetails.Controls.Add(this.tbBDShortMaker);
            this.gbBannerDetails.Controls.Add(this.lblBDShortMaker);
            this.gbBannerDetails.Controls.Add(this.tbBDVersion);
            this.gbBannerDetails.Controls.Add(this.lblBDVersion);
            this.gbBannerDetails.Controls.Add(this.tbBDShortName);
            this.gbBannerDetails.Controls.Add(this.lblBDShortName);
            this.gbBannerDetails.Location = new System.Drawing.Point(7, 124);
            this.gbBannerDetails.Name = "gbBannerDetails";
            this.gbBannerDetails.Size = new System.Drawing.Size(437, 329);
            this.gbBannerDetails.TabIndex = 12;
            this.gbBannerDetails.TabStop = false;
            this.gbBannerDetails.Text = "Banner details";
            // 
            // btnBDSave
            // 
            this.btnBDSave.Enabled = false;
            this.btnBDSave.Location = new System.Drawing.Point(279, 292);
            this.btnBDSave.Name = "btnBDSave";
            this.btnBDSave.Size = new System.Drawing.Size(152, 23);
            this.btnBDSave.TabIndex = 32;
            this.btnBDSave.Text = "Save changes";
            this.btnBDSave.UseVisualStyleBackColor = true;
            this.btnBDSave.Click += new System.EventHandler(this.btnBDSave_Click);
            // 
            // btnBDExport
            // 
            this.btnBDExport.Enabled = false;
            this.btnBDExport.Location = new System.Drawing.Point(279, 263);
            this.btnBDExport.Name = "btnBDExport";
            this.btnBDExport.Size = new System.Drawing.Size(75, 23);
            this.btnBDExport.TabIndex = 31;
            this.btnBDExport.Text = "Export…";
            this.btnBDExport.UseVisualStyleBackColor = true;
            this.btnBDExport.Click += new System.EventHandler(this.btnBDExport_Click);
            // 
            // btnBDImport
            // 
            this.btnBDImport.Enabled = false;
            this.btnBDImport.Location = new System.Drawing.Point(279, 220);
            this.btnBDImport.Name = "btnBDImport";
            this.btnBDImport.Size = new System.Drawing.Size(75, 23);
            this.btnBDImport.TabIndex = 30;
            this.btnBDImport.Text = "Import…";
            this.btnBDImport.UseVisualStyleBackColor = true;
            this.btnBDImport.Click += new System.EventHandler(this.btnBDImport_Click);
            // 
            // pbBDBanner
            // 
            this.pbBDBanner.BackColor = System.Drawing.SystemColors.Window;
            this.pbBDBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBDBanner.Location = new System.Drawing.Point(79, 220);
            this.pbBDBanner.Name = "pbBDBanner";
            this.pbBDBanner.Size = new System.Drawing.Size(192, 64);
            this.pbBDBanner.TabIndex = 29;
            this.pbBDBanner.TabStop = false;
            this.pbBDBanner.Paint += new System.Windows.Forms.PaintEventHandler(this.pbBDBanner_Paint);
            // 
            // lblBDBanner
            // 
            this.lblBDBanner.AutoSize = true;
            this.lblBDBanner.Location = new System.Drawing.Point(5, 224);
            this.lblBDBanner.Margin = new System.Windows.Forms.Padding(3);
            this.lblBDBanner.Name = "lblBDBanner";
            this.lblBDBanner.Size = new System.Drawing.Size(41, 13);
            this.lblBDBanner.TabIndex = 28;
            this.lblBDBanner.Text = "Banner";
            // 
            // tbBDDescription
            // 
            this.tbBDDescription.Enabled = false;
            this.tbBDDescription.Font = new System.Drawing.Font("MS Mincho", 9.25F);
            this.tbBDDescription.Location = new System.Drawing.Point(78, 176);
            this.tbBDDescription.MaxLength = 127;
            this.tbBDDescription.Multiline = true;
            this.tbBDDescription.Name = "tbBDDescription";
            this.tbBDDescription.Size = new System.Drawing.Size(353, 38);
            this.tbBDDescription.TabIndex = 27;
            // 
            // lblBDDescription
            // 
            this.lblBDDescription.AutoSize = true;
            this.lblBDDescription.Location = new System.Drawing.Point(5, 180);
            this.lblBDDescription.Margin = new System.Windows.Forms.Padding(3);
            this.lblBDDescription.Name = "lblBDDescription";
            this.lblBDDescription.Size = new System.Drawing.Size(63, 13);
            this.lblBDDescription.TabIndex = 26;
            this.lblBDDescription.Text = "Description:";
            // 
            // lblBDLanguage
            // 
            this.lblBDLanguage.AutoSize = true;
            this.lblBDLanguage.Location = new System.Drawing.Point(248, 48);
            this.lblBDLanguage.Margin = new System.Windows.Forms.Padding(3);
            this.lblBDLanguage.Name = "lblBDLanguage";
            this.lblBDLanguage.Size = new System.Drawing.Size(58, 13);
            this.lblBDLanguage.TabIndex = 25;
            this.lblBDLanguage.Text = "Language:";
            // 
            // cbBDLanguage
            // 
            this.cbBDLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBDLanguage.Enabled = false;
            this.cbBDLanguage.FormattingEnabled = true;
            this.cbBDLanguage.Items.AddRange(new object[] {
            "English",
            "German",
            "French",
            "Spanish",
            "Italian",
            "Dutch"});
            this.cbBDLanguage.Location = new System.Drawing.Point(321, 45);
            this.cbBDLanguage.Name = "cbBDLanguage";
            this.cbBDLanguage.Size = new System.Drawing.Size(110, 21);
            this.cbBDLanguage.TabIndex = 24;
            this.cbBDLanguage.SelectedIndexChanged += new System.EventHandler(this.cbBDLanguage_SelectedIndexChanged);
            // 
            // lblBDFile
            // 
            this.lblBDFile.AutoSize = true;
            this.lblBDFile.Location = new System.Drawing.Point(6, 22);
            this.lblBDFile.Margin = new System.Windows.Forms.Padding(3);
            this.lblBDFile.Name = "lblBDFile";
            this.lblBDFile.Size = new System.Drawing.Size(26, 13);
            this.lblBDFile.TabIndex = 23;
            this.lblBDFile.Text = "File:";
            // 
            // cbBDFile
            // 
            this.cbBDFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBDFile.Enabled = false;
            this.cbBDFile.FormattingEnabled = true;
            this.cbBDFile.Location = new System.Drawing.Point(79, 19);
            this.cbBDFile.Name = "cbBDFile";
            this.cbBDFile.Size = new System.Drawing.Size(139, 21);
            this.cbBDFile.TabIndex = 22;
            this.cbBDFile.SelectedIndexChanged += new System.EventHandler(this.cbBDFile_SelectedIndexChanged);
            // 
            // tbBDLongMaker
            // 
            this.tbBDLongMaker.Enabled = false;
            this.tbBDLongMaker.Font = new System.Drawing.Font("MS Mincho", 9.25F);
            this.tbBDLongMaker.Location = new System.Drawing.Point(78, 150);
            this.tbBDLongMaker.MaxLength = 63;
            this.tbBDLongMaker.Name = "tbBDLongMaker";
            this.tbBDLongMaker.Size = new System.Drawing.Size(353, 20);
            this.tbBDLongMaker.TabIndex = 21;
            // 
            // lblBDLongMaker
            // 
            this.lblBDLongMaker.AutoSize = true;
            this.lblBDLongMaker.Location = new System.Drawing.Point(5, 154);
            this.lblBDLongMaker.Margin = new System.Windows.Forms.Padding(3);
            this.lblBDLongMaker.Name = "lblBDLongMaker";
            this.lblBDLongMaker.Size = new System.Drawing.Size(66, 13);
            this.lblBDLongMaker.TabIndex = 20;
            this.lblBDLongMaker.Text = "Long maker:";
            // 
            // tbBDLongName
            // 
            this.tbBDLongName.Enabled = false;
            this.tbBDLongName.Font = new System.Drawing.Font("MS Mincho", 9.25F);
            this.tbBDLongName.Location = new System.Drawing.Point(78, 124);
            this.tbBDLongName.MaxLength = 63;
            this.tbBDLongName.Name = "tbBDLongName";
            this.tbBDLongName.Size = new System.Drawing.Size(353, 20);
            this.tbBDLongName.TabIndex = 19;
            // 
            // lblBDLongName
            // 
            this.lblBDLongName.AutoSize = true;
            this.lblBDLongName.Location = new System.Drawing.Point(5, 128);
            this.lblBDLongName.Margin = new System.Windows.Forms.Padding(3);
            this.lblBDLongName.Name = "lblBDLongName";
            this.lblBDLongName.Size = new System.Drawing.Size(63, 13);
            this.lblBDLongName.TabIndex = 18;
            this.lblBDLongName.Text = "Long name:";
            // 
            // tbBDShortMaker
            // 
            this.tbBDShortMaker.Enabled = false;
            this.tbBDShortMaker.Font = new System.Drawing.Font("MS Mincho", 9.25F);
            this.tbBDShortMaker.Location = new System.Drawing.Point(78, 98);
            this.tbBDShortMaker.MaxLength = 31;
            this.tbBDShortMaker.Name = "tbBDShortMaker";
            this.tbBDShortMaker.Size = new System.Drawing.Size(353, 20);
            this.tbBDShortMaker.TabIndex = 17;
            // 
            // lblBDShortMaker
            // 
            this.lblBDShortMaker.AutoSize = true;
            this.lblBDShortMaker.Location = new System.Drawing.Point(5, 102);
            this.lblBDShortMaker.Margin = new System.Windows.Forms.Padding(3);
            this.lblBDShortMaker.Name = "lblBDShortMaker";
            this.lblBDShortMaker.Size = new System.Drawing.Size(67, 13);
            this.lblBDShortMaker.TabIndex = 16;
            this.lblBDShortMaker.Text = "Short maker:";
            // 
            // tbBDVersion
            // 
            this.tbBDVersion.Enabled = false;
            this.tbBDVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbBDVersion.Location = new System.Drawing.Point(78, 46);
            this.tbBDVersion.MaxLength = 4;
            this.tbBDVersion.Name = "tbBDVersion";
            this.tbBDVersion.ReadOnly = true;
            this.tbBDVersion.Size = new System.Drawing.Size(140, 20);
            this.tbBDVersion.TabIndex = 13;
            // 
            // lblBDVersion
            // 
            this.lblBDVersion.AutoSize = true;
            this.lblBDVersion.Location = new System.Drawing.Point(5, 50);
            this.lblBDVersion.Margin = new System.Windows.Forms.Padding(3);
            this.lblBDVersion.Name = "lblBDVersion";
            this.lblBDVersion.Size = new System.Drawing.Size(45, 13);
            this.lblBDVersion.TabIndex = 12;
            this.lblBDVersion.Text = "Version:";
            // 
            // tbBDShortName
            // 
            this.tbBDShortName.Enabled = false;
            this.tbBDShortName.Font = new System.Drawing.Font("MS Mincho", 9.25F);
            this.tbBDShortName.Location = new System.Drawing.Point(78, 72);
            this.tbBDShortName.MaxLength = 31;
            this.tbBDShortName.Name = "tbBDShortName";
            this.tbBDShortName.Size = new System.Drawing.Size(353, 20);
            this.tbBDShortName.TabIndex = 1;
            // 
            // lblBDShortName
            // 
            this.lblBDShortName.AutoSize = true;
            this.lblBDShortName.Location = new System.Drawing.Point(5, 76);
            this.lblBDShortName.Margin = new System.Windows.Forms.Padding(3);
            this.lblBDShortName.Name = "lblBDShortName";
            this.lblBDShortName.Size = new System.Drawing.Size(64, 13);
            this.lblBDShortName.TabIndex = 0;
            this.lblBDShortName.Text = "Short name:";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRoot,
            this.miImage,
            this.miOptions,
            this.miHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(886, 24);
            this.menuStrip.TabIndex = 13;
            this.menuStrip.Text = "menuStrip1";
            // 
            // miRoot
            // 
            this.miRoot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miRoot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRootOpen,
            this.miRootSave,
            this.miRootClose,
            this.toolStripMenuItem1,
            this.miRootStart,
            this.toolStripMenuItem2,
            this.miRootExit});
            this.miRoot.Name = "miRoot";
            this.miRoot.Size = new System.Drawing.Size(42, 20);
            this.miRoot.Text = "Root";
            // 
            // miRootOpen
            // 
            this.miRootOpen.Image = global::GCRebuilder.Properties.Resources.root_open;
            this.miRootOpen.Name = "miRootOpen";
            this.miRootOpen.Size = new System.Drawing.Size(120, 22);
            this.miRootOpen.Text = "Open…";
            this.miRootOpen.Click += new System.EventHandler(this.miRootOpen_Click);
            // 
            // miRootSave
            // 
            this.miRootSave.Image = global::GCRebuilder.Properties.Resources.root_save;
            this.miRootSave.Name = "miRootSave";
            this.miRootSave.Size = new System.Drawing.Size(120, 22);
            this.miRootSave.Text = "Save…";
            this.miRootSave.Click += new System.EventHandler(this.miRootSave_Click);
            // 
            // miRootClose
            // 
            this.miRootClose.Enabled = false;
            this.miRootClose.Image = global::GCRebuilder.Properties.Resources.root_close;
            this.miRootClose.Name = "miRootClose";
            this.miRootClose.Size = new System.Drawing.Size(120, 22);
            this.miRootClose.Text = "Close";
            this.miRootClose.Click += new System.EventHandler(this.miRootClose_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 6);
            // 
            // miRootStart
            // 
            this.miRootStart.Enabled = false;
            this.miRootStart.Image = global::GCRebuilder.Properties.Resources.root_run;
            this.miRootStart.Name = "miRootStart";
            this.miRootStart.Size = new System.Drawing.Size(120, 22);
            this.miRootStart.Text = "Rebuild";
            this.miRootStart.Click += new System.EventHandler(this.miRootStart_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 6);
            // 
            // miRootExit
            // 
            this.miRootExit.Image = global::GCRebuilder.Properties.Resources.exit;
            this.miRootExit.Name = "miRootExit";
            this.miRootExit.Size = new System.Drawing.Size(120, 22);
            this.miRootExit.Text = "Exit";
            this.miRootExit.Click += new System.EventHandler(this.miRootExit_Click);
            // 
            // miImage
            // 
            this.miImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImageOpen,
            this.miImageClose,
            this.toolStripSeparator1,
            this.miImageWipeGarbage,
            this.toolStripSeparator2,
            this.miImageExit});
            this.miImage.Name = "miImage";
            this.miImage.Size = new System.Drawing.Size(49, 20);
            this.miImage.Text = "Image";
            // 
            // miImageOpen
            // 
            this.miImageOpen.Image = ((System.Drawing.Image)(resources.GetObject("miImageOpen.Image")));
            this.miImageOpen.Name = "miImageOpen";
            this.miImageOpen.Size = new System.Drawing.Size(152, 22);
            this.miImageOpen.Text = "Open…";
            this.miImageOpen.Click += new System.EventHandler(this.miImageOpen_Click);
            // 
            // miImageClose
            // 
            this.miImageClose.Enabled = false;
            this.miImageClose.Image = ((System.Drawing.Image)(resources.GetObject("miImageClose.Image")));
            this.miImageClose.Name = "miImageClose";
            this.miImageClose.Size = new System.Drawing.Size(152, 22);
            this.miImageClose.Text = "Close";
            this.miImageClose.Click += new System.EventHandler(this.miImageClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // miImageWipeGarbage
            // 
            this.miImageWipeGarbage.Enabled = false;
            this.miImageWipeGarbage.Image = global::GCRebuilder.Properties.Resources.wipe;
            this.miImageWipeGarbage.Name = "miImageWipeGarbage";
            this.miImageWipeGarbage.Size = new System.Drawing.Size(152, 22);
            this.miImageWipeGarbage.Text = "Wipe garbage";
            this.miImageWipeGarbage.Click += new System.EventHandler(this.miImageWipeGarbage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // miImageExit
            // 
            this.miImageExit.Image = global::GCRebuilder.Properties.Resources.exit;
            this.miImageExit.Name = "miImageExit";
            this.miImageExit.Size = new System.Drawing.Size(152, 22);
            this.miImageExit.Text = "Exit";
            this.miImageExit.Click += new System.EventHandler(this.miImageExit_Click);
            // 
            // miOptions
            // 
            this.miOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOptionsModifySystemFiles,
            this.miOptionsDoNotUseGameToc});
            this.miOptions.Name = "miOptions";
            this.miOptions.Size = new System.Drawing.Size(56, 20);
            this.miOptions.Text = "Options";
            // 
            // miOptionsModifySystemFiles
            // 
            this.miOptionsModifySystemFiles.CheckOnClick = true;
            this.miOptionsModifySystemFiles.Name = "miOptionsModifySystemFiles";
            this.miOptionsModifySystemFiles.Size = new System.Drawing.Size(189, 22);
            this.miOptionsModifySystemFiles.Text = "Modify system files";
            // 
            // miOptionsDoNotUseGameToc
            // 
            this.miOptionsDoNotUseGameToc.CheckOnClick = true;
            this.miOptionsDoNotUseGameToc.Name = "miOptionsDoNotUseGameToc";
            this.miOptionsDoNotUseGameToc.Size = new System.Drawing.Size(189, 22);
            this.miOptionsDoNotUseGameToc.Text = "Do not use \'game.toc\'";
            // 
            // miHelp
            // 
            this.miHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpAbout});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(40, 20);
            this.miHelp.Text = "Help";
            // 
            // miHelpAbout
            // 
            this.miHelpAbout.Image = global::GCRebuilder.Properties.Resources.about;
            this.miHelpAbout.Name = "miHelpAbout";
            this.miHelpAbout.Size = new System.Drawing.Size(114, 22);
            this.miHelpAbout.Text = "About";
            this.miHelpAbout.Click += new System.EventHandler(this.miHelpAbout_Click);
            // 
            // gbISODetails
            // 
            this.gbISODetails.Controls.Add(this.tbIDDate);
            this.gbISODetails.Controls.Add(this.lblIDDate);
            this.gbISODetails.Controls.Add(this.tbIDDiscID);
            this.gbISODetails.Controls.Add(this.lblIDDiskID);
            this.gbISODetails.Controls.Add(this.tbIDMakerCode);
            this.gbISODetails.Controls.Add(this.lblIDMakerCode);
            this.gbISODetails.Controls.Add(this.tbIDRegion);
            this.gbISODetails.Controls.Add(this.lblIDRegion);
            this.gbISODetails.Controls.Add(this.tbIDGameCode);
            this.gbISODetails.Controls.Add(this.lblIDGameCode);
            this.gbISODetails.Controls.Add(this.tbIDName);
            this.gbISODetails.Controls.Add(this.lblIDName);
            this.gbISODetails.Location = new System.Drawing.Point(7, 11);
            this.gbISODetails.Name = "gbISODetails";
            this.gbISODetails.Size = new System.Drawing.Size(437, 103);
            this.gbISODetails.TabIndex = 10;
            this.gbISODetails.TabStop = false;
            this.gbISODetails.Text = "Image details";
            // 
            // tbIDDate
            // 
            this.tbIDDate.BackColor = System.Drawing.SystemColors.Control;
            this.tbIDDate.Enabled = false;
            this.tbIDDate.Location = new System.Drawing.Point(321, 71);
            this.tbIDDate.Name = "tbIDDate";
            this.tbIDDate.ReadOnly = true;
            this.tbIDDate.Size = new System.Drawing.Size(110, 20);
            this.tbIDDate.TabIndex = 15;
            // 
            // lblIDDate
            // 
            this.lblIDDate.AutoSize = true;
            this.lblIDDate.Location = new System.Drawing.Point(248, 75);
            this.lblIDDate.Margin = new System.Windows.Forms.Padding(3);
            this.lblIDDate.Name = "lblIDDate";
            this.lblIDDate.Size = new System.Drawing.Size(33, 13);
            this.lblIDDate.TabIndex = 14;
            this.lblIDDate.Text = "Date:";
            // 
            // tbIDDiscID
            // 
            this.tbIDDiscID.BackColor = System.Drawing.SystemColors.Control;
            this.tbIDDiscID.Enabled = false;
            this.tbIDDiscID.Location = new System.Drawing.Point(389, 19);
            this.tbIDDiscID.Name = "tbIDDiscID";
            this.tbIDDiscID.ReadOnly = true;
            this.tbIDDiscID.Size = new System.Drawing.Size(42, 20);
            this.tbIDDiscID.TabIndex = 13;
            // 
            // lblIDDiskID
            // 
            this.lblIDDiskID.AutoSize = true;
            this.lblIDDiskID.Location = new System.Drawing.Point(316, 23);
            this.lblIDDiskID.Margin = new System.Windows.Forms.Padding(3);
            this.lblIDDiskID.Name = "lblIDDiskID";
            this.lblIDDiskID.Size = new System.Drawing.Size(45, 13);
            this.lblIDDiskID.TabIndex = 12;
            this.lblIDDiskID.Text = "Disc ID:";
            // 
            // tbIDMakerCode
            // 
            this.tbIDMakerCode.BackColor = System.Drawing.SystemColors.Control;
            this.tbIDMakerCode.Enabled = false;
            this.tbIDMakerCode.Location = new System.Drawing.Point(79, 71);
            this.tbIDMakerCode.Name = "tbIDMakerCode";
            this.tbIDMakerCode.ReadOnly = true;
            this.tbIDMakerCode.Size = new System.Drawing.Size(139, 20);
            this.tbIDMakerCode.TabIndex = 7;
            // 
            // lblIDMakerCode
            // 
            this.lblIDMakerCode.AutoSize = true;
            this.lblIDMakerCode.Location = new System.Drawing.Point(6, 75);
            this.lblIDMakerCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblIDMakerCode.Name = "lblIDMakerCode";
            this.lblIDMakerCode.Size = new System.Drawing.Size(67, 13);
            this.lblIDMakerCode.TabIndex = 6;
            this.lblIDMakerCode.Text = "Maker code:";
            // 
            // tbIDRegion
            // 
            this.tbIDRegion.BackColor = System.Drawing.SystemColors.Control;
            this.tbIDRegion.Enabled = false;
            this.tbIDRegion.Location = new System.Drawing.Point(321, 45);
            this.tbIDRegion.Name = "tbIDRegion";
            this.tbIDRegion.ReadOnly = true;
            this.tbIDRegion.Size = new System.Drawing.Size(110, 20);
            this.tbIDRegion.TabIndex = 5;
            // 
            // lblIDRegion
            // 
            this.lblIDRegion.AutoSize = true;
            this.lblIDRegion.Location = new System.Drawing.Point(248, 48);
            this.lblIDRegion.Margin = new System.Windows.Forms.Padding(3);
            this.lblIDRegion.Name = "lblIDRegion";
            this.lblIDRegion.Size = new System.Drawing.Size(44, 13);
            this.lblIDRegion.TabIndex = 4;
            this.lblIDRegion.Text = "Region:";
            // 
            // tbIDGameCode
            // 
            this.tbIDGameCode.BackColor = System.Drawing.SystemColors.Control;
            this.tbIDGameCode.Enabled = false;
            this.tbIDGameCode.Location = new System.Drawing.Point(79, 45);
            this.tbIDGameCode.Name = "tbIDGameCode";
            this.tbIDGameCode.ReadOnly = true;
            this.tbIDGameCode.Size = new System.Drawing.Size(139, 20);
            this.tbIDGameCode.TabIndex = 3;
            // 
            // lblIDGameCode
            // 
            this.lblIDGameCode.AutoSize = true;
            this.lblIDGameCode.Location = new System.Drawing.Point(6, 49);
            this.lblIDGameCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblIDGameCode.Name = "lblIDGameCode";
            this.lblIDGameCode.Size = new System.Drawing.Size(65, 13);
            this.lblIDGameCode.TabIndex = 2;
            this.lblIDGameCode.Text = "Game code:";
            // 
            // tbIDName
            // 
            this.tbIDName.BackColor = System.Drawing.SystemColors.Control;
            this.tbIDName.Enabled = false;
            this.tbIDName.Location = new System.Drawing.Point(79, 19);
            this.tbIDName.Name = "tbIDName";
            this.tbIDName.ReadOnly = true;
            this.tbIDName.Size = new System.Drawing.Size(218, 20);
            this.tbIDName.TabIndex = 1;
            // 
            // lblIDName
            // 
            this.lblIDName.AutoSize = true;
            this.lblIDName.Location = new System.Drawing.Point(6, 23);
            this.lblIDName.Margin = new System.Windows.Forms.Padding(3);
            this.lblIDName.Name = "lblIDName";
            this.lblIDName.Size = new System.Drawing.Size(38, 13);
            this.lblIDName.TabIndex = 0;
            this.lblIDName.Text = "Name:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gbStruct);
            this.panel1.Controls.Add(this.gbISODetails);
            this.panel1.Controls.Add(this.gbBannerDetails);
            this.panel1.Location = new System.Drawing.Point(-2, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 482);
            this.panel1.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 509);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "GCRebuilder v1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.cmsTVTOC.ResumeLayout(false);
            this.gbStruct.ResumeLayout(false);
            this.gbStruct.PerformLayout();
            this.gbSort.ResumeLayout(false);
            this.gbSort.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbBannerDetails.ResumeLayout(false);
            this.gbBannerDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBDBanner)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.gbISODetails.ResumeLayout(false);
            this.gbISODetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvTOC;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip cmsTVTOC;
        private System.Windows.Forms.ToolStripMenuItem miImport;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.ToolStripSeparator misep1;
        private System.Windows.Forms.ToolStripMenuItem miImpFT;
        private System.Windows.Forms.ToolStripMenuItem miExpFT;
        private System.Windows.Forms.ToolStripSeparator misep2;
        private System.Windows.Forms.ToolStripMenuItem miRename;
        private System.Windows.Forms.GroupBox gbStruct;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel sslblAction;
        private System.Windows.Forms.ToolStripProgressBar sspbProgress;
        private System.Windows.Forms.GroupBox gbBannerDetails;
        private System.Windows.Forms.TextBox tbBDVersion;
        private System.Windows.Forms.Label lblBDVersion;
        private System.Windows.Forms.TextBox tbBDShortName;
        private System.Windows.Forms.Label lblBDShortName;
        private System.Windows.Forms.TextBox tbBDLongMaker;
        private System.Windows.Forms.Label lblBDLongMaker;
        private System.Windows.Forms.TextBox tbBDLongName;
        private System.Windows.Forms.Label lblBDLongName;
        private System.Windows.Forms.TextBox tbBDShortMaker;
        private System.Windows.Forms.Label lblBDShortMaker;
        private System.Windows.Forms.Label lblBDLanguage;
        private System.Windows.Forms.ComboBox cbBDLanguage;
        private System.Windows.Forms.Label lblBDFile;
        private System.Windows.Forms.ComboBox cbBDFile;
        private System.Windows.Forms.Label lblBDBanner;
        private System.Windows.Forms.TextBox tbBDDescription;
        private System.Windows.Forms.Label lblBDDescription;
        private System.Windows.Forms.PictureBox pbBDBanner;
        private System.Windows.Forms.Button btnBDExport;
        private System.Windows.Forms.Button btnBDImport;
        private System.Windows.Forms.Button btnBDSave;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem miRoot;
        private System.Windows.Forms.GroupBox gbISODetails;
        private System.Windows.Forms.TextBox tbIDDate;
        private System.Windows.Forms.Label lblIDDate;
        private System.Windows.Forms.TextBox tbIDDiscID;
        private System.Windows.Forms.Label lblIDDiskID;
        private System.Windows.Forms.TextBox tbIDMakerCode;
        private System.Windows.Forms.Label lblIDMakerCode;
        private System.Windows.Forms.TextBox tbIDRegion;
        private System.Windows.Forms.Label lblIDRegion;
        private System.Windows.Forms.TextBox tbIDGameCode;
        private System.Windows.Forms.Label lblIDGameCode;
        private System.Windows.Forms.TextBox tbIDName;
        private System.Windows.Forms.Label lblIDName;
        private System.Windows.Forms.ToolStripMenuItem miRootOpen;
        private System.Windows.Forms.ToolStripMenuItem miRootSave;
        private System.Windows.Forms.ToolStripMenuItem miRootClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miRootStart;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miRootExit;
        private System.Windows.Forms.ToolStripMenuItem miImage;
        private System.Windows.Forms.ToolStripMenuItem miImageOpen;
        private System.Windows.Forms.ToolStripMenuItem miImageClose;
        private System.Windows.Forms.ToolStripMenuItem miOptions;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
        private System.Windows.Forms.GroupBox gbSort;
        private System.Windows.Forms.RadioButton rbSortAddress;
        private System.Windows.Forms.RadioButton rbSortFileName;
        private System.Windows.Forms.ToolStripMenuItem miOptionsModifySystemFiles;
        private System.Windows.Forms.ToolStripMenuItem miOptionsDoNotUseGameToc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miImageExit;
        private System.Windows.Forms.ToolStripMenuItem miImageWipeGarbage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox tbStartIdx;
        private System.Windows.Forms.Label lblStartIdx;
        private System.Windows.Forms.TextBox tbEndIdx;
        private System.Windows.Forms.Label lblEndIdx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem miCancel;
    }
}

