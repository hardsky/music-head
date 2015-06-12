using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class MyBands : JamPage
{
    public MyBands()
    {
        m_Code = 27;
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
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select ba.Id, ba.Name, ba.Description, ba.Leader, ui_leader.SiteName as LeaderName 
from bands as ba, userinfo as ui_leader, usertoband as ub 
where ub.UserId=?UserId and ub.BandId=ba.Id and ub.Deleted=0 and ba.Deleted=0 and ui_leader.Id=ba.Leader;", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvBands.DataSource = ds;
                gvBands.DataBind();

                if (ds.Tables[0].Rows == null || ds.Tables[0].Rows.Count == 0)
                {
                    btnLeave.Visible = false;
                }
                else
                {
                    btnLeave.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyBands", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MyBand.aspx");
    }

    protected void btnLeave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvBands.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("cbSelected");
            if (cb.Checked)
            {
                LeaveBand(row);
            }
        }
        Response.Redirect("~/MyBands.aspx");
    }

    private void LeaveBand(GridViewRow row)
    {
        UInt64 nId = (UInt64)gvBands.DataKeys[row.RowIndex].Values["Id"];
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            MySqlTransaction trans = null;
            try
            {
                trans = con.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand("delete from usertoband where BandId=?BandId and UserId=?UserId;", con, trans);
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nId;
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                cmd.ExecuteNonQuery();

                //check, if user was leader
                cmd = new MySqlCommand("select Id from bands where Id=?BandId and Leader=?UserId;", con, trans);
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nId;
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                object obj = cmd.ExecuteScalar();
                if (obj != null && obj != DBNull.Value) //leader
                {
                    //check, if there another members of group
                    cmd = new MySqlCommand(@"select usertoband.UserId 
from usertoband, userinfo 
where usertoband.BandId=?BandId and usertoband.Deleted=0 and usertoband.UserId=userinfo.Id and userinfo.Deleted=0 order by userinfo.SiteName;", con, trans);
                    cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nId;

                    obj = cmd.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value) //someone alive here//set him leader
                    {
                        cmd = new MySqlCommand("update bands set Leader=?AliveUserId, Updated=UTC_TIMESTAMP(), Updater=?LastLeader where Id=?BandId;", con, trans);
                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nId;
                        cmd.Parameters.Add("?LastLeader", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                        cmd.Parameters.Add("?AliveUserId", MySqlDbType.UInt64).Value = obj;

                        cmd.ExecuteNonQuery();
                    }
                    else //delete band
                    {
                        Utils.DeleteBand(con, trans, nId);
                    }
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                JamLog.log(JamLog.enEntryType.error, "MyBands", "LeaveBand: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void gvBands_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBands.PageIndex = e.NewPageIndex;
        FillForm();
    }

    protected void gvBands_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            UInt64 nId = (UInt64)gvBands.DataKeys[e.Row.RowIndex].Values["Id"];
            Repeater rp_Lang = (Repeater)e.Row.Cells[3].FindControl("rpLang");
            FillBandLang(rp_Lang, nId);
        }
    }
}
