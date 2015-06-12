using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class UIControls_ChartMusic : TabControl
{
    public UIControls_ChartMusic()
    {
        m_Code = 46;
        bDoLocalize = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    override public void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select 
music.Id as id, 
music.Title as Title, 
ui.SiteName as ArtName, 
bands.Name as BandName, 
music.Style,  
SUM(rates.Vote) as Rating
from music left outer join (rates, commentsubjtables) on 
(music.Id=rates.SubjId and rates.SubjTableId=commentsubjtables.Id and commentsubjtables.TableName='music') 
left outer join (userinfo as ui) on (music.Author=ui.Id) left outer join bands on music.BandId=bands.Id
where music.Deleted=0 
", con);

                if (UserInfo != null)
                {
                    cmd.CommandText += @" and (music.Author=?UserId or music.Visibility IS NULL or music.Visibility=0 or music.Visibility=1 or 
(music.Visibility=3 and music.BandId is Not null and 
?UserId in (select UserId from usertoband where usertoband.BandId=music.BandId and usertoband.Deleted=0)))";
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                }
                else
                {
                    cmd.CommandText += " and (music.Visibility IS NULL or music.Visibility=0)";
                }

                cmd.CommandText += "group by music.Id order by Rating desc, Title limit 100";

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                rpChartMusic.DataSource = ds;
                rpChartMusic.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "ChartMusic", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
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
    protected void rpChartMusic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LocalizeControls(e.Item.Controls);
        DataRowView drv = (DataRowView)e.Item.DataItem;
        if (drv != null)
        {
            HyperLink hl = e.Item.FindControl("hlComments") as HyperLink;
            if (hl != null)
                hl.Text += " (" + GetCommentsCount(drv["id"]) + ")";
        }
    }

    private string GetCommentsCount(object oId)
    {
        string sCommentsCount = "";
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select count(*) as cnt from comments, commentsubjtables, userinfo 
where comments.SubjId=?SubjId and comments.SubjTableId=commentsubjtables.Id and commentsubjtables.TableName=?SubjKind and comments.Author=userinfo.Id", con);
                cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = oId;
                cmd.Parameters.Add("?SubjKind", MySqlDbType.VarChar, 30).Value = "music";
                sCommentsCount = "0";
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        sCommentsCount = rdr.GetString("cnt");
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "ChartMusic", "GetCommentsCount: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return sCommentsCount;
    }
}
