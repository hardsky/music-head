using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;

public partial class Lyric : JamPage
{
    public Lyric()
    {
        m_Code = 21;
    }

    private string LID
    {
        get
        {
            return (string)ViewState["LID"];
        }
        set
        {
            ViewState["LID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LID = (string)HttpContext.Current.Items["poem_id"];
            if (!String.IsNullOrEmpty(LID))
            {
                FillForm();
                ctrUserComment.SubjectID = LID;
                ctrUserComment.SubjKind = "lyrics";

                ctrRating.SubjectID = LID;
                ctrRating.SubjKind = "lyrics";

                SetPageTitleDescr(new string[] { 
                                lbTitle.Text, 
                                lbTitle.Text },
                    new string[] { 
                    String.Format("Lyrics. Title: {0}, Author: {1}", lbTitle.Text, hlAuthor.Text), 
                    String.Format("Стихи. Название: {0}, Автор: {1}", lbTitle.Text, hlAuthor.Text) });
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
                MySqlCommand cmd = new MySqlCommand(@"select lyrics.Name, lyrics.Text, userinfo.SiteName as AuthorName from lyrics left outer join userinfo on lyrics.Author=userinfo.Id, usertoband where lyrics.id=?id and lyrics.Deleted=0", con);
                cmd.Parameters.Add("?id", MySqlDbType.UInt64).Value = UInt64.Parse(LID);

                if (UserInfo != null)
                {
                    cmd.CommandText += @" and (lyrics.Author=?UserId or lyrics.Visibility IS NULL or lyrics.Visibility=0 or lyrics.Visibility=1 or 
(lyrics.Visibility=3 and lyrics.BandId=usertoband.BandId and usertoband.UserId=?UserId and usertoband.Deleted=0))";
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                }
                else
                {
                    cmd.CommandText += " and (lyrics.Visibility IS NULL or lyrics.Visibility=0)";
                }

                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        lbTitle.Text = rdr.GetString("Name");
                        hlAuthor.Text = rdr.GetString("AuthorName");
                        hlAuthor.NavigateUrl = "~/folks/" + hlAuthor.Text;
                        tdText.InnerHtml = rdr.GetString("Text");
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "SongWriter", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
