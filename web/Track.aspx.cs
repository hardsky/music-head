using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;

public partial class Track : JamPage
{
    public Track()
    {
        m_Code = 22;
    }

    private string TrackID
    {
        get
        {
            return (string)ViewState["TrackID"];
        }
        set
        {
            ViewState["TrackID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TrackID = (string)HttpContext.Current.Items["song_id"];
            FillForm();

            ctrUserComment.SubjectID = TrackID;
            ctrUserComment.SubjKind = "music";

            ctrRating.SubjectID = TrackID;
            ctrRating.SubjKind = "music";

            SetPageTitleDescr(new string[] { 
                                lbTitle.Text, 
                                lbTitle.Text },
                new string[] { 
                    String.Format("Music. Title: {0}, Author: {1}", lbTitle.Text, hlAuthor.Text) + (!String.IsNullOrEmpty(hlBand.Text) ? (", Band: " + hlBand.Text) : ""), 
                    String.Format("Музыка. Название: {0}, Автор: {1}", lbTitle.Text, hlAuthor.Text) + (!String.IsNullOrEmpty(hlBand.Text) ? (", Группа: " + hlBand.Text) : "") });
        }
    }

    private void AddPlayer(string sSongTitle, string sImgId)
    {
        HtmlGenericControl hcPlayer = new HtmlGenericControl();
        hcPlayer.InnerHtml = String.Format(@"
<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0' width='400' height='15' id='xspf_player' align='middle'>
<param name='allowScriptAccess' value='sameDomain' />
<param name='movie' value='{0}' />
<param name='quality' value='high' />
<param name='bgcolor' value='#e6e6e6' />
<embed src='{0}' quality='high' bgcolor='#e6e6e6' width='400' height='15' name='xspf_player' align='middle' allowScriptAccess='sameDomain' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer' />
</object>
", this.ResolveUrl("~/Player/xspf_player.swf") + "?song_title=" + Uri.EscapeUriString(sSongTitle) + "&song_url=" + this.ResolveUrl("~/GetMusic.aspx?id=" + TrackID) + "&autoload=true" + (!String.IsNullOrEmpty(sImgId) ? "&song_image=" + this.ResolveUrl("~/GetImage.aspx?id=" + sImgId) : ""));

        phPlayer.Controls.Add(hcPlayer);
    }

    private void FillForm()
    {
        if (!String.IsNullOrEmpty(TrackID))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select
music.Title, music.FileName, music.Description, music.Style, music.Language, music.ImgId, userinfo.SiteName as AuthorName, bands.Name as BandName
from music left outer join bands on (music.BandId=bands.Id and bands.Deleted=0), userinfo, usertoband where music.Id=?TrackId and music.Deleted=0 and music.Author=userinfo.Id and userinfo.Deleted=0", con);
                    cmd.Parameters.Add("?TrackId", MySqlDbType.UInt64).Value = UInt64.Parse(TrackID);

                    if (UserInfo != null)
                    {
                        cmd.CommandText += @" and (music.Author=?UserId or music.Visibility IS NULL or music.Visibility=0 or music.Visibility=1 or 
(music.Visibility=3 and music.BandId=usertoband.BandId and usertoband.UserId=?UserId and usertoband.Deleted=0))";
                        cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                    }
                    else
                    {
                        cmd.CommandText += " and (music.Visibility IS NULL or music.Visibility=0)";
                    }

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        string sImgId = null;
                        if (rdr.Read())
                        {
                            lbTitle.Text = rdr.GetString("Title");
							lbDescr.Text = rdr.IsDBNull ( rdr.GetOrdinal ( "Description" ) ) ? "" : rdr.GetString ( "Description" );
							lbStyle.Text = rdr.IsDBNull ( rdr.GetOrdinal ( "Description" ) ) ? "" : rdr.GetString ( "Style" );
                            //lbAuthor.Text = rdr.GetString("AuthorName");
                            hlAuthor.Text = rdr.GetString("AuthorName");
							hlAuthor.NavigateUrl = Jam.JamRouteUrl.PickUp ( "folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "name", hlAuthor.Text } } );
                            //lbBand.Text = rdr.IsDBNull(rdr.GetOrdinal("BandName")) ? "" : rdr.GetString("BandName");
                            hlBand.Text = rdr.IsDBNull(rdr.GetOrdinal("BandName")) ? "" : rdr.GetString("BandName");
                            if (!String.IsNullOrEmpty(hlBand.Text))
                            {
                                trBand.Visible = true;
								hlBand.NavigateUrl = Jam.JamRouteUrl.PickUp ( "band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "name", hlBand.Text } } );
                            }
                            else
                            {
                                trBand.Visible = false;
                            }
                            lbLang.Text = rdr.IsDBNull(rdr.GetOrdinal("Language")) ? "" : rdr.GetString("Language");
                            trLang.Visible = !String.IsNullOrEmpty(lbLang.Text);
                            sImgId = rdr.IsDBNull(rdr.GetOrdinal("ImgId")) ? null : rdr.GetString("ImgId");
                        }

                        rdr.Close();

                        AddPlayer(lbTitle.Text, sImgId);
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Track", "FillForm: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
