using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InFresh.Master.v1.Controls
{
    public partial class MasterMenu : MenuStrip
    {
        public MasterMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello Menu " + (sender as ToolStripMenuItem).Text.Replace("&", string.Empty));
            //if (sender == tsmiSubdepo)
            //{
            //    MessageBox.Show("Hello Menu Master Subdepo");
            //    return;
            //}
        }
    }
}
