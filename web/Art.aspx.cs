using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.Security;

namespace Jam
{
    public partial class Art : JamPage
    {
        public Art()
        {
            m_Code = 6;
            bDoLocalize = false;
        }

        private string ArtistName
        {
            get
            {
                return (string)ViewState["ArtistName"];
            }
            set
            {
                ViewState["ArtistName"] = value;
            }
        }

        private UInt64 ArtistUserId
        {
            get
            {
                return ViewState["ArtistUserId"] != null ? Convert.ToUInt64(ViewState["ArtistUserId"]) : 0;
            }
            set
            {
                ViewState["ArtistUserId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Form.Action = Request.RawUrl;
            if (!IsPostBack)
            {
                LocalizeControls();

                ArtistName = (string)HttpContext.Current.Items["name"];
                try
                {
                    ArtistName = Uri.UnescapeDataString(ArtistName);
                    ArtistName = Utils.SQLEscape(ArtistName);

                    if (!String.IsNullOrEmpty(ArtistName))
                    {
                        FillForm();

                        if (UserInfo != null && UserInfo.UIntId > 0 && UserInfo.UIntId == ArtistUserId)
                        {
                            ctrMyMenu.Visible = true;
                            dvLogoutBtn.Visible = true;
                        }
                        else
                        {
                            ctrMyMenu.Visible = false;
                            dvLogoutBtn.Visible = false;
                        }

                        SetPageTitleDescr(new string[] { 
                                ArtistName + "'s page", 
                                ArtistName },
                            new string[] { 
                               ArtistName + "'s page. Lyrics, music and video from " + ArtistName + ".", 
                                "Страничка " + ArtistName +"Здесь собраны стихи, музыка и видео от пользователя " + ArtistName + "." });

                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Art", "Page_Load: " + ex.Message);
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!IsPostBack)
            {
                LocalizeControls();
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            JamTypes.User.ResetUserSession(Session);
            Response.Redirect(Request.RawUrl);
        }

        private void FillForm()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select userinfo.Id, userinfo.UserPicId, userinfo.SiteName, userinfo.Country, 
userinfo.City, userinfo.OwnInfo from userinfo where LOWER(userinfo.SiteName)=?UserName;", con);
                    cmd.Parameters.Add("?UserName", MySqlDbType.VarChar, 45).Value = ArtistName.ToLower();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        if (rdr.Read())
                        {
                            if (rdr.IsDBNull(rdr.GetOrdinal("UserPicId")))
                            {//load defaul pic
                                imgAvatar.ImageUrl = m_sDefaultAvatarUrl;
                            }
                            else
                            {
                                imgAvatar.ImageUrl = "~/GetImage.aspx?id=" + rdr.GetUInt64("UserPicId").ToString();
                            }

                            lbName.Text = rdr.GetString("SiteName");
                            string sInfo = !rdr.IsDBNull(rdr.GetOrdinal("OwnInfo")) ? rdr.GetString("OwnInfo") : null;
                            if (!String.IsNullOrEmpty(sInfo))
                            {
                                dvInfo.Visible = true;
                                HtmlGenericControl hc = new HtmlGenericControl();
                                hc.InnerHtml = sInfo;
                                phInfo.Controls.Add(hc);
                            }
                            else
                            {
                                dvInfo.Visible = false;
                            }

                            string sCountry = !rdr.IsDBNull(rdr.GetOrdinal("Country")) ? rdr.GetString("Country") : null;
                            if (!String.IsNullOrEmpty(sCountry))
                            {
                                dvCountry.Visible = true;
                                lbCountry.Text = sCountry;
                            }
                            else
                            {
                                dvCountry.Visible = false;
                                lbCountry.Text = "";
                            }

                            string sCity = !rdr.IsDBNull(rdr.GetOrdinal("City")) ? rdr.GetString("City") : null;
                            if (!String.IsNullOrEmpty(sCity))
                            {
                                dvCity.Visible = true;
                                lbCity.Text = sCity;
                            }
                            else
                            {
                                dvCity.Visible = false;
                                lbCity.Text = "";
                            }

                            ArtistUserId = rdr.GetUInt64("Id");
                        }
                        rdr.Close();
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Art", "FillForm: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }

                FillArtWays();
                FillArtInstr();
                FillArtStyles();
                FillArtLangs();
                FillLyrics();
                FillMusic();
                FillVideo();
                if (gvVideo.Rows == null || gvVideo.Rows.Count == 0)
                {
                    dvVideo.Visible = false;
                }
                else
                {
                    dvVideo.Visible = true;
                }

                FillBands();
            }
        }

        private void FillArtWays()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select wl.Text as WayName from userways as uw, waylocal as wl where uw.UserId=?UserId and uw.Deleted=0 and wl.WayId=uw.WayId and wl.LangId=?LangId", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = ArtistUserId;
                    cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = LangUId;

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        while (rdr.Read())
                        {
                            lbWays.Text += rdr.GetString("WayName") + ", ";
                        }
                        rdr.Close();

                        lbWays.Text = lbWays.Text.Trim();
                        lbWays.Text = lbWays.Text.TrimEnd(',');

                        dvWays.Visible = !String.IsNullOrEmpty(lbWays.Text);

                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Art", "FillArtWays: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void FillArtInstr()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Instrument from instruments as instr where instr.UserId=?UserId and instr.Deleted=0", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = ArtistUserId;

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        while (rdr.Read())
                        {
                            lbInstruments.Text += rdr.GetString("Instrument") + ", ";
                        }
                        rdr.Close();

                        lbInstruments.Text = lbInstruments.Text.Trim();
                        lbInstruments.Text = lbInstruments.Text.TrimEnd(',');

                        dvInstrs.Visible = !String.IsNullOrEmpty(lbInstruments.Text);

                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Art", "FillArtInstr: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void FillArtStyles()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select StyleName from userstyles as ust where ust.UserId=?UserId", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = ArtistUserId;

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        while (rdr.Read())
                        {
                            lbStyles.Text += rdr.GetString("StyleName") + ", ";
                        }
                        rdr.Close();

                        lbStyles.Text = lbStyles.Text.Trim();
                        lbStyles.Text = lbStyles.Text.TrimEnd(',');

                        dvStyles.Visible = !String.IsNullOrEmpty(lbStyles.Text);

                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Art", "FillArtStyles: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void FillArtLangs()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Language from userlanguages as ul where ul.UserId=?UserId and ul.Deleted=0", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = ArtistUserId;

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        while (rdr.Read())
                        {
                            lbLanguages.Text += rdr.GetString("Language") + ", ";
                        }
                        rdr.Close();

                        lbLanguages.Text = lbLanguages.Text.Trim();
                        lbLanguages.Text = lbLanguages.Text.TrimEnd(',');

                        dvLangs.Visible = !String.IsNullOrEmpty(lbLanguages.Text);

                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Art", "FillArtLangs: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void FillLyrics()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select lyrics.id, lyrics.Name, lyrics.Style, 
lyrics.Language, lyrics.Created, lyrics.Updated, bands.Name as BandName 
from lyrics left outer join (bands) on (lyrics.BandId=bands.Id and bands.Deleted=0) 
where lyrics.Deleted=0 and lyrics.Author = ?AuthorId", con);
                    cmd.Parameters.Add("?AuthorId", MySqlDbType.UInt64).Value = ArtistUserId;

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

                    if (!String.IsNullOrEmpty(LyricsSortExpr))
                    {
                        cmd.CommandText += " order by " + Utils.SQLEscape(LyricsSortExpr) + " " + (LyricsSortDir == SortDirection.Ascending ? "ASC" : "DESC");
                    }

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    rpLyrics.DataSource = ds;
                    rpLyrics.DataBind();

                    dvLyrics.Visible = (ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0);
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Art", "FillLyrics: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        /*
                protected void gvLirics_PageIndexChanging(object sender, GridViewPageEventArgs e)
                {
                    gvLirics.PageIndex = e.NewPageIndex;
                    FillLyrics();
                }
        */
        private void FillMusic()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select 
music.Id, music.Title, music.Style, music.Language, bands.Name as BandName, music.Created, music.Updated  
from music left outer join (bands) on (music.BandId=bands.Id and bands.Deleted=0)
 where music.Deleted=0 and music.Author=?AuthorId", con);
                    cmd.Parameters.Add("?AuthorId", MySqlDbType.UInt64).Value = ArtistUserId;

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

                    if (!String.IsNullOrEmpty(MusicSortExpr))
                    {
                        cmd.CommandText += " order by " + Utils.SQLEscape(MusicSortExpr) + (MusicSortDir == SortDirection.Ascending ? " ASC" : " DESC");
                    }

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    rpMusic.DataSource = ds;
                    rpMusic.DataBind();

                    dvMusic.Visible = (ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0);
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Art", "FillMusic: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private Control AddButtonPlayer(ulong nTrackId)
        {
            string sPlayer = String.Format(@"
<object type='application/x-shockwave-flash' data='{0}' width='17' height='17'>
<param name='movie' value='{0}'>
<img src='noflash.gif' alt='' width='17' height='17'>
</object>
", this.ResolveUrl("~/Player/Button/musicplayer.swf") + "?song_url=" + this.ResolveUrl("~/GetMusic.aspx?id=" + nTrackId));
            HtmlGenericControl hc = new HtmlGenericControl();
            hc.InnerHtml = sPlayer;

            return hc;
        }

        private void FillVideo()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select 
video.Id, video.Title, video.ImgId, video.Style, video.Language, bands.Name as BandName 
from video left outer join bands on (video.BandId=bands.Id and bands.Deleted=0) 
where video.Deleted=0 and video.Author=?AuthorId", con);
                    cmd.Parameters.Add("?AuthorId", MySqlDbType.UInt64).Value = ArtistUserId;

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
                    JamLog.log(JamLog.enEntryType.error, "Art", "FillVideo: " + ex.Message);
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
                oVideoFrag.Band = dr["BandName"].ToString();
                oVideoFrag.Style = dr["Style"].ToString();
                oVideoFrag.Language = dr["Language"].ToString();

                oVideoFrag.Player.Controls.Add(AddVideoPlayer(dr["Id"].ToString(), dr["ImgId"].ToString()));
            }
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

        private void FillBands()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select bands.Id as BandId, bands.Name, bands.Style, bands.Leader as LeaderId, userinfo.SiteName as LeaderName
                from bands, userinfo, usertoband 
where bands.Leader=userinfo.Id and userinfo.Deleted=0 and bands.Deleted=0 and usertoband.UserId=?UserId and usertoband.BandId=bands.Id and usertoband.Deleted=0", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = ArtistUserId;

                    if (!String.IsNullOrEmpty(BandsSortExpr))
                    {
                        cmd.CommandText += " order by " + Utils.SQLEscape(BandsSortExpr) + " " + (BandsSortDir == SortDirection.Ascending ? "ASC" : "DESC");
                    }

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    rpBands.DataSource = ds;
                    rpBands.DataBind();

                    dvBands.Visible = (ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0);
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Art", "FillBands: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /*
        protected void gvBands_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                UInt64 nId = (UInt64)gvBands.DataKeys[e.Row.RowIndex].Values["BandId"];
                Repeater rp_Lang = (Repeater)e.Row.Cells[2].FindControl("rpLang");
                FillBandLang(rp_Lang, nId);
            }
        }

        protected void gvBands_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBands.PageIndex = e.NewPageIndex;
            FillBands();
        }
        /*
        protected void gvArtWays_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvArtWays.PageIndex = e.NewPageIndex;
            FillWays(gvArtWays, ArtistUserId);
        }
        /*
        protected void gvInstruments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInstruments.PageIndex = e.NewPageIndex;
            FillInstr(gvInstruments, ArtistUserId);
        }

        /*
        protected void gvStyles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStyles.PageIndex = e.NewPageIndex;
            FillStyles(gvStyles, ArtistUserId);
        }
        /*
        protected void gvLang_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLang.PageIndex = e.NewPageIndex;
            FillLang(gvLang, ArtistUserId);
        }
         */
        /*
        protected void gvMusic_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMusic.PageIndex = e.NewPageIndex;
            FillMusic();
        }
         */
        protected void gvVideo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVideo.PageIndex = e.NewPageIndex;
            FillVideo();
        }

        private string LyricsSortExpr
        {
            get
            {
                return (string)ViewState["LyricsSortExpr"];
            }
            set
            {
                ViewState["LyricsSortExpr"] = value;
            }
        }

        private SortDirection LyricsSortDir
        {
            get
            {
                return (SortDirection)ViewState["LyricsSortDir"];
            }
            set
            {
                ViewState["LyricsSortDir"] = value;
            }

        }

        protected void gvLirics_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == LyricsSortExpr)
            {
                if (LyricsSortDir == SortDirection.Ascending)
                    e.SortDirection = SortDirection.Descending;
                else
                    e.SortDirection = SortDirection.Ascending;
            }
            LyricsSortExpr = e.SortExpression;
            LyricsSortDir = e.SortDirection;

