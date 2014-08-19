using System.Windows.Forms;
using InFresh.Framework.v1.Enums;

namespace InFresh.Framework.v1.Interfaces
{
    public interface IWizard
    {
        string FullPath { get; }

        string Description { get; }

        Form Window(WizardType type);
    }
}
