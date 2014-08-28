using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Interfaces;
using WeifenLuo.WinFormsUI.Docking;
using InFresh.Master.v1.Implements;

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
            try
            {
                IDock dock = null;
                if (sender == tsmiSubdepo)
                    dock = (IDock)Activator.CreateInstance(Type.GetType("InFresh.Master.v1.Pages.MP001_SubdepoPage"));
                else if(sender == tsmiEmployee)
                    dock = (IDock)Activator.CreateInstance(Type.GetType("InFresh.Master.v1.Pages.MP002_EmployeePage"));
                else if (sender == tsmiSupplier)
                    dock = (IDock)Activator.CreateInstance(Type.GetType("InFresh.Master.v1.Pages.MP003_SupplierPage"));
                else if (sender == tsmiOutlet)
                    dock = (IDock)Activator.CreateInstance(Type.GetType("InFresh.Master.v1.Pages.MP004_OutletPage"));

                if (dock != null)
                    MasterModule.Handler.Host.ShowContent(dock as DockContent, dock.State);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null,
                    ex.Message,
                    MasterModule.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //MessageBox.Show("Hello Menu " + (sender as ToolStripMenuItem).Text.Replace("&", string.Empty));
            //if (sender == tsmiSubdepo)
            //{
            //    MessageBox.Show("Hello Menu Master Subdepo");
            //    return;
            //}
        }
    }
}
