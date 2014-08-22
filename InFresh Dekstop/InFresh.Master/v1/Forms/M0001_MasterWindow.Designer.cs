namespace InFresh.Master.v1.Forms
{
    partial class M0001_MasterWindow
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
            this.tlsToolbar = new System.Windows.Forms.ToolStrip();
            this.stsStatusbar = new System.Windows.Forms.StatusStrip();
            this.mnsMenubar = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSubdepo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOutlet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMenubar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsToolbar
            // 
            this.tlsToolbar.CanOverflow = false;
            this.tlsToolbar.Location = new System.Drawing.Point(0, 24);
            this.tlsToolbar.Name = "tlsToolbar";
            this.tlsToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tlsToolbar.Size = new System.Drawing.Size(696, 25);
            this.tlsToolbar.TabIndex = 19;
            this.tlsToolbar.Text = "toolStrip1";
            // 
            // stsStatusbar
            // 
            this.stsStatusbar.Location = new System.Drawing.Point(0, 239);
            this.stsStatusbar.Name = "stsStatusbar";
            this.stsStatusbar.Size = new System.Drawing.Size(696, 22);
            this.stsStatusbar.SizingGrip = false;
            this.stsStatusbar.TabIndex = 18;
            this.stsStatusbar.Text = "statusStrip1";
            // 
            // mnsMenubar
            // 
            this.mnsMenubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiGeneral,
            this.tsmiMaster,
            this.tsmiAdministration,
            this.tsmiTools,
            this.tsmiHelp});
            this.mnsMenubar.Location = new System.Drawing.Point(0, 0);
            this.mnsMenubar.Name = "mnsMenubar";
            this.mnsMenubar.Size = new System.Drawing.Size(696, 24);
            this.mnsMenubar.TabIndex = 17;
            this.mnsMenubar.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiGeneral
            // 
            this.tsmiGeneral.Name = "tsmiGeneral";
            this.tsmiGeneral.Size = new System.Drawing.Size(86, 20);
            this.tsmiGeneral.Text = "&General Data";
            // 
            // tsmiMaster
            // 
            this.tsmiMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSubdepo,
            this.tsmiEmployee,
            this.toolStripSeparator2,
            this.tsmiSupplier,
            this.tsmiOutlet});
            this.tsmiMaster.Name = "tsmiMaster";
            this.tsmiMaster.Size = new System.Drawing.Size(82, 20);
            this.tsmiMaster.Text = "&Master Data";
            // 
            // tsmiSubdepo
            // 
            this.tsmiSubdepo.Name = "tsmiSubdepo";
            this.tsmiSubdepo.Size = new System.Drawing.Size(165, 22);
            this.tsmiSubdepo.Text = "Master &Subdepo";
            // 
            // tsmiEmployee
            // 
            this.tsmiEmployee.Name = "tsmiEmployee";
            this.tsmiEmployee.Size = new System.Drawing.Size(165, 22);
            this.tsmiEmployee.Text = "Master &Employee";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmiSupplier
            // 
            this.tsmiSupplier.Name = "tsmiSupplier";
            this.tsmiSupplier.Size = new System.Drawing.Size(165, 22);
            this.tsmiSupplier.Text = "Master Su&pplier";
            // 
            // tsmiOutlet
            // 
            this.tsmiOutlet.Name = "tsmiOutlet";
            this.tsmiOutlet.Size = new System.Drawing.Size(165, 22);
            this.tsmiOutlet.Text = "Master &Outlet";
            // 
            // tsmiAdministration
            // 
            this.tsmiAdministration.Name = "tsmiAdministration";
            this.tsmiAdministration.Size = new System.Drawing.Size(98, 20);
            this.tsmiAdministration.Text = "&Administration";
            // 
            // tsmiTools
            // 
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Size = new System.Drawing.Size(48, 20);
            this.tsmiTools.Text = "&Tools";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "&Help";
            // 
            // M0001_MasterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 261);
            this.Controls.Add(this.tlsToolbar);
            this.Controls.Add(this.stsStatusbar);
            this.Controls.Add(this.mnsMenubar);
            this.Name = "M0001_MasterWindow";
            this.Text = "M0001_MasterWindow";
            this.mnsMenubar.ResumeLayout(false);
            this.mnsMenubar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip tlsToolbar;
        public System.Windows.Forms.StatusStrip stsStatusbar;
        public System.Windows.Forms.MenuStrip mnsMenubar;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiGeneral;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaster;
        private System.Windows.Forms.ToolStripMenuItem tsmiSubdepo;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSupplier;
        private System.Windows.Forms.ToolStripMenuItem tsmiOutlet;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdministration;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
    }
}