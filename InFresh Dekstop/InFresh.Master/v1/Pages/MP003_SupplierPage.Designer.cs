namespace InFresh.Master.v1.Pages
{
    partial class MP003_SupplierPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MP003_SupplierPage));
            this.tlsToolbar = new System.Windows.Forms.ToolStrip();
            this.tsbList = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTruncate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbGenerate = new System.Windows.Forms.ToolStripButton();
            this.tslRecord = new System.Windows.Forms.ToolStripLabel();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbPrevious = new System.Windows.Forms.ToolStripButton();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOldCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFax1 = new System.Windows.Forms.MaskedTextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lnkEmail = new System.Windows.Forms.LinkLabel();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.MaskedTextBox();
            this.stsStatusbar = new System.Windows.Forms.StatusStrip();
            this.tsxStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stxGap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.bgwWorker = new System.ComponentModel.BackgroundWorker();
            this.leftTabControl1 = new InFresh.Controls.v1.LeftTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tlsToolbar.SuspendLayout();
            this.stsStatusbar.SuspendLayout();
            this.leftTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsToolbar
            // 
            this.tlsToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbList,
            this.tsbRefresh,
            this.toolStripSeparator7,
            this.tsbNew,
            this.tsbEdit,
            this.tsbSave,
            this.tsbCancel,
            this.toolStripSeparator8,
            this.tsbGenerate,
            this.tslRecord,
            this.tsbLast,
            this.tsbNext,
            this.tsbPrevious,
            this.tsbFirst});
            this.tlsToolbar.Location = new System.Drawing.Point(0, 0);
            this.tlsToolbar.Name = "tlsToolbar";
            this.tlsToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tlsToolbar.Size = new System.Drawing.Size(834, 25);
            this.tlsToolbar.Stretch = true;
            this.tlsToolbar.TabIndex = 68;
            this.tlsToolbar.Text = "toolStrip1";
            // 
            // tsbList
            // 
            this.tsbList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbList.Enabled = false;
            this.tsbList.Image = global::InFresh.Master.Properties.Resources.ic_list;
            this.tsbList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbList.Name = "tsbList";
            this.tsbList.Size = new System.Drawing.Size(23, 22);
            this.tsbList.Text = "List All";
            this.tsbList.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Enabled = false;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.ToolTipText = "Refresh Data";
            this.tsbRefresh.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Enabled = false;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 22);
            this.tsbNew.Text = "New (Ctrl + N)";
            this.tsbNew.ToolTipText = "New Record";
            this.tsbNew.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Enabled = false;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbEdit.Text = "Edit (F2)";
            this.tsbEdit.ToolTipText = "Edit Selected Record";
            this.tsbEdit.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save (Ctrl + S)";
            this.tsbSave.ToolTipText = "Commit Changes";
            this.tsbSave.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDelete,
            this.tsbTruncate});
            this.tsbCancel.Enabled = false;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(32, 22);
            this.tsbCancel.Text = "Delete";
            this.tsbCancel.ButtonClick += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(128, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tsbTruncate
            // 
            this.tsbTruncate.Image = ((System.Drawing.Image)(resources.GetObject("tsbTruncate.Image")));
            this.tsbTruncate.Name = "tsbTruncate";
            this.tsbTruncate.Size = new System.Drawing.Size(128, 22);
            this.tsbTruncate.Text = "Clear Data";
            this.tsbTruncate.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbGenerate
            // 
            this.tsbGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGenerate.Enabled = false;
            this.tsbGenerate.Image = global::InFresh.Master.Properties.Resources.ic_setting;
            this.tsbGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGenerate.Name = "tsbGenerate";
            this.tsbGenerate.Size = new System.Drawing.Size(23, 22);
            this.tsbGenerate.Text = "Generate Code";
            this.tsbGenerate.ToolTipText = "Generate Suggest Code";
            this.tsbGenerate.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tslRecord
            // 
            this.tslRecord.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslRecord.Name = "tslRecord";
            this.tslRecord.Size = new System.Drawing.Size(79, 22);
            this.tslRecord.Text = "Record: 0 of 0";
            // 
            // tsbLast
            // 
            this.tsbLast.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLast.Enabled = false;
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(23, 22);
            this.tsbLast.Text = "Last";
            this.tsbLast.ToolTipText = "Last Record (Ctrl + Arrow Down)";
            this.tsbLast.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Enabled = false;
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(23, 22);
            this.tsbNext.Text = "Next";
            this.tsbNext.ToolTipText = "Next Record (Ctrl + Arrow Right)";
            this.tsbNext.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tsbPrevious
            // 
            this.tsbPrevious.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrevious.Enabled = false;
            this.tsbPrevious.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrevious.Image")));
            this.tsbPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrevious.Name = "tsbPrevious";
            this.tsbPrevious.Size = new System.Drawing.Size(23, 22);
            this.tsbPrevious.Text = "Previous";
            this.tsbPrevious.ToolTipText = "Previous Record (Ctrl + Arrow Left)";
            this.tsbPrevious.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // tsbFirst
            // 
            this.tsbFirst.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFirst.Enabled = false;
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(23, 22);
            this.tsbFirst.Text = "First";
            this.tsbFirst.ToolTipText = "First Record (Ctrl + Arrow Up)";
            this.tsbFirst.Click += new System.EventHandler(this.ToolbarItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 114;
            this.label5.Text = "Telephone";
            // 
            // txtOldCode
            // 
            this.txtOldCode.Location = new System.Drawing.Point(97, 54);
            this.txtOldCode.Name = "txtOldCode";
            this.txtOldCode.ReadOnly = true;
            this.txtOldCode.Size = new System.Drawing.Size(142, 20);
            this.txtOldCode.TabIndex = 99;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(464, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 117;
            this.label9.Text = "Fax";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 122;
            this.label11.Text = "Old Code";
            // 
            // txtFax1
            // 
            this.txtFax1.Location = new System.Drawing.Point(554, 106);
            this.txtFax1.Mask = "###############";
            this.txtFax1.Name = "txtFax1";
            this.txtFax1.ReadOnly = true;
            this.txtFax1.Size = new System.Drawing.Size(270, 20);
            this.txtFax1.TabIndex = 108;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(245, 31);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(122, 13);
            this.lblInfo.TabIndex = 121;
            this.lblInfo.Text = "(Generate Automatically)";
            this.lblInfo.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 120;
            this.label10.Text = "Status";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Enabled = false;
            this.chkStatus.Location = new System.Drawing.Point(554, 158);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(56, 17);
            this.chkStatus.TabIndex = 110;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(97, 158);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(270, 20);
            this.txtCity.TabIndex = 104;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 119;
            this.label6.Text = "Zip Code";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(554, 28);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.ReadOnly = true;
            this.txtZipCode.Size = new System.Drawing.Size(80, 20);
            this.txtZipCode.TabIndex = 105;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 118;
            this.label8.Text = "City";
            // 
            // lnkEmail
            // 
            this.lnkEmail.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkEmail.AutoSize = true;
            this.lnkEmail.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lnkEmail.Location = new System.Drawing.Point(555, 135);
            this.lnkEmail.Name = "lnkEmail";
            this.lnkEmail.Size = new System.Drawing.Size(0, 13);
            this.lnkEmail.TabIndex = 103;
            this.lnkEmail.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            // 
            // txtAddr2
            // 
            this.txtAddr2.Location = new System.Drawing.Point(97, 132);
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.ReadOnly = true;
            this.txtAddr2.Size = new System.Drawing.Size(270, 20);
            this.txtAddr2.TabIndex = 102;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(464, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 116;
            this.label7.Text = "Email Address";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(554, 54);
            this.txtContact.Name = "txtContact";
            this.txtContact.ReadOnly = true;
            this.txtContact.Size = new System.Drawing.Size(270, 20);
            this.txtContact.TabIndex = 106;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 115;
            this.label4.Text = "Contact Person";
            // 
            // txtAddr1
            // 
            this.txtAddr1.Location = new System.Drawing.Point(97, 106);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.ReadOnly = true;
            this.txtAddr1.Size = new System.Drawing.Size(270, 20);
            this.txtAddr1.TabIndex = 101;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(97, 80);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(270, 20);
            this.txtName.TabIndex = 100;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(97, 28);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(142, 20);
            this.txtCode.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 113;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Supplier Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 111;
            this.label1.Text = "Supplier Code";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(554, 132);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(270, 20);
            this.txtEmail.TabIndex = 109;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(554, 80);
            this.txtPhone1.Mask = "###############";
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.ReadOnly = true;
            this.txtPhone1.Size = new System.Drawing.Size(270, 20);
            this.txtPhone1.TabIndex = 107;
            // 
            // stsStatusbar
            // 
            this.stsStatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsxStatus,
            this.stxGap,
            this.tspProgress});
            this.stsStatusbar.Location = new System.Drawing.Point(0, 484);
            this.stsStatusbar.Name = "stsStatusbar";
            this.stsStatusbar.Size = new System.Drawing.Size(834, 22);
            this.stsStatusbar.SizingGrip = false;
            this.stsStatusbar.TabIndex = 123;
            this.stsStatusbar.Text = "statusStrip1";
            // 
            // tsxStatus
            // 
            this.tsxStatus.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.tsxStatus.MergeIndex = 0;
            this.tsxStatus.Name = "tsxStatus";
            this.tsxStatus.Size = new System.Drawing.Size(819, 17);
            this.tsxStatus.Spring = true;
            this.tsxStatus.Text = "Ready";
            this.tsxStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stxGap
            // 
            this.stxGap.Name = "stxGap";
            this.stxGap.Size = new System.Drawing.Size(0, 17);
            // 
            // tspProgress
            // 
            this.tspProgress.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.tspProgress.MergeIndex = 2;
            this.tspProgress.Name = "tspProgress";
            this.tspProgress.Size = new System.Drawing.Size(100, 16);
            this.tspProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tspProgress.Visible = false;
            // 
            // bgwWorker
            // 
            this.bgwWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.bgwWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.bgwWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // leftTabControl1
            // 
            this.leftTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.leftTabControl1.Controls.Add(this.tabPage1);
            this.leftTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.leftTabControl1.ItemSize = new System.Drawing.Size(30, 130);
            this.leftTabControl1.Location = new System.Drawing.Point(12, 184);
            this.leftTabControl1.Multiline = true;
            this.leftTabControl1.Name = "leftTabControl1";
            this.leftTabControl1.SelectedIndex = 0;
            this.leftTabControl1.Size = new System.Drawing.Size(812, 296);
            this.leftTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.leftTabControl1.TabIndex = 124;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(134, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(674, 288);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Outlet Covered";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MP003_SupplierPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 506);
            this.Controls.Add(this.leftTabControl1);
            this.Controls.Add(this.stsStatusbar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOldCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtFax1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lnkEmail);
            this.Controls.Add(this.txtAddr2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddr1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone1);
            this.Controls.Add(this.tlsToolbar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 545);
            this.Name = "MP003_SupplierPage";
            this.Text = "MP003_ListSupplierPage";
            this.DockStateChanged += new System.EventHandler(this.Form_DockStateChanged);
            this.Activated += new System.EventHandler(this.Form_Activated);
            this.Deactivate += new System.EventHandler(this.Form_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.tlsToolbar.ResumeLayout(false);
            this.tlsToolbar.PerformLayout();
            this.stsStatusbar.ResumeLayout(false);
            this.stsStatusbar.PerformLayout();
            this.leftTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsToolbar;
        private System.Windows.Forms.ToolStripButton tsbList;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSplitButton tsbCancel;
        private System.Windows.Forms.ToolStripMenuItem tsbDelete;
        private System.Windows.Forms.ToolStripMenuItem tsbTruncate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbGenerate;
        private System.Windows.Forms.ToolStripLabel tslRecord;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbPrevious;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOldCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtFax1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel lnkEmail;
        private System.Windows.Forms.TextBox txtAddr2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddr1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MaskedTextBox txtPhone1;
        private System.Windows.Forms.StatusStrip stsStatusbar;
        private System.Windows.Forms.ToolStripStatusLabel tsxStatus;
        private System.Windows.Forms.ToolStripStatusLabel stxGap;
        private System.Windows.Forms.ToolStripProgressBar tspProgress;
        private InFresh.Controls.v1.LeftTabControl leftTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.ComponentModel.BackgroundWorker bgwWorker;
    }
}