using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;

public partial class Video : JamPage
{
    /*
	<a class="flowplayer" href="http://localhost:3709/web/Video/5/a879bc39-80c9-4e50-bd53-2854f5a5fbbd_five.flv">
	<img src="img/2m.jpg" />
	</a>                
     */
    public Video()
    {
        m_Code = 200;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillForm();

            SetPageTitleDescr(new string[] { 
                                "Video", 
                                "Клипы" },
                new string[] { 
                    "Video from users of music-head.", 
                    "Клипы пользователей music-head."});
        }

        ctrFinder.onFindBtnClick = VideoFind;
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select 
video.Id, video.Title, video.ImgId, video.Style, video.Language, userinfo.SiteName as AuthorName, bands.Name as BandName 
from video left outer join bands on (video.BandId=bands.Id and bands.Deleted=0) 
,userinfo where video.Deleted=0 and video.Author=userinfo.Id", con);

                if (!String.IsNullOrEmpty(ctrFinder.Name))
                {
                    cmd.CommandText += " and LOWER(video.Title) like ?Title";
                    cmd.Parameters.Add("?Title", MySqlDbType.VarChar, 100).Value = ctrFinder.Name;
                }

                if (!String.IsNullOrEmpty(ctrFinder.Style))
                {
                    cmd.CommandText += " and LOWER(video.Style)=?Style";
                    cmd.Parameters.Add("?Style", MySqlDbType.VarChar, 80).Value = ctrFinder.Style;
                }

                if (!String.IsNullOrEmpty(ctrFinder.Lang))
                {
                    cmd.CommandText += " and LOWER(video.Language)=?Language";
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
                    cmd.CommandText += @" and (video.Author=?UserId or video.Visibility IS NULL or video.Visibility=0 or video.Visibility=1 or 
(video.Visibility=3 and video.BandId is not null and 
?UserId in (select UserId from usertoband where usertoband.BandId=video.BandId and usertoband.Deleted=0)))";
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                }
                else
                {
                    cmd.CommandText += " and (video.Visibility IS NULL or video.Visibility=0)";
                }

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvVideo.DataSource = ds;
                gvVideo.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Video", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void gvVideo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            UIControls_VideoFragment oVideoFrag = (UIControls_VideoFragment)e.Row.Cells[0].Controls[1];
            DataRowView dr = (DataRowView)e.Row.DataItem;
            oVideoFrag.ClipId = dr["Id"].ToString();
            oVideoFrag.Title = dr["Title"].ToString();
            oVideoFrag.Author = dr["AuthorName"].ToString();
            oVideoFrag.Band = dr["BandName"].ToString();
            oVideoFrag.Style = dr["Style"].ToString();
            oVideoFrag.Language = dr["Language"].ToString();

            oVideoFrag.Player.Controls.Add(AddPlayer(dr["Id"].ToString(), dr["ImgId"].ToString()));
        }
    }

    private Control AddPlayer(string sId, string sImgId)
    {
        string sHttpLeftPart = this.Request.Url.GetLeftPart(UriPartial.Authority);
        StringBuilder sb = new StringBuilder(150);
        sb.AppendFormat("<a class=\"flowplayer\" href=\"{0}{1}\">", sHttpLeftPart, this.ResolveUrl("~/GetVideo.aspx?id=" + sId));
        sb.AppendFormat("<img src=\"{0}\">", !String.IsNullOrEmpty(sImgId) ? sHttpLeftPart + this.ResolveUrl("~/GetImage.aspx?id=" + sImgId) : "./img/video_cover.gif");
        sb.Append("</a>");

        HtmlGenericControl hc = new HtmlGenericControl();
        hc.InnerHtml = sb.ToString();

        return hc;
    }

    private void VideoFind(object sender, EventArgs e)
    {
        FillForm();
    }
    protected void gvVideo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        gvVideo.PageIndex = e.NewSelectedIndex;
        FillForm();
    }
}
