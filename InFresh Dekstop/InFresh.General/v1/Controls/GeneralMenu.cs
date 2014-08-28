using System;
using System.Windows.Forms;
using InFresh.Framework.v1.Interfaces;
using InFresh.General.v1.Implements;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.General.v1.Controls
{
    public partial class GeneralMenu : MenuStrip
    {
        public GeneralMenu()
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
                else if (sender == tsmiSalesArea)
                    dock = (IDock)Activator.CreateInstance(Type.GetType("InFresh.General.v1.Pages.GP002_SalesAreaPage"));
                else if (sender == tsmiCode)
                    dock = (IDock)Activator.CreateInstance(Type.GetType("InFresh.General.v1.Pages.GP003A_CodeDefinitionPage"));

                if (dock != null)
                    GeneralModule.Handler.Host.ShowContent(dock as DockContent, dock.State);
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
