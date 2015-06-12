using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class Clip : JamPage
{
    public Clip()
    {
        m_Code = 23;
    }

    private string VideoID
    {
        get
        {
            return (string)ViewState["VideoID"];
        }
        set
        {
            ViewState["VideoID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VideoID = (string)HttpContext.Current.Items["clip_id"];
            FillForm();

            ctrUserComment.SubjectID = VideoID;
            ctrUserComment.SubjKind = "video";

            ctrRating.SubjectID = VideoID;
            ctrRating.SubjKind = "video";

            SetPageTitleDescr(new string[] { 
                                lbTitle.Text, 
                                lbTitle.Text },
                new string[] { 
                    String.Format("Video. Title: {0}, Author: {1}", lbTitle.Text, hlAuthor.Text) + (!String.IsNullOrEmpty(lbBand.Text) ? (", Band: " + lbBand.Text) : ""), 
                    String.Format("Клип. Название: {0}, Автор: {1}", lbTitle.Text, hlAuthor.Text) + (!String.IsNullOrEmpty(lbBand.Text) ? (", Группа: " + lbBand.Text) : "") });

        }
    }

    private void FillForm()
    {
        if (!String.IsNullOrEmpty(VideoID))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select
video.Id, video.Title, video.FileName, video.ImgId, video.Description, video.Style, video.Language, userinfo.SiteName as AuthorName, bands.Name as BandName
from video left outer join bands on (video.BandId=bands.Id and bands.Deleted=0), userinfo, usertoband where video.Id=?TrackId and video.Deleted=0 and video.Author=userinfo.Id and userinfo.Deleted=0", con);
                    cmd.Parameters.Add("?TrackId", MySqlDbType.UInt64).Value = UInt64.Parse(VideoID);

                    if (UserInfo != null)
                    {
                        cmd.CommandText += @" and (video.Author=?UserId or video.Visibility IS NULL or video.Visibility=0 or video.Visibility=1 or 
(video.Visibility=3 and video.BandId=usertoband.BandId and usertoband.UserId=?UserId and usertoband.Deleted=0))";
                        cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                    }
                    else
                    {
                        cmd.CommandText += " and (video.Visibility IS NULL or video.Visibility=0)";
                    }

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        if (rdr.Read())
                        {
                            lbTitle.Text = rdr.GetString("Title");
                            lbDescr.Text = rdr.IsDBNull(rdr.GetOrdinal("Description")) ? "" : rdr.GetString("Description");
                            trDescr.Visible = !String.IsNullOrEmpty(lbDescr.Text);
                            lbStyle.Text = rdr.IsDBNull(rdr.GetOrdinal("Style")) ? "" : rdr.GetString("Style");
                            trStyle.Visible = !String.IsNullOrEmpty(lbStyle.Text);
                            hlAuthor.Text = rdr.GetString("AuthorName");
                            hlAuthor.NavigateUrl = "~/folks/" + hlAuthor.Text;
                            lbBand.Text = rdr.IsDBNull(rdr.GetOrdinal("BandName")) ? "" : rdr.GetString("BandName");
                            trBand.Visible = !String.IsNullOrEmpty(lbBand.Text);
                            lbLang.Text = rdr.IsDBNull(rdr.GetOrdinal("Language")) ? "" : rdr.GetString("Language");
                            trLang.Visible = !String.IsNullOrEmpty(lbLang.Text);
                            phPlayer.Controls.Add(AddPlayer(rdr.GetUInt64("Id").ToString(), rdr.IsDBNull(rdr.GetOrdinal("ImgId")) ? null : rdr.GetUInt64("ImgId").ToString()));
                        }

                        rdr.Close();
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Clip", "FillForm: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
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
}
