using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InFresh.Master.v1.Wizards
{
    public enum ImportSequence
    {
        IDLE = -1,
        FormLoad = 0,
        FileLoad = 1,
        SheetLoad = 2,
        TemplateLoad = 3,
        DataLoad = 4,
        DataSaving = 5,
        TemplateSaving = 6,
    }
}
