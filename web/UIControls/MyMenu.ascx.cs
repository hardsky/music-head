using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Jam;
using MySql.Data.MySqlClient;

//dvSelectedMenuItem
public partial class UIControls_MyMenu : JamUIControl
{
    public UIControls_MyMenu()
    {
        m_Code = 5;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            AddInviteCount();
            AddNewMsgCount();
        }
        base.OnPreRender(e);
    }

    private void AddNewMsgCount()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select count(*) as cnt from messages where ToId=?UserId and IsReaded <> 1", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("cnt")))
                        {
                            int cnt = rdr.GetInt32("cnt");
                            if (cnt > 0)
                            {
                                hlMessages.Text += " (" + cnt + ")";
                            }                            
                        }
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_MyMenu", "AddNewMsgCount: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void AddInviteCount()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select count(*) as cnt from invites where UserId=?UserId", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        if(!rdr.IsDBNull(rdr.GetOrdinal("cnt")))
                        {
                            int cnt = rdr.GetInt32("cnt");
                            if (cnt > 0)
                            {
                                hlInvites.Text += " (" + cnt + ")";
                            }
                        }
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControl_MyMenu", "AddInviteCount: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        JamTypes.User.ResetUserSession(Session);
        Response.Redirect(Request.RawUrl);
    }
}
