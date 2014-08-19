using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace InFresh.Utilization.v1.OleProcessor
{
    /// <summary>
    /// Class Name  : XlsOleProcessor
    /// Created By  : Ivo Hutasoit
    /// Create On   : 22 May 2013
    /// Version     : 1.0.0.0
    /// Description : This inheritage ImportProcessor class gor processing Microsoft Excel. 
    ///               For this vesion, processor only accept first row as header of data.
    ///               What to do next for this class such as:
    ///               1. Recieve header for user defined position
    ///               2. Read all sheets on workbook file
    /// </summary>
    public class XlsOleProcessor : IOOleProcessor
    {
        private const string extends = "Excel 8.0";
        private string conStr = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public XlsOleProcessor(string filename)
            : base(filename)
        {
            try
            {
                string ext = Path.GetExtension(FileName);
                if (ext.Equals(".xls"))
                    conStr = string.Format(OldOle, FileName, extends, "Yes", string.Empty);
                else if (ext.Equals(".xlsx"))
                    conStr = string.Format(NewOle, FileName, extends, "Yes", string.Empty);
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> GetSheets()
        {
            IDictionary<string, string> sheets = null;
            DataTable dtSheet = null;
            try
            {
                Connection = new OleDbConnection(conStr);
                Connection.Open();

                // read all sheets from connection
                dtSheet = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dtSheet != null)
                {
                    sheets = new Dictionary<string, string>();

                    foreach (DataRow row in dtSheet.Rows)
                    {
                        string sheet = row["TABLE_NAME"].ToString();

                        sheets.Add(sheet, sheet.Replace("$", string.Empty).Replace("\'", string.Empty));
                    }
                }
            }
            catch { }
            finally
            {
                dtSheet = null;
                if (Connection != null)
                {
                    Connection.Close();
                    Connection = null;
                }
            }
            return sheets;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IList<string> GetHeaders(string sheet = null)
        {
            IList<string> headers = null;
            OleDbDataAdapter adapter = null;
            DataSet set = null;
            try
            {

                if (sheet == null || sheet.Equals(string.Empty))
                {
                    sheet = GetSheets().Keys.ToList()[0].ToString();
                }

                Connection = new OleDbConnection(conStr);
                Connection.Open();

                headers = new List<string>();

                adapter = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", sheet), Connection);

                set = new DataSet();
                adapter.Fill(set);

                headers = set.Tables[0].Columns.Cast<DataColumn>()
                            .Select(m => m.ColumnName).ToList();

            }
            catch { }
            finally
            {
                set = null;
                adapter = null;
                if (Connection != null)
                {
                    Connection.Close();
                    Connection = null;
                }
            }
            return headers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DataTable GetData(string sheet = null)
        {
            DataTable data = null;
            OleDbDataAdapter adapter = null;
            DataSet set = null;
            try
            {

                if (sheet == null || sheet.Equals(string.Empty))
                {
                    sheet = GetSheets().Keys.ToList()[0].ToString();
                }

                Connection = new OleDbConnection(conStr);
                Connection.Open();

                adapter = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", sheet), Connection);

                set = new DataSet();
                adapter.Fill(set);

                data = new DataTable();
                data = set.Tables[0];

            }
            catch { }
            finally
            {
                set = null;
                adapter = null;
                if (Connection != null)
                {
                    Connection.Close();
                    Connection = null;
                }
            }
            return data;
        }
    }
}
