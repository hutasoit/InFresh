using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InFresh.Framework.v1.Interfaces
{
    public interface IModule
    {
        void Activate();

        void Deactivate();
    }
}
