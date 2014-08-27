using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InFresh.Driver.v1.Forms;
using InFresh.Framework.v1.Base;
using InFresh.Framework.v1.Interfaces;

namespace InFresh.Driver
{
    static class Program
    {
        public static InFreshHandler Handler = InFreshHandler.Instance;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Handler.Initialize();
            Handler.Repository = UnitOfWork.GetInstance();
            Handler.RepositoryV2 = new UnitOfWorkV2();

            Application.Run(Handler.Host.MainWindow);
        }
    }
}
