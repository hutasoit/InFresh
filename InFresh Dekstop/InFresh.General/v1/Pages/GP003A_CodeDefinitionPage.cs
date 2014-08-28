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

namespace InFresh.General.v1.Pages
{
    public partial class GP003A_CodeDefinitionPage : DockContent, IDock
    {
        #region Constructor & Properties
        /// <summary>
        /// 
        /// </summary>
        public GP003A_CodeDefinitionPage()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public DockState State
        {
            get { return DockState.Float; }
        }
    }
}
