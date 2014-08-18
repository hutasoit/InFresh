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

namespace InFresh.Driver.v1.Forms
{
    public partial class G002_WizardWindow : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public G002_WizardWindow()
        {
            Resources = new ResourceManager("InFresh.Globalization.Localization.Resources", 
                Assembly.LoadFrom(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\PrivateAssemblies\\InFresh.Globalization.dll"));

            InitializeComponent();

            Text = Resources.GetString("Import_Data").Replace("&", string.Empty);
            txtSearch.WaterMark = string.Format(Resources.GetString("Search_Item"), string.Empty);
        }


        /// <summary>
        /// 
        /// </summary>
        protected ResourceManager Resources { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            if (lsbType.Items.Count != 0)
                btnOK.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonItem_Click(object sender, EventArgs e)
        {
            if (sender == btnSearch)
            {
                return;
            }

            if (sender == btnOK)
            {
                return;
            }

            if (sender == btnCancel)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        
    }
}
