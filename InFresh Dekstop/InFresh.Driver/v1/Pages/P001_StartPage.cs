using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Interfaces;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.Driver.v1.Pages
{
    public partial class P001_StartPage : DockContent, IDock 
    {
        /// <summary>
        /// 
        /// </summary>
        public P001_StartPage()
        {
            InitializeComponent();

            Text = TabText = string.Format(Program.Handler.Resources.GetString("App_Name"),string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        public DockState State
        {
            get { return DockState.Document; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Activated(object sender, EventArgs e)
        {
            Program.Handler.Host.MergeStatusbar(stsStatusbar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Deactivate(object sender, EventArgs e)
        {
            Program.Handler.Host.ReverseStatusbar(stsStatusbar);
        }
    }
}
