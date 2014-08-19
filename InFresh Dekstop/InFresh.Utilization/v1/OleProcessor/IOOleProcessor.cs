using InFresh.Utilization.v1.Processors;
using System.Data.OleDb;

namespace InFresh.Utilization.v1.OleProcessor
{
    public abstract class IOOleProcessor : IOProcessor
    {
        public IOOleProcessor(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected string OldOle
        {
            get
            {
                return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='{1};HDR={2};{3}'";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected string NewOle
        {
            get
            {
                return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='{1};HDR={2};{3}'";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected OleDbConnection Connection { get; set; }
    }
}
