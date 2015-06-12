using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Lyrics : JamPage
{
    public Lyrics()
    {
        m_Code = 11;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                FillForm();

                SetPageTitleDescr(new string[] { 
                                "Lyrics", 
                                "Стихи" },
                    new string[] { 
                               "Lyrics Archives.", 
                                "Собрание стихов пользователей music-head" });
            }

            ctrFinder.onFindBtnClick = btnFind_Click;
        }
        catch (Exception ex)
        {
            JamLog.log(JamLog.enEntryType.error, "Lyrics", "Page_Load: " + ex.Message);
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
                    @"select lyrics.id, lyrics.Name, userinfo.SiteName as AuthorName, lyrics.Style, lyrics.Language, lyrics.Created, lyrics.Updated 
from lyrics left outer join (bands) on (lyrics.BandId=bands.Id and bands.Deleted=0), userinfo 
where lyrics.Deleted=0 and lyrics.Author = userinfo.Id and userinfo.Deleted=0", con);

                if (!String.IsNullOrEmpty(ctrFinder.Name))
                {
                    cmd.CommandText += " and LOWER(lyrics.Name) like ?Name";
                    cmd.Parameters.Add("?Name", MySqlDbType.VarChar, 100).Value = ctrFinder.Name;
                }

                if (!String.IsNullOrEmpty(ctrFinder.Style))
                {
                    cmd.CommandText += " and LOWER(lyrics.Style)=?Style";
                    cmd.Parameters.Add("?Style", MySqlDbType.VarChar, 80).Value = ctrFinder.Style;
                }

                if (!String.IsNullOrEmpty(ctrFinder.Lang))
                {
                    cmd.CommandText += " and LOWER(lyrics.Language)=?Language";
                    cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = ctrFinder.Lang;
                }

                if (!String.IsNullOrEmpty(ctrFinder.Author))
                {
                    cmd.CommandText += " and LOWER(userinfo.SiteName) like ?SiteName";
                    cmd.Parameters.Add("?SiteName", MySqlDbType.VarChar, 45).Value = ctrFinder.Author;
                }
                if (UserInfo != null)
                {
                    cmd.CommandText += @" and (lyrics.Author=?UserId or lyrics.Visibility IS NULL or lyrics.Visibility=0 or lyrics.Visibility=1 or 
(lyrics.Visibility=3 and lyrics.BandId is Not null and 
?UserId in (select UserId from usertoband where usertoband.BandId=lyrics.BandId and usertoband.Deleted=0)))";
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                }
                else
                {
                    cmd.CommandText += " and (lyrics.Visibility IS NULL or lyrics.Visibility=0)";
                }

                if (!String.IsNullOrEmpty(SortExpr))
                {
                    string sTmp = SortExpr.ToLower();
                    cmd.CommandText += " order by " + ((sTmp == "updated" || sTmp == "created") ? SortExpr : Utils.SQLEscape(SortExpr)) + (SortDir == SortDirection.Ascending ? " ASC" : " DESC");
                }

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvLirics.DataSource = ds;
                gvLirics.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Lyrics", "FillForm: " + ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void gvLirics_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLirics.PageIndex = e.NewPageIndex;
        FillForm();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        FillForm();
    }
    private string SortExpr
    {
        get
        {
            return (string)ViewState["SortExpr"];
        }
        set
        {
            ViewState["SortExpr"] = value;
        }
    }

    private SortDirection SortDir
    {
        get
        {
            return (SortDirection)ViewState["SortDir"];
        }
        set
        {
            ViewState["SortDir"] = value;
        }
    }
    protected void gvLirics_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == SortExpr)
        {
            if (SortDir == SortDirection.Ascending)
                e.SortDirection = SortDirection.Descending;
            else
                e.SortDirection = SortDirection.Ascending;
        }
        SortExpr = e.SortExpression;
        SortDir = e.SortDirection;

        FillForm();
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
                e.Row.Cells[4].Text = (dt + UserInfo.TimeZone).ToString();
            }
            object oUpd = drv["Updated"];
            if (oUpd != null && oUpd != DBNull.Value && UserInfo != null)
            {
                DateTime dt = (DateTime)oUpd;
                e.Row.Cells[5].Text = (dt + UserInfo.TimeZone).ToString("dd.MM.yyyy");
            }
        }
    }
}
