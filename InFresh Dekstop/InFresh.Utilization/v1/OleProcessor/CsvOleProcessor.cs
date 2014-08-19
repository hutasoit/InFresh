using System.Collections.Generic;
using System.Data;

namespace InFresh.Utilization.v1.OleProcessor
{
    public class CsvOleProcessor : IOOleProcessor
    {
        private string conStr = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="delimeter"></param>
        public CsvOleProcessor(string filename, string delimeter)
            : base(filename)
        {
            conStr = string.Format(OldOle, FileName, "text", "Yes", string.Format("FMT=Delimited({0})", delimeter));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> GetSheets()
        {
            //using (OleDbCommand cmd = new OleDbCommand(string.Format
            //                      ("SELECT * FROM [{0}]", file.Name), con))
            //{
            //    con.Open();

            //    // Using a DataReader to process the data
            //    using (OleDbDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            // Process the current reader entry...
            //        }
            //    }

            //    // Using a DataTable to process the data
            //    using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
            //    {
            //        DataTable tbl = new DataTable("MyTable");
            //        adp.Fill(tbl);

            //        foreach (DataRow row in tbl.Rows)
            //        {
            //            // Process the current row...
            //        }
            //    }
            //}

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public override IList<string> GetHeaders(string sheet = null)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public override DataTable GetData(string sheet = null)
        {
            return null;
        }
    }
}
