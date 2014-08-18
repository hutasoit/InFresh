using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.Framework.v1.Interfaces
{
    public interface IDock
    {
        DockState State { get; }
    }
}