            FillLyrics();
        }

        private string BandsSortExpr
        {
            get
            {
                return (string)ViewState["BandsSortExpr"];
            }
            set
            {
                ViewState["BandsSortExpr"] = value;
            }
        }

        private SortDirection BandsSortDir
        {
            get
            {
                return (SortDirection)ViewState["BandsSortDir"];
            }
            set
            {
                ViewState["BandsSortDir"] = value;
            }

        }
        protected void gvBands_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == BandsSortExpr)
            {
                if (BandsSortDir == SortDirection.Ascending)
                    e.SortDirection = SortDirection.Descending;
                else
                    e.SortDirection = SortDirection.Ascending;
            }
            BandsSortExpr = e.SortExpression;
            BandsSortDir = e.SortDirection;

            FillBands();
        }
        private string MusicSortExpr
        {
            get
            {
                return (string)ViewState["MusicSortExpr"];
            }
            set
            {
                ViewState["MusicSortExpr"] = value;
            }
        }

        private SortDirection MusicSortDir
        {
            get
            {
                return (SortDirection)ViewState["MusicSortDir"];
            }
            set
            {
                ViewState["MusicSortDir"] = value;
            }

        }
        protected void gvMusic_Sorting(object sender, GridViewSortEventArgs e)
        {

            if (e.SortExpression == MusicSortExpr)
            {
                if (MusicSortDir == SortDirection.Ascending)
                    e.SortDirection = SortDirection.Descending;
                else
                    e.SortDirection = SortDirection.Ascending;
            }
            MusicSortExpr = e.SortExpression;
            MusicSortDir = e.SortDirection;

            FillMusic();
        }

        protected void rpLyrics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Label lbCreated = (Label)e.Item.FindControl("lbRptLyricsCreated");
                DataRowView rv = (DataRowView)e.Item.DataItem;
                DateTime dtCr = (DateTime)rv["Created"];
                if (dtCr != null)
                {
                    lbCreated.Text += (LangEnum == enLang.en ? "Created: " : "Создано: ") + dtCr.Date.ToShortDateString() + " | " + dtCr.TimeOfDay;
                }

                Label lbUpdated = (Label)e.Item.FindControl("lbRptLyricsUpdated");
                DateTime dtUp = (DateTime)rv["Updated"];
                if (dtUp != null)
                {
                    lbUpdated.Text = (LangEnum == enLang.en ? "Updated: " : "Изменено: ") + dtUp.Date.ToShortDateString() + " | " + dtUp.TimeOfDay;
                }
            }
        }

        protected void rpMusic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Label lbCreated = (Label)e.Item.FindControl("lbRptCreated");
                DataRowView rv = (DataRowView)e.Item.DataItem;
                DateTime dtCr = (DateTime)rv["Created"];
                if (dtCr != null)
                {
                    lbCreated.Text = (LangEnum == enLang.en ? "Created: " : "Создано: ") + dtCr.Date.ToShortDateString() + " | " + dtCr.TimeOfDay;
                }

                Label lbUpdated = (Label)e.Item.FindControl("lbRptUpdated");
                DateTime dtUp = (DateTime)rv["Updated"];
                if (dtUp != null)
                {
                    lbUpdated.Text = (LangEnum == enLang.en ? "Updated: " : "Изменено: ") + dtUp.Date.ToShortDateString() + " | " + dtUp.TimeOfDay;
                }

                try
                {
                    PlaceHolder ph = (PlaceHolder)e.Item.FindControl("phButtonPlayer");
                    HiddenField hf = (HiddenField)e.Item.FindControl("hfId");
                    UInt64 nId = UInt64.Parse(hf.Value);
                    ph.Controls.Add(AddButtonPlayer(nId));
                }
                catch
                {
                }
            }
        }

        protected void rpBands_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MySqlConnection con = Utils.GetSqlConnection();
                if (con != null)
                {
                    try
                    {
                        Label lbLangs = (Label)e.Item.FindControl("lbRptLangs");
                        HiddenField hf = (HiddenField)e.Item.FindControl("hfBandId");
                        UInt64 nId = UInt64.Parse(hf.Value);

                        MySqlCommand cmd = new MySqlCommand("select Language from bandlanguages as bl where bl.BandId=?BandId and bl.Deleted=0", con);
                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nId;

                        MySqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                lbLangs.Text += rdr.GetString("Language") + ", ";
                            }
                            rdr.Close();

                            lbLangs.Text = lbLangs.Text.Trim();
                            lbLangs.Text = lbLangs.Text.TrimEnd(',');
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}
