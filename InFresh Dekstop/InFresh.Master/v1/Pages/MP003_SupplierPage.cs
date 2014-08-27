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

namespace InFresh.Master.v1.Pages
{
    public partial class MP003_SupplierPage : DockContent, IDock
    {
        #region Constructor & Properties
        /// <summary>
        /// 
        /// </summary>
        public MP003_SupplierPage()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public DockState State
        {
            get { return DockState.Document; }
        }
    }
}
