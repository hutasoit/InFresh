using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InFresh.Master.v1.Enums
{
    public enum Flag
    {
        IDLE = -00000001,

        // User Interfaces' Flag Operations
        FormLoading = 00000000,
        FileLoading = 00000010,
        SheetLoading = 00000020,
        TemplateLoading = 00000030,
        DataLoading = 00000040,
        DetailLoading = 00000041,
        DataSaving = 00000050,
        TemplateSaving = 00000060,
        MapLoading = 00000070,
        PointLoading = 00000071,

        // Database's Flag Operation
        DataCreating = 00000100,
        DataUpdating = 00000101,
        DataDeleting = 00000102,
        DataTruncating = 00000203,
    }
}
