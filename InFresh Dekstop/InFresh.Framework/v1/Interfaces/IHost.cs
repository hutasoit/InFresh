using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.Framework.v1.Interfaces
{
    public interface IHost
    {
        string Host { get; }

        void ShowContent(DockContent content, DockState state);

        void AddMenu(int pos, ToolStripMenuItem item);

        void AddMenuItem(string parent, int pos, ToolStripItem item);

        void AddToolbar(int pos, ToolStripItem item);

        void AddToolBarDropDown(string parent, int pos, ToolStripItem item);

        void MergeToolbar(ToolStrip toolbar);

        void ReverseToolbar(ToolStrip toolbar);

        void MergeStatusbar(StatusStrip statusbar);

        void ReverseStatusbar(StatusStrip statusbar);
    }
}
