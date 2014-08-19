using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InFresh.Driver.v1.Forms
{
    public partial class Z0003_AboutWindow : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Z0003_AboutWindow()
        {
            InitializeComponent();

            Text = string.Format(Program.Handler.Resources.GetString("About"), 
                string.Format(Program.Handler.Resources.GetString("App_Name"), string.Empty))
                .Replace("&",string.Empty);

            lblApplication.Text = string.Format(Program.Handler.Resources.GetString("App_Name"), string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="hlpevent"></param>
        private void Form_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }
    }
}
