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

            Text = string.Format(Resources.GetString("App_Name"), "1.0.1");
        }

        /// <summary>
        /// 
        /// </summary>
        protected ResourceManager Resources { get; private set; }
    }
}
