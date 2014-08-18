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

namespace InFresh.Driver.v1.Forms
{
    public partial class G001_MainWindow : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public G001_MainWindow()
        {
            InitializeComponent();

            MinimumSize = Size = new Size(Screen.PrimaryScreen.Bounds.Width - 60, Screen.PrimaryScreen.Bounds.Height - 100);

            Resources = new ResourceManager("InFresh.Globalization.Localization.Resources", Assembly.LoadFrom(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\PrivateAssemblies\\InFresh.Globalization.dll"));

            Config = InFreshConfig.Instance;

            Text = string.Format(Resources.GetString("App_Name"), Config.AssemblyVersion);
        }

        /// <summary>
        /// 
        /// </summary>
        protected ResourceManager Resources { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected InFreshConfig Config { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender == tsmiImport)
            {
                new G002_WizardWindow().ShowDialog();
                return;
            }
            //G002_WizardWindow f = null;
            //if (sender == tsmiImport || sender == tsmiExport)
            //    f = new G002_WizardWindow(WizardType.Import);
            //else if (sender == tsbExport || sender == tsmiExport)
            //    f = new G002_WizardWindow(WizardType.Export);

            //if (f != null)
            //{
            //    if (f.ShowDialog() == DialogResult.OK)
            //    {
            //        Form fw = f.Wizard.Form(f.Type);
            //        if (fw != null) fw.ShowDialog(Handler.Host as Form);
            //    }
            //}
        }
    }
}
