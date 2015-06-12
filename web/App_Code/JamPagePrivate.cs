using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Jam
{
    /// <summary>
    /// Summary description for JamPagePrivate
    /// </summary>
    public class JamPagePrivate : JamPage
    {
        protected string ItemId
        {
            get
            {
                return (string)ViewState["ItemId"];
            }
            set
            {
                ViewState["ItemId"] = value;
            }
        }

        protected string TableName
        {
            get
            {
                return (string)ViewState["TableName"];
            }
            set
            {
                ViewState["TableName"] = value;
            }
        }

        public JamPagePrivate()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected bool IsAuthor()
        {
            if (UserInfo == null) //anonimous users
                return false;

            if (String.IsNullOrEmpty(ItemId))
                return true;

            bool res = false;
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(String.Format("select Author from {0} where id=?id and Deleted=0", TableName), con);
                    cmd.Parameters.Add("?id", MySqlDbType.UInt64).Value = UInt64.Parse(ItemId);
                    string sAuthorID = cmd.ExecuteScalar().ToString();

                    res = (sAuthorID == UserInfo.Id && !String.IsNullOrEmpty(sAuthorID) && !String.IsNullOrEmpty(UserInfo.Id));

                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPgePrivate", "IsAuthor: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return res;
        }
    }
}
