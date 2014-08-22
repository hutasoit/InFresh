using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Enums;
using InFresh.Framework.v1.Interfaces;
using InFresh.Master.v1.Wizards.Imports;

namespace InFresh.Master.v1.Implements
{
    [Export(typeof(IWizard))]
    public class SubdepoWizard : IWizard
    {
        #region IWizard Member
        /// <summary>
        /// 
        /// </summary>
        public string FullPath
        {
            get
            {
                return string.Format("{0}",
                    MasterModule.Handler.Resources.GetString("Master").Replace("&", string.Empty));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return MasterModule.Handler.Resources.GetString("Subdepo").Replace("&", string.Empty); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Form Window(WizardType type)
        {
            switch (type)
            {
                case WizardType.Import:
                    return new MW001_ImportSubdepo();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Description;
        }
        #endregion
    }

    [Export(typeof(IWizard))]
    public class EmployeeWizard : IWizard
    {
        #region IWizard Member
        /// <summary>
        /// 
        /// </summary>
        public string FullPath
        {
            get
            {
                return string.Format("{0}",
                    MasterModule.Handler.Resources.GetString("Master").Replace("&", string.Empty));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return MasterModule.Handler.Resources.GetString("Employee").Replace("&", string.Empty); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Form Window(WizardType type)
        {
            switch (type)
            {
                case WizardType.Import:
                    return new MW002_ImportEmployee();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Description;
        }
        #endregion
    }

    [Export(typeof(IWizard))]
    public class SupplierWizard : IWizard
    {
        #region IWizard Member
        /// <summary>
        /// 
        /// </summary>
        public string FullPath
        {
            get
            {
                return string.Format("{0}",
                    MasterModule.Handler.Resources.GetString("Master").Replace("&", string.Empty));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return MasterModule.Handler.Resources.GetString("Supplier").Replace("&", string.Empty); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Form Window(WizardType type)
        {
            switch (type)
            {
                case WizardType.Import:
                    return new MW003_ImportSupplier();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Description;
        }
        #endregion
    }


    [Export(typeof(IWizard))]
    public class OutletWizard : IWizard
    {
        #region IWizard Member
        /// <summary>
        /// 
        /// </summary>
        public string FullPath
        {
            get
            {
                return string.Format("{0}",
                    MasterModule.Handler.Resources.GetString("Master").Replace("&", string.Empty));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return MasterModule.Handler.Resources.GetString("Outlet").Replace("&", string.Empty); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Form Window(WizardType type)
        {
            switch (type)
            {
                case WizardType.Import:
                    return new MW004_ImportOutlet();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Description;
        }
        #endregion
    }
}
