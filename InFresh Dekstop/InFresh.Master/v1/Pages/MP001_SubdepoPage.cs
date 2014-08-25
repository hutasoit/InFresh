using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Interfaces;
using InFresh.Master.v1.Implements;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.Master.v1.Pages
{
    public partial class MP001_SubdepoPage : DockContent, IDock
    {
        public MP001_SubdepoPage()
        {
            InitializeComponent();

            Text = TabText = MasterModule.Handler.Resources.GetString("Subdepo").Replace("&", string.Empty);
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
        private void Form_DockStateChanged(object sender, EventArgs e)
        {
            if (DockState == DockState.Float)
            {
                Size = new Size(900, 600);

                var topLeft = DockPanel.Location;
                topLeft.X = ((Screen.PrimaryScreen.Bounds.Width / 2) - (Size.Width / 2));
                topLeft.Y = ((Screen.PrimaryScreen.Bounds.Height / 2) - (Size.Height / 2));
                Show(DockPanel, new Rectangle(topLeft, Size));
            }
        }
    }
}
