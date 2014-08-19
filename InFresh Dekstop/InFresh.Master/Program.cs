using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InFresh.Master.v1.Forms;

namespace InFresh.Master
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
            Application.Run(new M0001_MasterWindow());
        }
    }
}
