using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InFresh.Framework.v1.Enums
{
    public enum WizardType
    {
        Select = 00000000,
        Create = 00000001,
        Update = 00000002,
        Delete = 00000003,
        Import = 00000010,
        Export = 00000020,
        Report = 00000030
    }
}
