using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using InFresh.Framework.v1.Interfaces;

namespace InFresh.Framework.v1.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [MetadataAttribute]
    public class ModuleAttribute : ExportAttribute
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="name"></param>
        public ModuleAttribute(string name)
            : base(typeof(IModule))
        {
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }
    }
}
