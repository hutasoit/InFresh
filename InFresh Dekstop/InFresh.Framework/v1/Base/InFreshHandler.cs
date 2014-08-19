using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using InFresh.Framework.v1.Interfaces;

namespace InFresh.Framework.v1.Base
{
    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IModuleHandler))]
    public class InFreshHandler : IModuleHandler, IDisposable
    {
        /// <summary>
        /// Singleton of class
        /// </summary>
        private static InFreshHandler _instance = null;

        /// <summary>
        /// Catalog modules
        /// </summary>
        private AggregateCatalog catalog = new AggregateCatalog();

        /// <summary>
        /// 
        /// </summary>
        private InFreshHandler()
        {
            Resources = new ResourceManager("InFresh.Globalization.Localization.Resources", Assembly.LoadFrom(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\PrivateAssemblies\\InFresh.Globalization.dll"));
        }

        /// <summary>
        /// 
        /// </summary>
        public static InFreshHandler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InFreshHandler();
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            try
            {
                var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                catalog.Catalogs.Add(new AssemblyCatalog(
                                       Assembly.GetCallingAssembly()));

                catalog.Catalogs.Add(
                    new DirectoryCatalog(location, "*.dll"));


                catalog.Catalogs.Add(
                    new DirectoryCatalog(location + "\\Modules\\", "*.dll"));

                var container = new CompositionContainer(catalog);

                container.ComposeParts(this);

                foreach (var module in Modules)
                    module.Value.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #region IModuleHandler Members
        [Import(typeof(IHost))]
        public IHost Host { get; set; }

        public ResourceManager Resources { get; set; }

        [Import(typeof(IRepository))]
        public IRepository Repository { get; set; }

        [ImportMany(typeof(IModule), AllowRecomposition = true)]
        public List<Lazy<IModule>> Modules { get; set; }

        [ImportMany(typeof(IWizard), AllowRecomposition = true)]
        public List<Lazy<IWizard>> Wizards { get; set; }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            catalog.Dispose();
            catalog = null;
        }
        #endregion
    }
}
