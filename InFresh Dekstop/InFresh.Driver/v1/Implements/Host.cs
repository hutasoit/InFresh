using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Driver.v1.Forms;
using InFresh.Framework.v1.Interfaces;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.Driver.v1.Implements
{
    [Export(typeof(IHost))]
    public class Host : IHost
    {
        /// <summary>
        /// 
        /// </summary>
        private G001_MainWindow window;

        /// <summary>
        /// 
        /// </summary>
        public Host()
        {
            window = new G001_MainWindow();
        }

        #region IHost Member
        /// <summary>
        /// 
        /// </summary>
        public string DomainName
        {
            get { return window.Name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Form MainWindow
        {
            get { return window; }
        }

        public void ShowContent(DockContent content, DockState state)
        {
            throw new NotImplementedException();
        }

        public void AddMenu(int pos, ToolStripMenuItem item)
        {
            throw new NotImplementedException();
        }

        public void AddMenuItem(string parent, int pos, ToolStripItem item)
        {
            throw new NotImplementedException();
        }

        public void AddToolbar(int pos, ToolStripItem item)
        {
            throw new NotImplementedException();
        }

        public void AddToolBarDropDown(string parent, int pos, ToolStripItem item)
        {
            throw new NotImplementedException();
        }

        public void MergeToolbar(ToolStrip toolbar)
        {
            throw new NotImplementedException();
        }

        public void ReverseToolbar(ToolStrip toolbar)
        {
            throw new NotImplementedException();
        }

        public void MergeStatusbar(StatusStrip statusbar)
        {
            throw new NotImplementedException();
        }

        public void ReverseStatusbar(StatusStrip statusbar)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
