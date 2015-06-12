using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;

public partial class CreateMessage : JamPage
{
    public CreateMessage()
    {
        m_Code = 34;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbTo.Text = string.Empty;
            tbSubj.Text = string.Empty;
            ctrEditor.Content = string.Empty;
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(ctrEditor.Content))
        {
            bool bSucceded = false;

            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                MySqlTransaction trans = null;
                try
                {
                    trans = con.BeginTransaction();

                    MySqlCommand cmd = new MySqlCommand(@"insert into subjects set Subj=?Subj;select LAST_INSERT_ID();", con, trans);
                    cmd.Parameters.Add("?Subj", MySqlDbType.VarChar, 45).Value = Utils.SQLEscape(tbSubj.Text.Trim());
                    ulong nSubjId = Convert.ToUInt64(cmd.ExecuteScalar());

                    cmd = new MySqlCommand(@"insert into messages (SubjId, Msg, FromId, ToId, Created, SenderDelete, RecipientDelete, IsReaded) 
select ?SubjId, ?Msg, ?FromId, userinfo.Id, UTC_TIMESTAMP(), 0, 0, 0 from userinfo where LOWER(userinfo.SiteName)=?ToName;", con, trans);
                    cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = nSubjId;
                    cmd.Parameters.Add("?Msg", MySqlDbType.VarChar, 1024).Value = Utils.SQLEscape(ctrEditor.Content).Trim();
                    cmd.Parameters.Add("?FromId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                    cmd.Parameters.Add("?ToName", MySqlDbType.VarChar, 45).Value = Utils.SQLEscape(tbTo.Text.ToLower().Trim());

                    cmd.ExecuteNonQuery();

                    trans.Commit();

                    bSucceded = true;
                }
                catch (Exception ex)
                {
                    if (trans != null)
                        trans.Rollback();
                    JamLog.log(JamLog.enEntryType.error, "CreateMessage", "btnSend_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            if (bSucceded)
                Response.Redirect("~/Messages.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Messages.aspx");
    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        dvPreview.InnerHtml = ctrEditor.Content;
        dvPreview.Visible = true;
    }
}
