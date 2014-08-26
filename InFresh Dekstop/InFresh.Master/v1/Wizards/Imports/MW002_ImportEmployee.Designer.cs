namespace InFresh.Master.v1.Wizards.Imports
{
    partial class MW002_ImportEmployee
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
            this.chkFirstHeader = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.stsStatusbar = new System.Windows.Forms.StatusStrip();
            this.tsxStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ofpFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.cmbSheet = new System.Windows.Forms.ComboBox();
            this.bgwWorker = new System.ComponentModel.BackgroundWorker();
            this.pnlField = new System.Windows.Forms.Panel();
            this.crlFieldLoading = new InFresh.Controls.v1.CircleLoading();
            this.cmbEmailField = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPhone2Field = new System.Windows.Forms.ComboBox();
            this.cmbPhone1Field = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkCode = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOldCodeField = new System.Windows.Forms.ComboBox();
            this.cmbZipCodeField = new System.Windows.Forms.ComboBox();
            this.cmbCityField = new System.Windows.Forms.ComboBox();
            this.cmbAdd2Field = new System.Windows.Forms.ComboBox();
            this.cmbAdd1Field = new System.Windows.Forms.ComboBox();
            this.cmbNameField = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnShowData = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.crlDataLoadinging = new InFresh.Controls.v1.CircleLoading();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dtxCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgxOlCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxAddr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxPhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxPhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxEmail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stsStatusbar.SuspendLayout();
            this.pnlField.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // chkFirstHeader
            // 
            this.chkFirstHeader.AutoSize = true;
            this.chkFirstHeader.Checked = true;
            this.chkFirstHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirstHeader.Enabled = false;
            this.chkFirstHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkFirstHeader.Location = new System.Drawing.Point(318, 31);
            this.chkFirstHeader.Name = "chkFirstHeader";
            this.chkFirstHeader.Size = new System.Drawing.Size(135, 17);
            this.chkFirstHeader.TabIndex = 78;
            this.chkFirstHeader.Text = "First Column as Header";
            this.chkFirstHeader.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(13, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "Imported File";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(104, 3);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(356, 20);
            this.txtFilename.TabIndex = 75;
            // 
            // stsStatusbar
            // 
            this.stsStatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsxStatus,
            this.toolStripStatusLabel2,
            this.tspProgress});
            this.stsStatusbar.Location = new System.Drawing.Point(0, 439);
            this.stsStatusbar.Name = "stsStatusbar";
            this.stsStatusbar.Size = new System.Drawing.Size(854, 22);
            this.stsStatusbar.SizingGrip = false;
            this.stsStatusbar.TabIndex = 85;
            // 
            // tsxStatus
            // 
            this.tsxStatus.Name = "tsxStatus";
            this.tsxStatus.Size = new System.Drawing.Size(39, 17);
            this.tsxStatus.Text = "Ready";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(800, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // tspProgress
            // 
            this.tspProgress.Name = "tspProgress";
            this.tspProgress.Size = new System.Drawing.Size(100, 16);
            this.tspProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tspProgress.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(768, 413);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 82;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.ButtonItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(13, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Sheet (excel file)";
            // 
            // ofpFileDialog
            // 
            this.ofpFileDialog.Filter = "Microsoft Excel files 2010-2013|*.xlsx|Microsoft Excel 2003-2007|*.xls|CSV format" +
    "ed files|*.csv";
            this.ofpFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Select template";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.Enabled = false;
            this.cmbTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(104, 56);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(208, 21);
            this.cmbTemplate.TabIndex = 80;
            this.cmbTemplate.SelectedIndexChanged += new System.EventHandler(this.ComboItem_SelectedIndexChanged);
            // 
            // cmbSheet
            // 
            this.cmbSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSheet.Enabled = false;
            this.cmbSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSheet.FormattingEnabled = true;
            this.cmbSheet.Location = new System.Drawing.Point(104, 29);
            this.cmbSheet.Name = "cmbSheet";
            this.cmbSheet.Size = new System.Drawing.Size(208, 21);
            this.cmbSheet.TabIndex = 77;
            this.cmbSheet.SelectedIndexChanged += new System.EventHandler(this.ComboItem_SelectedIndexChanged);
            // 
            // bgwWorker
            // 
            this.bgwWorker.WorkerReportsProgress = true;
            this.bgwWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.bgwWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.bgwWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // pnlField
            // 
            this.pnlField.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlField.Controls.Add(this.crlFieldLoading);
            this.pnlField.Controls.Add(this.cmbEmailField);
            this.pnlField.Controls.Add(this.label8);
            this.pnlField.Controls.Add(this.cmbPhone2Field);
            this.pnlField.Controls.Add(this.cmbPhone1Field);
            this.pnlField.Controls.Add(this.label12);
            this.pnlField.Controls.Add(this.label11);
            this.pnlField.Controls.Add(this.chkCode);
            this.pnlField.Controls.Add(this.label2);
            this.pnlField.Controls.Add(this.cmbOldCodeField);
            this.pnlField.Controls.Add(this.cmbZipCodeField);
            this.pnlField.Controls.Add(this.cmbCityField);
            this.pnlField.Controls.Add(this.cmbAdd2Field);
            this.pnlField.Controls.Add(this.cmbAdd1Field);
            this.pnlField.Controls.Add(this.cmbNameField);
            this.pnlField.Controls.Add(this.label5);
            this.pnlField.Controls.Add(this.label10);
            this.pnlField.Controls.Add(this.label9);
            this.pnlField.Controls.Add(this.label7);
            this.pnlField.Controls.Add(this.label6);
            this.pnlField.Enabled = false;
            this.pnlField.Location = new System.Drawing.Point(12, 83);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(300, 353);
            this.pnlField.TabIndex = 83;
            // 
            // crlFieldLoading
            // 
            this.crlFieldLoading.Active = true;
            this.crlFieldLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crlFieldLoading.BackColor = System.Drawing.Color.Transparent;
            this.crlFieldLoading.Color = System.Drawing.Color.DarkGray;
            this.crlFieldLoading.InnerCircleRadius = 5;
            this.crlFieldLoading.Location = new System.Drawing.Point(112, 164);
            this.crlFieldLoading.Name = "crlFieldLoading";
            this.crlFieldLoading.NumberSpoke = 12;
            this.crlFieldLoading.OuterCircleRadius = 11;
            this.crlFieldLoading.RotationSpeed = 100;
            this.crlFieldLoading.Size = new System.Drawing.Size(75, 23);
            this.crlFieldLoading.SpokeThickness = 2;
            this.crlFieldLoading.StylePreset = InFresh.Controls.v1.CircleLoading.StylePresets.MacOSX;
            this.crlFieldLoading.TabIndex = 58;
            this.crlFieldLoading.Text = "Loading...";
            this.crlFieldLoading.Visible = false;
            // 
            // cmbEmailField
            // 
            this.cmbEmailField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmailField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmailField.FormattingEnabled = true;
            this.cmbEmailField.Location = new System.Drawing.Point(91, 270);
            this.cmbEmailField.Name = "cmbEmailField";
            this.cmbEmailField.Size = new System.Drawing.Size(204, 21);
            this.cmbEmailField.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "Email";
            // 
            // cmbPhone2Field
            // 
            this.cmbPhone2Field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhone2Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPhone2Field.FormattingEnabled = true;
            this.cmbPhone2Field.Location = new System.Drawing.Point(92, 243);
            this.cmbPhone2Field.Name = "cmbPhone2Field";
            this.cmbPhone2Field.Size = new System.Drawing.Size(203, 21);
            this.cmbPhone2Field.TabIndex = 47;
            // 
            // cmbPhone1Field
            // 
            this.cmbPhone1Field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhone1Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPhone1Field.FormattingEnabled = true;
            this.cmbPhone1Field.Location = new System.Drawing.Point(92, 213);
            this.cmbPhone1Field.Name = "cmbPhone1Field";
            this.cmbPhone1Field.Size = new System.Drawing.Size(203, 21);
            this.cmbPhone1Field.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 246);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Handphone";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Telephone";
            // 
            // chkCode
            // 
            this.chkCode.AutoSize = true;
            this.chkCode.Checked = true;
            this.chkCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCode.Enabled = false;
            this.chkCode.Location = new System.Drawing.Point(92, 12);
            this.chkCode.Name = "chkCode";
            this.chkCode.Size = new System.Drawing.Size(177, 17);
            this.chkCode.TabIndex = 31;
            this.chkCode.Text = "Auto Generated (recommended)";
            this.chkCode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Old Code";
            // 
            // cmbOldCodeField
            // 
            this.cmbOldCodeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOldCodeField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOldCodeField.FormattingEnabled = true;
            this.cmbOldCodeField.Location = new System.Drawing.Point(92, 40);
            this.cmbOldCodeField.Name = "cmbOldCodeField";
            this.cmbOldCodeField.Size = new System.Drawing.Size(203, 21);
            this.cmbOldCodeField.TabIndex = 32;
            // 
            // cmbZipCodeField
            // 
            this.cmbZipCodeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZipCodeField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbZipCodeField.FormattingEnabled = true;
            this.cmbZipCodeField.Location = new System.Drawing.Point(92, 186);
            this.cmbZipCodeField.Name = "cmbZipCodeField";
            this.cmbZipCodeField.Size = new System.Drawing.Size(203, 21);
            this.cmbZipCodeField.TabIndex = 42;
            // 
            // cmbCityField
            // 
            this.cmbCityField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCityField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCityField.FormattingEnabled = true;
            this.cmbCityField.Location = new System.Drawing.Point(92, 157);
            this.cmbCityField.Name = "cmbCityField";
            this.cmbCityField.Size = new System.Drawing.Size(203, 21);
            this.cmbCityField.TabIndex = 40;
            // 
            // cmbAdd2Field
            // 
            this.cmbAdd2Field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdd2Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAdd2Field.FormattingEnabled = true;
            this.cmbAdd2Field.Location = new System.Drawing.Point(92, 128);
            this.cmbAdd2Field.Name = "cmbAdd2Field";
            this.cmbAdd2Field.Size = new System.Drawing.Size(203, 21);
            this.cmbAdd2Field.TabIndex = 38;
            // 
            // cmbAdd1Field
            // 
            this.cmbAdd1Field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdd1Field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAdd1Field.FormattingEnabled = true;
            this.cmbAdd1Field.Location = new System.Drawing.Point(92, 99);
            this.cmbAdd1Field.Name = "cmbAdd1Field";
            this.cmbAdd1Field.Size = new System.Drawing.Size(203, 21);
            this.cmbAdd1Field.TabIndex = 37;
            // 
            // cmbNameField
            // 
            this.cmbNameField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNameField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNameField.FormattingEnabled = true;
            this.cmbNameField.Location = new System.Drawing.Point(92, 70);
            this.cmbNameField.Name = "cmbNameField";
            this.cmbNameField.Size = new System.Drawing.Size(203, 21);
            this.cmbNameField.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Employee Code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Zip Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "City";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Employee Name";
            // 
            // btnShowData
            // 
            this.btnShowData.Enabled = false;
            this.btnShowData.Location = new System.Drawing.Point(318, 413);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(75, 23);
            this.btnShowData.TabIndex = 81;
            this.btnShowData.Text = "Show Data";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.ButtonItem_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowse.Location = new System.Drawing.Point(466, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(74, 23);
            this.btnBrowse.TabIndex = 76;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.ButtonItem_Click);
            // 
            // pnlData
            // 
            this.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlData.Controls.Add(this.crlDataLoadinging);
            this.pnlData.Controls.Add(this.dgvData);
            this.pnlData.Enabled = false;
            this.pnlData.Location = new System.Drawing.Point(319, 83);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(524, 324);
            this.pnlData.TabIndex = 84;
            // 
            // crlDataLoadinging
            // 
            this.crlDataLoadinging.Active = true;
            this.crlDataLoadinging.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crlDataLoadinging.BackColor = System.Drawing.Color.White;
            this.crlDataLoadinging.Color = System.Drawing.Color.DarkGray;
            this.crlDataLoadinging.InnerCircleRadius = 5;
            this.crlDataLoadinging.Location = new System.Drawing.Point(224, 150);
            this.crlDataLoadinging.Name = "crlDataLoadinging";
            this.crlDataLoadinging.NumberSpoke = 12;
            this.crlDataLoadinging.OuterCircleRadius = 11;
            this.crlDataLoadinging.RotationSpeed = 100;
            this.crlDataLoadinging.Size = new System.Drawing.Size(75, 23);
            this.crlDataLoadinging.SpokeThickness = 2;
            this.crlDataLoadinging.StylePreset = InFresh.Controls.v1.CircleLoading.StylePresets.MacOSX;
            this.crlDataLoadinging.TabIndex = 51;
            this.crlDataLoadinging.Text = "Loading...";
            this.crlDataLoadinging.Visible = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtxCode,
            this.dgxOlCode,
            this.dtxName,
            this.dtxAddr1,
            this.dtxPhone1,
            this.dtxPhone2,
            this.dtxEmail,
            this.Column1});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(522, 322);
            this.dgvData.StandardTab = true;
            this.dgvData.TabIndex = 33;
            // 
            // dtxCode
            // 
            this.dtxCode.DataPropertyName = "Code";
            this.dtxCode.HeaderText = "Employee Code";
            this.dtxCode.Name = "dtxCode";
            this.dtxCode.Width = 150;
            // 
            // dgxOlCode
            // 
            this.dgxOlCode.DataPropertyName = "OldCode";
            this.dgxOlCode.HeaderText = "Old Code";
            this.dgxOlCode.Name = "dgxOlCode";
            // 
            // dtxName
            // 
            this.dtxName.DataPropertyName = "Name";
            this.dtxName.HeaderText = "Employee Name";
            this.dtxName.Name = "dtxName";
            this.dtxName.Width = 150;
            // 
            // dtxAddr1
            // 
            this.dtxAddr1.DataPropertyName = "Address1";
            this.dtxAddr1.HeaderText = "Address";
            this.dtxAddr1.Name = "dtxAddr1";
            this.dtxAddr1.Width = 200;
            // 
            // dtxPhone1
            // 
            this.dtxPhone1.DataPropertyName = "Phone1";
            this.dtxPhone1.HeaderText = "Telephone";
            this.dtxPhone1.Name = "dtxPhone1";
            // 
            // dtxPhone2
            // 
            this.dtxPhone2.DataPropertyName = "Phone2";
            this.dtxPhone2.HeaderText = "Handphone";
            this.dtxPhone2.Name = "dtxPhone2";
            // 
            // dtxEmail
            // 
            this.dtxEmail.DataPropertyName = "Email";
            this.dtxEmail.HeaderText = "Email";
            this.dtxEmail.Name = "dtxEmail";
            this.dtxEmail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtxEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            // 
            // MW002_ImportEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 461);
            this.Controls.Add(this.chkFirstHeader);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.stsStatusbar);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTemplate);
            this.Controls.Add(this.cmbSheet);
            this.Controls.Add(this.pnlField);
            this.Controls.Add(this.btnShowData);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.pnlData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(870, 500);
            this.Name = "MW002_ImportEmployee";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Data Employee";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.stsStatusbar.ResumeLayout(false);
            this.stsStatusbar.PerformLayout();
            this.pnlField.ResumeLayout(false);
            this.pnlField.PerformLayout();
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox chkFirstHeader;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.StatusStrip stsStatusbar;
        private System.Windows.Forms.ToolStripStatusLabel tsxStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar tspProgress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog ofpFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.ComboBox cmbSheet;
        private System.ComponentModel.BackgroundWorker bgwWorker;
        private System.Windows.Forms.Panel pnlField;
        private InFresh.Controls.v1.CircleLoading crlFieldLoading;
        private System.Windows.Forms.ComboBox cmbEmailField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPhone2Field;
        private System.Windows.Forms.ComboBox cmbPhone1Field;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOldCodeField;
        private System.Windows.Forms.ComboBox cmbZipCodeField;
        private System.Windows.Forms.ComboBox cmbCityField;
        private System.Windows.Forms.ComboBox cmbAdd2Field;
        private System.Windows.Forms.ComboBox cmbAdd1Field;
        private System.Windows.Forms.ComboBox cmbNameField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnShowData;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel pnlData;
        private InFresh.Controls.v1.CircleLoading crlDataLoadinging;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgxOlCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxAddr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxPhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxPhone2;
        private System.Windows.Forms.DataGridViewLinkColumn dtxEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

    }
}