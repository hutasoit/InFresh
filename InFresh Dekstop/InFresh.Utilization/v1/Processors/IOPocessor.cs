using System;
using System.Collections.Generic;
using System.Data;

namespace InFresh.Utilization.v1.Processors
{
    public abstract class IOProcessor : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public IOProcessor(string filename)
        {
            FileName = filename;
        }

        /// <summary>
        /// 
        /// </summary>
        protected string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IDictionary<string, string> GetSheets();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract IList<string> GetHeaders(string sheet = null);

        /// <summary>
        /// 
        /// </summary>
        public abstract DataTable GetData(string sheet = null);

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            FileName = null;
        }
    }
}
