using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Base;
using InFresh.Framework.v1.Enums;
using InFresh.Framework.v1.Interfaces;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.Driver.v1.Forms
{
    public partial class Z0001_MainWindow : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Z0001_MainWindow()
        {
            InitializeComponent();

            MinimumSize = Size = new Size(Screen.PrimaryScreen.Bounds.Width - 60, Screen.PrimaryScreen.Bounds.Height - 100);

            Config = InFreshConfig.Instance;

            Text = string.Format(Program.Handler.Resources.GetString("App_Name"), Config.AssemblyVersion);
        }

        /// <summary>
        /// 
        /// </summary>
        protected InFreshConfig Config { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            tsmiStart.PerformClick();
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
                if (sender == tsmiStart)
                {
                    IDock dock = (IDock)Activator.CreateInstance(Type.GetType("InFresh.Driver.v1.Pages.P001_StartPage"));

                    Program.Handler.Host.ShowContent(dock as DockContent, dock.State);

                    //if (dock != null)
                    //{
                    //    DockContent content = dock as DockContent;
                    //    content.Show(dckMainPanel, dock.State);
                    //}
                    return;
                }

                if (sender == tsmiAboutApp)
                {
                    new Z0003_AboutWindow().ShowDialog();
                    return;
                }

                if (sender == tsmiImport || sender == tsmiExport)
                {
                    Z0002_WizardWindow f = null;
                    //if (sender == lnkNew)
                    //    f = new FDWizard(WizardType.New); //(Form)Activator.CreateInstance(Type.GetType("InFresh.Main.v1.Forms.FDWizard"), WizardType.New);
                    //else 
                    if (sender == tsmiImport)
                        f = new Z0002_WizardWindow(WizardType.Import);
                    else if (sender == tsmiExport)
                        f = new Z0002_WizardWindow(WizardType.Export);

                    if (f != null)
                    {
                        if (f.ShowDialog(Program.Handler.Host.MainWindow) == DialogResult.OK)
                        {
                            Form fw = f.Wizard.Window(f.Type);
                            if (fw != null) fw.ShowDialog(Program.Handler.Host.MainWindow);
                        }
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null,
                    ex.Message,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
