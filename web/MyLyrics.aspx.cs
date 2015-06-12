using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class MyLyrics : JamPage
{
    public MyLyrics()
    {
        m_Code = 18;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                btnDelete.Visible = false;
                FillForm();
            }
        }
        catch(Exception ex)
        {
            JamLog.log(JamLog.enEntryType.error, "MyLyrics", "Page_Load: " + ex.Message);
        }
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    "select id, Name, Created, Updated from lyrics where Author=?Author and Deleted=0", con);
                cmd.Parameters.Add("?Author", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvLirics.DataSource = ds;
                gvLirics.DataBind();

                if (gvLirics.Rows != null && gvLirics.Rows.Count > 0)
                {
                    btnDelete.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyLyrics", "FillForm: " + ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SongWriter.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        List<ulong> lstIds = new List<ulong>();
        foreach (GridViewRow row in gvLirics.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("chSelected");
            if (cb.Checked)
            {
                UInt64 nId = (UInt64)gvLirics.DataKeys[row.RowIndex].Values["id"];
                lstIds.Add(nId);
            }
        }

        if (lstIds.Count > 0)
        {
            DeleteLyrics(lstIds);
        }

        Response.Redirect("~/MyLyrics.aspx");
    }

    private void DeleteLyrics(List<ulong> lstIds)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update lyrics set Deleted=1 where id in (", con);
                foreach (ulong nId in lstIds)
                {
                    cmd.CommandText += "'" + nId + "',";
                }

                cmd.CommandText = cmd.CommandText.TrimEnd(',');
                cmd.CommandText += ") and Author=?AuthorId";
                cmd.Parameters.Add("?AuthorId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyLyrics", "btnDelete_Click: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void gvLirics_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            object oCr = drv["Created"];
            if (oCr != null && oCr != DBNull.Value && UserInfo != null)
            {
                DateTime dt = (DateTime)oCr;
                e.Row.Cells[2].Text = (dt + UserInfo.TimeZone).ToString();
            }
            object oUpd = drv["Updated"];
            if (oUpd != null && oUpd != DBNull.Value && UserInfo != null)
            {
                DateTime dt = (DateTime)oUpd;
                e.Row.Cells[3].Text = (dt + UserInfo.TimeZone).ToString();
            }
        }
    }
}
