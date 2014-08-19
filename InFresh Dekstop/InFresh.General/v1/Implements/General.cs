using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Attributes;
using InFresh.Framework.v1.Interfaces;
using InFresh.General.v1.Forms;

namespace InFresh.General.v1.Implements
{
    [Module("General Module")]
    public class General : IModule
    {
        /// <summary>
        /// 
        /// </summary>
        private G0001_GeneralWindow window = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        [ImportingConstructor()]
        public General([Import(typeof(IModuleHandler))] IModuleHandler handler)
        {
            window = new G0001_GeneralWindow();

            Handler = handler;
        }

        /// <summary>
        /// 
        /// </summary>
        public static IModuleHandler Handler { get; set; }

        #region IModule Members
        /// <summary>
        /// 
        /// </summary>
        public void Activate()
        {
            IList<ToolStripItem> menus = new List<ToolStripItem>();
            foreach (var menu in window.mnsMenubar.Items)
                menus.Add(menu as ToolStripMenuItem);
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
