using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Attributes;
using InFresh.Framework.v1.Interfaces;
using InFresh.Master.v1.Controls;
using InFresh.Master.v1.Forms;

namespace InFresh.Master.v1.Implements
{
    [Module("Master Module")]
    public class MasterModule : IModule
    {
        /// <summary>
        /// 
        /// </summary>
        private M0001_MasterWindow window = null;

        private MasterMenu menu = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        [ImportingConstructor()]
        public MasterModule([Import(typeof(IModuleHandler))] IModuleHandler handler)
        {
            window = new M0001_MasterWindow();

            menu = new MasterMenu();

            Handler = handler;
        }

        /// <summary>
        /// 
        /// </summary>
        public static IModuleHandler Handler { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string Name { get { return "Master Module"; } }

        #region IModule Members
        /// <summary>
        /// 
        /// </summary>
        public void Activate()
        {
            IList<ToolStripItem> menus = new List<ToolStripItem>();
            foreach (var me in menu.Items)
                menus.Add(me as ToolStripMenuItem);
            //var menus = window.mnsMenubar.Items;
            for (int ii = 0; ii < menus.Count; ii++)
            {
                ToolStripMenuItem mm = menus[ii] as ToolStripMenuItem;
                Handler.Host.AddMenu(ii, mm);
            }
        }

        public void Deactivate()
        {
            
        }
        #endregion
    }
}
