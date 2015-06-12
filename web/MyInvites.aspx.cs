using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;

public partial class MyInvites : JamPage
{
    public MyInvites()
    {
        m_Code = 29;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillForm();
        }
    }

    private void FillForm()
    {
        trActions.Visible = false;

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select invites.Id, bands.Id as BandId, userinfo.SiteName as InviterName, bands.Name as BandName, invites.Msg, invites.Created from invites, commentsubjtables as cst, userinfo, bands 
where invites.UserId=?UserId and invites.SubjTableId=cst.Id and cst.TableName='bands' and userinfo.Id=invites.MainUserId 
and invites.SubjId=bands.Id;", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet("DS_MYINVS");
                adp.Fill(ds);

                gvInvites.DataSource = ds;
                gvInvites.DataBind();

                if (ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
                    trActions.Visible = true;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyInvites", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvInvites.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("cbSelected");
            if (cb.Checked)
            {
                JoinToBand(row);
            }
        }
        Response.Redirect("~/MyInvites.aspx");        
    }

    private void JoinToBand(GridViewRow row)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            MySqlTransaction trans = null;
            try
            {
                UInt64 nBandId = (UInt64)gvInvites.DataKeys[row.RowIndex].Values["BandId"];

                trans = con.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand(@"insert into usertoband (UserId, BandId, Deleted, Updater, Updated) 
values(?UserId, ?BandId, 0, ?UserId, UTC_TIMESTAMP());SELECT LAST_INSERT_ID();", con, trans);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nBandId;
                
                object obj = cmd.ExecuteScalar();

                if (obj != null && obj != DBNull.Value)
                {
                    UInt64 nId = (UInt64)gvInvites.DataKeys[row.RowIndex].Values["Id"];
                    cmd = new MySqlCommand("delete from invites where Id=?Id", con, trans);
                    cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = nId;

                    cmd.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyInvites", "JoinToBand: " + ex.Message);
                if (trans != null)
                    trans.Rollback();
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvInvites.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("cbSelected");
            if (cb.Checked)
            {
                DeleteInvite(row);
            }
        }
        Response.Redirect("~/MyInvites.aspx");
    }

    private void DeleteInvite(GridViewRow row)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                UInt64 nId = (UInt64)gvInvites.DataKeys[row.RowIndex].Values["Id"];
                MySqlCommand cmd = new MySqlCommand("delete from invites where Id=?Id", con);
                cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = nId;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyInvites", "DeleteInvite: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void gvInvites_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            object oCr = drv["Created"];
            if (oCr != null && oCr != DBNull.Value && UserInfo != null)
            {
                DateTime dt = (DateTime)oCr;
                e.Row.Cells[4].Text = (dt + UserInfo.TimeZone).ToString();
            }
        }
    }
}
