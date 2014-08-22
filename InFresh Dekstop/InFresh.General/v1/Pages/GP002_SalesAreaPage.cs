using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Interfaces;
using InFresh.General.v1.Implements;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.General.v1.Pages
{
    public partial class GP002_SalesAreaPage : DockContent, IDock
    {
        public GP002_SalesAreaPage()
        {
            InitializeComponent();

            Text = TabText = GeneralModule.Handler.Resources.GetString("Sales_Area").Replace("&", string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        public DockState State
        {
            get { return DockState.Document; }
        }

        private void GP002_SalesAreaPage_Load(object sender, EventArgs e)
        {

        }
    }
}
