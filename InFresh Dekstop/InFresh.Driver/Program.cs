using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InFresh.Driver.v1.Forms;

namespace InFresh.Driver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new G001_MainWindow());
        }
    }
}
