using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;

public partial class SetHashedPsw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                int saltSize = 6;
                string salt = Utils.CreateSalt(saltSize);//i used array of 6 bytes to generate salt, but get salt string with length 8; need some reseach TODO
                string sPswHash = Utils.CreatePasswordHash("1", salt);

                MySqlCommand cmd = new MySqlCommand(@"update userinfo set PswHash=?PswHash where Id=29;", con);
                cmd.Parameters.Add("?PswHash", MySqlDbType.VarChar, 48).Value = sPswHash;
                object obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "SetHashedPsw", "Action: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
