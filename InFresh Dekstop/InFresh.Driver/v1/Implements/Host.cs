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

        /// <summary>
        /// Show content to main panel of form based on DockState like Document, DockLeft etc
        /// </summary>
        /// <param name="content">Content that would be showed</param>
        /// <param name="state">State of content on main panel</param>
        public void ShowContent(DockContent content, DockState state)
        {
            if (state != DockState.Float)
            {
                bool found = false;

                foreach (DockContent d in window.dckMainPanel.Contents)
                {
                    if (d.Name.Equals(content.Name))
                    {
                        found = true;
                        d.Activate();
                        break;
                    }
                }

                if (!found)
                    content.Show(window.dckMainPanel, state);
            }
            else
                content.Show(window.dckMainPanel, state);
        }

        /// <summary>
        /// Add item to main menubar of application based on position. Item will be added to 
        /// right position that defined on parameter.
        /// </summary>
        /// <param name="pos">Position of item </param>
        /// <param name="item">Current object of item that would be added</param>
        public void AddMenu(int pos, ToolStripMenuItem item)
        {
            bool found = false;
            ToolStripMenuItem mnu = null;

            if (pos >= window.mnsMenubar.Items.Count)
            {
                window.mnsMenubar.Items.AddRange(new ToolStripItem[] { item });
                return;
            }

            foreach (ToolStripItem menu in window.mnsMenubar.Items)
            {
                if (menu.Text.Replace("&", string.Empty)
                        .Equals(item.Text.Replace("&", string.Empty), StringComparison.CurrentCultureIgnoreCase))
                {
                    found = true;
                    mnu = menu as ToolStripMenuItem;
                    break;
                }
            }

            if (found)
            {
                mnu.DropDownItems.AddRange(item.DropDownItems);
            }
            else
                window.mnsMenubar.Items.Insert(pos, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="pos"></param>
        /// <param name="item"></param>
        public void AddMenuItem(string parent, int pos, ToolStripItem item)
        {
            foreach (ToolStripItem menu in window.mnsMenubar.Items)
            {
                if (menu.GetType() == typeof(ToolStripSeparator))
                    continue;
                else
                {
                    ToolStripMenuItem tMenu = (ToolStripMenuItem)menu;
                    if (tMenu.Text.Replace("&", "")
                        .Equals(parent, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if ((pos >= tMenu.DropDownItems.Count))
                            tMenu.DropDownItems.Add(item);
                        else
                            tMenu.DropDownItems.Insert(pos, item);
                        break;
                    }
                    else if (tMenu.HasDropDownItems)
                    {
                        //if (pos >= tMenu.DropDownItems.Count)
                        //{
                        //    tMenu.DropDownItems.AddRange(new ToolStripItem[] { item });
                        //    return;
                        //}

                        foreach (ToolStripItem child in tMenu.DropDownItems)
                        {
                            if (child.GetType() == typeof(ToolStripSeparator))
                                continue;
                            else
                            {
                                ToolStripMenuItem tChild = (ToolStripMenuItem)child;
                                if (tChild.Text.Replace("&", "")
                                    .Equals(parent, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    tChild.DropDownItems.Insert(pos, item);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="item"></param>
        public void AddToolbar(int pos, ToolStripItem item)
        {
            window.tlsToolbar.Items.Insert(pos, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="pos"></param>
        /// <param name="item"></param>
        public void AddToolBarDropDown(string parent, int pos, ToolStripItem item)
        {
            foreach (ToolStripItem cItem in window.tlsToolbar.Items)
            {
                if (cItem.GetType() == typeof(ToolStripSeparator))
                    continue;
                else if (cItem.GetType() == typeof(ToolStripComboBox))
                {
                    ToolStripComboBox tcItem = (ToolStripComboBox)cItem;
                    if (tcItem.Text.Equals(parent))
                    {
                        tcItem.Items.Insert(pos, item);
                        break;
                    }
                    else if (tcItem.Items.Count > 0)
                    {
                        foreach (ToolStripItem child in tcItem.Items)
                        {
                            if (child.GetType() == typeof(ToolStripSeparator))
                                continue;
                            else if (child.Text.Equals(parent))
                                break;
                        }
                    }
                }
                else
                {

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolbar"></param>
        public void MergeToolbar(ToolStrip toolbar)
        {
            ToolStripManager.RevertMerge(window.tlsToolbar, toolbar);

            ToolStripManager.Merge(toolbar, window.tlsToolbar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolbar"></param>
        public void ReverseToolbar(ToolStrip toolbar)
        {
            ToolStripManager.RevertMerge(window.tlsToolbar, toolbar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusbar"></param>
        public void MergeStatusbar(StatusStrip statusbar)
        {
            ToolStripManager.RevertMerge(window.stsStatusbar, statusbar);

            ToolStripManager.Merge(statusbar, window.stsStatusbar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusbar"></param>
        public void ReverseStatusbar(StatusStrip statusbar)
        {
            ToolStripManager.RevertMerge(window.stsStatusbar, statusbar);
        }
        #endregion
    }
}
