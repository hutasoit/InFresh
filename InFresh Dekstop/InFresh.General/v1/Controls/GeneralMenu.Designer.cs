namespace InFresh.General.v1.Controls
{
    partial class GeneralMenu
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
            this.tsmiAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdministrative = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalesArea = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            // 
            // tsmiFile
            // 
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 35);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiGeneral
            // 
            this.tsmiGeneral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdministrative,
            this.tsmiSalesArea});
            this.tsmiGeneral.Name = "tsmiGeneral";
            this.tsmiGeneral.Size = new System.Drawing.Size(86, 35);
            this.tsmiGeneral.Text = "&General Data";
            // 
            // tsmiAdministration
            // 
            this.tsmiAdministration.Name = "tsmiAdministration";
            this.tsmiAdministration.Size = new System.Drawing.Size(98, 35);
            this.tsmiAdministration.Text = "&Administration";
            // 
            // tsmiTools
            // 
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Size = new System.Drawing.Size(48, 35);
            this.tsmiTools.Text = "&Tools";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 35);
            this.tsmiHelp.Text = "&Help";
            // 
            // tsmiAdministrative
            // 
            this.tsmiAdministrative.Name = "tsmiAdministrative";
            this.tsmiAdministrative.Size = new System.Drawing.Size(178, 22);
            this.tsmiAdministrative.Text = "&Administrative Area";
            this.tsmiAdministrative.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tsmiSalesArea
            // 
            this.tsmiSalesArea.Name = "tsmiSalesArea";
            this.tsmiSalesArea.Size = new System.Drawing.Size(178, 22);
            this.tsmiSalesArea.Text = "&Sales Area";
            this.tsmiSalesArea.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // GeneralMenu
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiGeneral,
            this.tsmiAdministration,
            this.tsmiTools,
            this.tsmiHelp});
            this.Size = new System.Drawing.Size(700, 39);
            this.Click += new System.EventHandler(this.MenuItem_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiGeneral;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdministration;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdministrative;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalesArea;
    }
}
