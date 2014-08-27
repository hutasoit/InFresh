using System;
using System.Collections.Generic;
using System.Resources;

namespace InFresh.Framework.v1.Interfaces
{
    public interface IModuleHandler
    {
        IHost Host { get; set; }

        ResourceManager Resources { get; set; }

        IRepository Repository { get; set; }

        IRepositoryV2 RepositoryV2 { get; set; }
        
        List<Lazy<IModule, IModuleMetadata>> Modules { get; set; }

        List<Lazy<IWizard>> Wizards { get; set; }
    }
}
