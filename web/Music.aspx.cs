using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

public partial class Music : JamPage
{
    public Music()
    {
        m_Code = 12;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*
<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0" width="400" height="170" id="xspf_player" align="middle">
<param name="allowScriptAccess" value="sameDomain" />
<param name="movie" value="/web/Player/xspf_player.swf?playlist_url=http://localhost:3709/web/Player/playlistlist.xspf&autoload=true" />
<param name="quality" value="high" />
<param name="bgcolor" value="#e6e6e6" />
<embed src="/web/Player/xspf_player.swf?playlist_url=http://localhost:3709/web/Player/playlistlist.xspf&autoload=true" quality="high" bgcolor="#e6e6e6" width="400" height="170" name="xspf_player" align="middle" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
</object>
             */
            FillForm();

            SetPageTitleDescr(new string[] { 
                                "Music", 
                                "Музыка" },
                new string[] { 
                    "Music from musicians on music-head.", 
                    "Музыка от музыкантов на music-head."});
        }

        ctrFinder.onFindBtnClick = btnFind_Click;
    }

    private Control AddButtonPlayer(ulong nTrackId)
    {
        /*
<object type="application/x-shockwave-flash" data="http://musicplayer.sourceforge.net/button/musicplayer.swf?&amp;playlist_url=?playlist_url=allshows.xspf&amp;" width="17" height="17">
<param name="movie" value="http://musicplayer.sourceforge.net/button/musicplayer.swf?&amp;playlist_url=?playlist_url=allshows.xspf&amp;">
<img src="noflash.gif" alt="" width="17" height="17">
</object>
         */
        string sPlayer = String.Format(@"
<object type='application/x-shockwave-flash' data='{0}' width='17' height='17'>
<param name='movie' value='{0}'>
<img src='noflash.gif' alt='' width='17' height='17'>
</object>
", this.ResolveUrl("~/Player/Button/musicplayer.swf") + "?song_url=" + this.ResolveUrl("~/GetMusic.aspx?id=" + nTrackId));//this.ResolveUrl("~/Music/") + Uri.EscapeUriString(sFileName));
        HtmlGenericControl hc = new HtmlGenericControl();
        hc.InnerHtml = sPlayer;

        return hc;
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select 
music.Id, music.Title, music.Style, music.Language, music.Created, music.Updated, userinfo.SiteName as AuthorName, bands.Name as BandName  
from music left outer join (bands) on (music.BandId=bands.Id and bands.Deleted=0)
, userinfo where music.Deleted=0 and music.Author=userinfo.Id and userinfo.Deleted=0", con);

                if (!String.IsNullOrEmpty(ctrFinder.Name))
                {
                    cmd.CommandText += " and LOWER(music.Title) like ?Title";
                    cmd.Parameters.Add("?Title", MySqlDbType.VarChar, 100).Value = ctrFinder.Name;
                }

                if (!String.IsNullOrEmpty(ctrFinder.Style))
                {
                    cmd.CommandText += " and LOWER(music.Style)=?Style";
                    cmd.Parameters.Add("?Style", MySqlDbType.VarChar, 80).Value = ctrFinder.Style;
                }

                if (!String.IsNullOrEmpty(ctrFinder.Lang))
                {
                    cmd.CommandText += " and LOWER(music.Language)=?Language";
                    cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = ctrFinder.Lang;
                }

                if (!String.IsNullOrEmpty(ctrFinder.Author))
                {
                    cmd.CommandText += " and LOWER(userinfo.SiteName) like ?SiteName";
                    cmd.Parameters.Add("?SiteName", MySqlDbType.VarChar, 45).Value = ctrFinder.Author;
                }

                if (!String.IsNullOrEmpty(ctrFinder.Band))
                {
                    cmd.CommandText += " and LOWER(bands.Name) like ?BandName";
                    cmd.Parameters.Add("?BandName", MySqlDbType.VarChar, 45).Value = ctrFinder.Band;
                }

                if (UserInfo != null)
                {
                    cmd.CommandText += @" and (music.Author=?UserId or music.Visibility IS NULL or music.Visibility=0 or music.Visibility=1 or 
(music.Visibility=3 and music.BandId is not null and 
?UserId in (select UserId from usertoband where usertoband.BandId=music.BandId and usertoband.Deleted=0)))";
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                }
                else
                {
                    cmd.CommandText += " and (music.Visibility IS NULL or music.Visibility=0)";
                }

                if (!String.IsNullOrEmpty(SortExpr))
                {
                    string sTmp  = SortExpr.ToLower();
                    cmd.CommandText += " order by " + ((sTmp == "updated" || sTmp == "created")? SortExpr : Utils.SQLEscape(SortExpr)) + (SortDir == SortDirection.Ascending ? " ASC" : " DESC");
                }

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvMusic.DataSource = ds;
                gvMusic.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Music", "FillGrid: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void gvMusic_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            PlaceHolder ph = (PlaceHolder)e.Row.Cells[6].FindControl("phButtonPlayer");
            UInt64 nId = (UInt64)gvMusic.DataKeys[e.Row.RowIndex].Values["Id"];
            ph.Controls.Add(AddButtonPlayer(nId));

            DataRowView drv = (DataRowView)e.Row.DataItem;
            object oCr = drv["Created"];
            if (oCr != null && oCr != DBNull.Value && UserInfo != null)
            {
                DateTime dt = (DateTime)oCr;
                e.Row.Cells[5].Text = (dt + UserInfo.TimeZone).ToString("dd.MM.yyyy");
            }
        }
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        FillForm();
    }
    protected void gvMusic_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        gvMusic.PageIndex = e.NewSelectedIndex;
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

    protected void gvMusic_Sorting(object sender, GridViewSortEventArgs e)
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
}
