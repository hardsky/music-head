using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Band : JamPage
{
    public Band()
    {
        m_Code = 9;
    }

    private string BandName
    {
        get
        {
            return (string)ViewState["BandName"];
        }
        set
        {
            ViewState["BandName"] = value;
        }
    }

    private string BandId
    {
        get
        {
            return (string)ViewState["BandId"];
        }
        set
        {
            ViewState["BandId"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;
        if (!IsPostBack)
        {
            BandName = (string)HttpContext.Current.Items["name"];

            if (!String.IsNullOrEmpty(BandName))
            {
                try
                {
                    BandName = Uri.UnescapeDataString(BandName);
                    BandName = Utils.SQLEscape(BandName);

                    if (!String.IsNullOrEmpty(BandName))
                    {
                        SetPageTitleDescr(new string[] { 
                                BandName, 
                                BandName },
                            new string[] { 
                                String.Format("Page of music band: {0}", BandName), 
                                String.Format("Страничка группы: {0}", BandName) });

                        FillForm();
                        FillMembers();
                        FillMusic();
                        FillLyrics();
                        FillVideo();
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Band", "Page_Load: " + ex.Message);
                }
            }
        }

        /*
        string sBandName = !String.IsNullOrEmpty(BandName) ? BandName : "";
        ctrBandMenu.m_arMenu = new UIControls_VerticalMenu.MenuItem[] { 
            new UIControls_VerticalMenu.MenuItem(String.Format("~/bands/{0}#info", sBandName), "Информация"),
            new UIControls_VerticalMenu.MenuItem(String.Format("~/bands/{0}#music", sBandName), "Музыка"),
            new UIControls_VerticalMenu.MenuItem(String.Format("~/bands/{0}#lyrics", sBandName), "Стихи"),
            new UIControls_VerticalMenu.MenuItem(String.Format("~/bands/{0}#video", sBandName), "Видео"),
            new UIControls_VerticalMenu.MenuItem(String.Format("~/bands/{0}#contacts", sBandName), "Контакты"),
        };
         */
    }

    private void FillLyrics()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select lyrics.id, lyrics.Name as Title, lyrics.Created,
userinfo.SiteName
from lyrics, userinfo 
where lyrics.BandId=?bid and lyrics.Deleted=0 and lyrics.Author=userinfo.Id", con);
                cmd.Parameters.Add("?bid", MySqlDbType.UInt64).Value = ulong.Parse(BandId);

                if (UserInfo != null)
                {
                    cmd.CommandText += @" and (lyrics.Author=?UserId or lyrics.Visibility IS NULL or lyrics.Visibility=0 or lyrics.Visibility=1 
or (lyrics.Visibility=3 and lyrics.BandId is Not null and 
?UserId in (select UserId from usertoband where usertoband.BandId=lyrics.BandId and usertoband.Deleted=0)))";
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                }
                else
                {
                    cmd.CommandText += " and (lyrics.Visibility IS NULL or lyrics.Visibility=0)";
                }

                cmd.CommandText += " order by lyrics.Created desc, lyrics.Name";

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvLyrics.DataSource = ds;
                gvLyrics.DataBind();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dvLyrics.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Band", "FillLyrics: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillMusic()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select music.Id as MusicId, music.Title, music.Created,
userinfo.SiteName
from music, userinfo 
where music.BandId=?bid and music.Deleted=0 and music.Author=userinfo.Id", con);
                cmd.Parameters.Add("?bid", MySqlDbType.UInt64).Value = ulong.Parse(BandId);

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

                cmd.CommandText += " order by music.Created desc, music.Title";

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvMusic.DataSource = ds;
                gvMusic.DataBind();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dvMusic.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Band", "FillMusic: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Id, Name, Description from bands where Name=?Name and Deleted=0;", con);
                cmd.Parameters.Add("?Name", MySqlDbType.VarChar, 45).Value = BandName;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        BandId = rdr.GetInt64("Id").ToString();
                        lbName.Text = rdr.GetString("Name");
                        lbDescr.Text = rdr.GetString("Description");
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Band", "FillForm: " + ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillMembers()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select ui.SiteName, ub.Comment from userinfo as ui, usertoband as ub where
ui.Deleted = 0 and ub.Deleted=0 and ui.id = ub.UserId and ub.BandId = ?BandId order by SiteName;", con);
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvMembers.DataSource = ds;
                gvMembers.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Band", "FillMembers: " + ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
    private void FillVideo()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select video.Id, video.Title, video.Created,
video.Style, video.Language, video.ImgId,
userinfo.SiteName
from video, userinfo 
where video.BandId=?bid and video.Deleted=0 and video.Author=userinfo.Id
order by video.Created desc, video.Title", con);
                cmd.Parameters.Add("?bid", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvVideo.DataSource = ds;
                gvVideo.DataBind();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dvVideo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Band", "FillVideo: " + ex.Message);
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
            //oVideoFrag.Band = dr["BandName"].ToString();
            oVideoFrag.Author = dr["SiteName"].ToString();
            oVideoFrag.Style = dr["Style"].ToString();
            oVideoFrag.Language = dr["Language"].ToString();

            oVideoFrag.Player.Controls.Add(AddVideoPlayer(dr["Id"].ToString(), dr["ImgId"].ToString()));
        }
    }
    protected void gvVideo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVideo.PageIndex = e.NewPageIndex;
        FillVideo();
    }
    private Control AddVideoPlayer(string sId, string sImgId)
    {
        string sHttpLeftPart = this.Request.Url.GetLeftPart(UriPartial.Authority);
        HyperLink hp = new HyperLink();
        hp.CssClass = "flowplayer";
        hp.NavigateUrl = "~/GetVideo.aspx?id=" + sId;

        Image img = new Image();
        img.ImageUrl = !String.IsNullOrEmpty(sImgId) ? "~/GetImage.aspx?id=" + sImgId : "~/img/video_cover.gif";

        hp.Controls.Add(img);

        return hp;
    }
}
