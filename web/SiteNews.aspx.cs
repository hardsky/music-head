using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;

public partial class SiteNews : JamPage
{
    public string NID
    {
        get
        {
            return (string)ViewState["NID"];
        }
        set
        {
            ViewState["NID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
			NID = (string) HttpContext.Current.Items [ "id" ];
            if (!String.IsNullOrEmpty(NID))
            {
                FillForm();
                ctrUserComment.SubjectID = NID;
                ctrUserComment.SubjKind = "sitenews";

                SetPageTitleDescr(new string[] { 
                lbLabelTitle.Text, 
                lbLabelTitle.Text},
                    new string[] { 
                    String.Format("Title: {0}, Author: {1}, Date: {2}", lbLabelTitle.Text, lbLabelAuthor.Text, lbLabelDate.Text), 
                    String.Format("Заголовок: {0}, Автор: {1}, Дата: {2}", lbLabelTitle.Text, lbLabelAuthor.Text, lbLabelDate.Text) });
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
                MySqlCommand cmd = new MySqlCommand(@"select sn.Id, sn.Title, sn.News_Text, sn.Created, 
ui.SiteName as AuthorName 
from site_news as sn, userinfo as ui where sn.Id=?NID and sn.Author=ui.Id", con);
                cmd.Parameters.Add("?NID", MySqlDbType.UInt64).Value = ulong.Parse(NID);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        lbLabelTitle.Text = rdr.GetString("Title");
                        lbLabelAuthor.Text = rdr.GetString("AuthorName");
                        dvText.InnerHtml = rdr.GetString("News_Text");
                        lbLabelDate.Text = (rdr.GetDateTime("Created") + (UserInfo != null ? UserInfo.TimeZone : TimeSpan.Zero)).ToString();
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "SiteNews", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
