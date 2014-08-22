namespace InFresh.Master.v1.Controls
{
    partial class MasterMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSubdepo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOutlet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SuspendLayout();
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
            this.toolStripSeparator1,
            this.tsmiSupplier,
            this.tsmiOutlet});
            this.tsmiMaster.Name = "tsmiMaster";
            this.tsmiMaster.Size = new System.Drawing.Size(82, 20);
            this.tsmiMaster.Text = "&Master Data";
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
            // tsmiSubdepo
            // 
            this.tsmiSubdepo.Name = "tsmiSubdepo";
            this.tsmiSubdepo.Size = new System.Drawing.Size(181, 22);
            this.tsmiSubdepo.Text = "Master &Subdepo";
            this.tsmiSubdepo.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmiSupplier
            // 
            this.tsmiSupplier.Name = "tsmiSupplier";
            this.tsmiSupplier.Size = new System.Drawing.Size(181, 22);
            this.tsmiSupplier.Text = "Master Su&pplier";
            this.tsmiSupplier.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmiOutlet
            // 
            this.tsmiOutlet.Name = "tsmiOutlet";
            this.tsmiOutlet.Size = new System.Drawing.Size(181, 22);
            this.tsmiOutlet.Text = "Master &Outlet";
            this.tsmiOutlet.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmiEmployee
            // 
            this.tsmiEmployee.Name = "tsmiEmployee";
            this.tsmiEmployee.Size = new System.Drawing.Size(165, 22);
            this.tsmiEmployee.Text = "Master &Employee";
            this.tsmiEmployee.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // MasterMenu
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiGeneral,
            this.tsmiMaster,
            this.tsmiAdministration,
            this.tsmiTools,
            this.tsmiHelp});
            this.Click += new System.EventHandler(this.MenuItem_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiGeneral;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaster;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdministration;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiSubdepo;
        private System.Windows.Forms.ToolStripMenuItem tsmiSupplier;
        private System.Windows.Forms.ToolStripMenuItem tsmiOutlet;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
