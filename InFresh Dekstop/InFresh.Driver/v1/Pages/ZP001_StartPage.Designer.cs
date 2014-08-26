namespace InFresh.Driver.v1.Pages
{
    partial class ZP001_StartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZP001_StartPage));
            this.stsStatusbar = new System.Windows.Forms.StatusStrip();
            this.stxStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stxGap = new System.Windows.Forms.ToolStripStatusLabel();
            this.stpProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkExport = new System.Windows.Forms.LinkLabel();
            this.lnkImport = new System.Windows.Forms.LinkLabel();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblApplication = new System.Windows.Forms.Label();
            this.stsStatusbar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsStatusbar
            // 
            this.stsStatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stxStatus,
            this.stxGap,
            this.stpProgress});
            this.stsStatusbar.Location = new System.Drawing.Point(0, 539);
            this.stsStatusbar.Name = "stsStatusbar";
            this.stsStatusbar.Size = new System.Drawing.Size(884, 22);
            this.stsStatusbar.SizingGrip = false;
            this.stsStatusbar.TabIndex = 5;
            this.stsStatusbar.Text = "statusStrip1";
            // 
            // stxStatus
            // 
            this.stxStatus.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.stxStatus.MergeIndex = 0;
            this.stxStatus.Name = "stxStatus";
            this.stxStatus.Size = new System.Drawing.Size(736, 17);
            this.stxStatus.Spring = true;
            this.stxStatus.Text = "Ready";
            this.stxStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stxGap
            // 
            this.stxGap.Name = "stxGap";
            this.stxGap.Size = new System.Drawing.Size(0, 17);
            // 
            // stpProgress
            // 
            this.stpProgress.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.stpProgress.MergeIndex = 2;
            this.stpProgress.Name = "stpProgress";
            this.stpProgress.Size = new System.Drawing.Size(100, 16);
            this.stpProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.stpProgress.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 539);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lnkExport);
            this.panel2.Controls.Add(this.lnkImport);
            this.panel2.Controls.Add(this.lnkNew);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblApplication);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 539);
            this.panel2.TabIndex = 0;
            // 
            // lnkExport
            // 
            this.lnkExport.ActiveLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.lnkExport.AutoSize = true;
            this.lnkExport.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkExport.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkExport.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.lnkExport.Location = new System.Drawing.Point(12, 182);
            this.lnkExport.Name = "lnkExport";
            this.lnkExport.Size = new System.Drawing.Size(121, 17);
            this.lnkExport.TabIndex = 5;
            this.lnkExport.TabStop = true;
            this.lnkExport.Text = "Export Data To File...";
            this.lnkExport.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            // 
            // lnkImport
            // 
            this.lnkImport.ActiveLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.lnkImport.AutoSize = true;
            this.lnkImport.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkImport.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkImport.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.lnkImport.Location = new System.Drawing.Point(12, 163);
            this.lnkImport.Name = "lnkImport";
            this.lnkImport.Size = new System.Drawing.Size(137, 17);
            this.lnkImport.TabIndex = 4;
            this.lnkImport.TabStop = true;
            this.lnkImport.Text = "Import Data From File...";
            this.lnkImport.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            // 
            // lnkNew
            // 
            this.lnkNew.ActiveLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.lnkNew.AutoSize = true;
            this.lnkNew.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkNew.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkNew.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.lnkNew.Location = new System.Drawing.Point(12, 144);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(71, 17);
            this.lnkNew.TabIndex = 3;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "New Data...";
            this.lnkNew.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(12, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start";
            // 
            // lblApplication
            // 
            this.lblApplication.AutoSize = true;
            this.lblApplication.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplication.Location = new System.Drawing.Point(12, 19);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Size = new System.Drawing.Size(86, 32);
            this.lblApplication.TabIndex = 0;
            this.lblApplication.Text = "InFresh";
            // 
            // ZP001_StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stsStatusbar);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "ZP001_StartPage";
            this.Text = "P001_StartPage";
            this.DockStateChanged += new System.EventHandler(this.Form_DockStateChanged);
            this.Activated += new System.EventHandler(this.Form_Activated);
            this.Deactivate += new System.EventHandler(this.Form_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Closing);
            this.stsStatusbar.ResumeLayout(false);
            this.stsStatusbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStatusbar;
        private System.Windows.Forms.ToolStripStatusLabel stxStatus;
        private System.Windows.Forms.ToolStripStatusLabel stxGap;
        private System.Windows.Forms.ToolStripProgressBar stpProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lnkExport;
        private System.Windows.Forms.LinkLabel lnkImport;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblApplication;
    }
}