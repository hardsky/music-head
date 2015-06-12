using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Jam
{
    /// <summary>
    /// Summary description for JamLog
    /// </summary>
    public class JamLog
    {
        public enum enEntryType
        {
            info = 0,
            warning,
            error
        }

        public JamLog()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        static public void log(enEntryType entrytype, string sSource, string sMessage)
        {
            MySqlConnection con = null;
            try
            {
                string sConStr = ConfigurationManager.ConnectionStrings["JamConnectionString"].ToString();
                con = new MySqlConnection(sConStr);
                con.Open();

                if (con != null)
                {
                    MySqlCommand cmd = new MySqlCommand(@"insert into jamlog (entry_type, entry_source, entry_msg, created) 
values(?entry_type, ?entry_source, ?entry_msg, UTC_TIMESTAMP())", con);
                    cmd.Parameters.Add("?entry_type", MySqlDbType.Int16).Value = (Int16)entrytype;
                    cmd.Parameters.Add("?entry_source", MySqlDbType.VarChar, 80).Value = sSource;
                    cmd.Parameters.Add("?entry_msg", MySqlDbType.VarChar, 2048).Value = sMessage.Length > 2048 ? sMessage.Substring(0, 2048) : sMessage;

                    cmd.ExecuteNonQuery();
                }
            }
            catch// (Exception ex)
            {
                //JamLog.log(JamLog.enEntryType.error, "string", "string: " + ex.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
    }
}