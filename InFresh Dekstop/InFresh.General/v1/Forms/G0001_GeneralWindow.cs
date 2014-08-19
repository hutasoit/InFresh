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

namespace InFresh.General.v1.Forms
{
    public partial class G0001_GeneralWindow : Form
    {
        public G0001_GeneralWindow()
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
            try
            {
                IDock dock = null;
                if (sender == tsmiAdministrative)
                    dock = (IDock)Activator.CreateInstance(Type.GetType("InFresh.General.v1.Pages.GP001_AdministrativePage"));
                else if(sender == tsmiSalesArea)
                    dock = (IDock)Activator.CreateInstance(Type.GetType("InFresh.General.v1.Pages.GP002_SalesAreaPage"));

                if (dock != null)
                    (dock as DockContent).Show(dckMainPanel, dock.State);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null,
                    ex.Message,
                    GeneralModule.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
