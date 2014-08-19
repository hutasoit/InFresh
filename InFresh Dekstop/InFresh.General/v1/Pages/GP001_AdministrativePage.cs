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
    public partial class GP001_AdministrativePage : DockContent, IDock
    {
        /// <summary>
        /// 
        /// </summary>
        public GP001_AdministrativePage()
        {
            InitializeComponent();

            Text = TabText = GeneralModule.Handler.Resources.GetString("Administrative_Area").Replace("&", string.Empty);

            txtSearch.WaterMark = string.Format(GeneralModule.Handler.Resources.GetString("Search_Item"), string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        public DockState State
        {
            get { return DockState.Document; }
        }
    }
}
