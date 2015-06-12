using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;

public partial class UIControls_OutboxMessages : TabControl
{
    public UIControls_OutboxMessages()
    {
        m_Code = 31;
        bDoLocalize = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LocalizeControls();
        if (!IsPostBack)
        {
            gvOutbox.DataBind();
        }
    }

    public override void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select messages.Id, subjects.Subj, userinfo.SiteName as ToName, messages.Created 
from messages, subjects, userinfo where messages.SenderDelete=0 and messages.FromId=?UserId and subjects.Id=messages.SubjId 
and userinfo.Id=messages.ToId
order by Created desc;", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = JamTypes.User.GetUserFromSession(Session).UIntId;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet("DS_OUTBOX");
                adp.Fill(ds);

                gvOutbox.DataSource = ds;
                gvOutbox.DataBind();

                btnDelete.Visible = ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_OutboxMessages", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void gvOutbox_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowMessage")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ulong nId = (ulong)gvOutbox.DataKeys[index].Value;
            FillMessage(nId);
        }
    }

    private void FillMessage(ulong nId)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                bool bReaded = false;

                MySqlCommand cmd = new MySqlCommand(@"select userinfo.SiteName as ToName, subjects.Subj, messages.Msg, messages.Created
from messages, subjects, userinfo where messages.Id=?Id and messages.SenderDelete=0 and messages.FromId=?UserId and subjects.Id=messages.SubjId 
and messages.ToId=userinfo.Id;", con);
                cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = nId;
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = JamTypes.User.GetUserFromSession(Session).UIntId;

                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        lbTo.Text = rdr.GetString("ToName");
                        lbSent.Text = rdr.GetDateTime("Created").ToString();
                        lbMsgSubject.Text = rdr.GetString("Subj");
                        dvText.InnerHtml = rdr.GetString("Msg");

                        bReaded = true;

                        trMessage.Visible = true;
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_OutboxMessages", "FillMessage: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ulong nCount = 0;
            foreach (GridViewRow row in gvOutbox.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("cbSelected");
                if (cb.Checked)
                {
                    nCount++;
                    MarkMessageToDelete(row);
                }
            }

            if (nCount > 0)
                DeleteMarkedMessages();
        }
        catch
        {
        }

        Response.Redirect("~/Messages.aspx");
    }

    private void DeleteMarkedMessages()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"delete from messages, subjects using messages, subjects where messages.FromId=?UserId and messages.RecipientDelete=1 and messages.SenderDelete=1 
and subjects.Id=messages.SubjId;", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = JamTypes.User.GetUserFromSession(Session).UIntId;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_OutboxMessages", "DeleteMarkedMessages: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void MarkMessageToDelete(GridViewRow row)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                UInt64 nId = (UInt64)gvOutbox.DataKeys[row.RowIndex].Values["Id"];
                MySqlCommand cmd = new MySqlCommand(@"update messages set SenderDelete=1 where Id=?Id;", con);
                cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = nId;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_OutboxMessages", "MarkMessageToDelete: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void gvOutbox_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            object oCr = drv["Created"];
            if (oCr != null && oCr != DBNull.Value && UserInfo != null)
            {
                DateTime dt = (DateTime)oCr;
                e.Row.Cells[3].Text = (dt + UserInfo.TimeZone).ToString();
            }
        }
    }
}
