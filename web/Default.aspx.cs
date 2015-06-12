using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class _Default : JamPage
{
    public _Default()
    {
        m_Code = 38;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetPageTitleDescr(new string[] { "music-head.net: Site for musicians, poets and music fans.", "music-head.net: Сайт для музыкантов, поэтов и всех, кто любит музыку." },
                new string[] { "Social networking site for people, who like music.", "Музыкальная социальная сеть для всех, кто любит музыку." });
            FillSiteNews();
            FillAfisha();
            FillAfishaNow();
            FillUserNews();
        }
    }

    private void FillUserNews()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Created, News_Text from news order by Created desc limit 5", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                rpNews.DataSource = ds;
                rpNews.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "_Default", "FillUserNews: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillAfishaNow()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select Id, Event_name, Description, Event_datetime, Who, IsBand from afisha 
where DATE(Event_datetime) = DATE(NOW()) order by Event_datetime desc limit 3", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                rpAfishaNow.DataSource = ds;
                rpAfishaNow.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "_Default", "FillAfishaNow: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillAfisha()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select Id, Event_name, Event_datetime, Who, IsBand from afisha 
where DATE(Event_datetime) > DATE(NOW()) order by Event_datetime desc limit 5", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                rpAfisha.DataSource = ds;
                rpAfisha.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "_Default", "FillAfisha: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillSiteNews()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                ulong nNid = 0;
                MySqlCommand cmd = new MySqlCommand(@"select tblMain.Id, tblMain.Title, tblMain.News_Text, 
tblMain.AuthorName, tblCommentCnt.comment_cnt
from
(select sn.Id, sn.Title, sn.News_Text, 
ui.SiteName as AuthorName 
from site_news as sn, userinfo as ui where sn.LangId=?LangId and sn.Author=ui.Id order by sn.Created desc limit 1) as tblMain 
left outer join (select comments.SubjId,
count(*) as comment_cnt 
from comments, commentsubjtables
where comments.SubjTableId=commentsubjtables.Id and 
commentsubjtables.TableName=?SubjTbl
group by comments.SubjId) as tblCommentCnt on tblCommentCnt.SubjId = tblMain.Id
", con);
                cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = LangUId;
                cmd.Parameters.Add("?SubjTbl", MySqlDbType.VarChar).Value = "sitenews";
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        hSiteNewsTitle.InnerText = rdr.GetString("Title");
                        dvSiteNewsText.InnerHtml = rdr.GetString("News_Text");
                        hlSiteNewsAuthor.Text = rdr.GetString("AuthorName");
						hlSiteNewsAuthor.NavigateUrl = Jam.JamRouteUrl.PickUp ( "folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "name", hlSiteNewsAuthor.Text } } );
                        nNid = rdr.GetUInt64("Id");
						hlComment.NavigateUrl = Jam.JamRouteUrl.PickUp ( "news_issue", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "id", nNid.ToString() } } );
                        if (!rdr.IsDBNull(rdr.GetOrdinal("comment_cnt")))
                            hlComment.Text = rdr.GetInt32("comment_cnt").ToString();
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "_Default", "FillSiteNews: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void rpAfisha_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbDate = e.Item.FindControl("lbAfishaDate") as Label;
            if (lbDate != null)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                DateTime dt = (DateTime)drv["Event_datetime"];
                lbDate.Text = dt.ToString("dd.MM");
            }

            HyperLink hlWho = e.Item.FindControl("hlWho") as HyperLink;
            if (hlWho != null)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                bool bIsBand = Convert.ToBoolean(drv["IsBand"]);                
                if (bIsBand)
                {
                    string sBandName = GetBandName((ulong)drv["Who"]);
                    hlWho.Text = sBandName;
                    hlWho.NavigateUrl = Jam.JamRouteUrl.PickUp("band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", sBandName } });//"~/bands/" + sBandName;
                }
                else
                {
                    string sManName = GetManName((ulong)drv["Who"]);
                    hlWho.Text = sManName;
                    hlWho.NavigateUrl = Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", sManName } });//"~/folks/" + sManName;
                }
            }
        }
    }

    private string GetManName(ulong nId)
    {
        string sManName = "";
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select SiteName from userinfo where Id=?Id", con);
                cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = nId;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        sManName = rdr.GetString("SiteName");
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "_Default", "GetManName: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return sManName;
    }

    private string GetBandName(ulong nId)
    {
        string sBandName = "";
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Name from bands where Id=?Id", con);
                cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = nId;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        sBandName = rdr.GetString("Name");
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "_Default", "GetBandName: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return sBandName;
    }
    protected void rpAfishaNow_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink hlWho = e.Item.FindControl("hlNowWho") as HyperLink;
            if (hlWho != null)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                bool bIsBand = Convert.ToBoolean(drv["IsBand"]);
                if (bIsBand)
                {
                    string sBandName = GetBandName((ulong)drv["Who"]);
                    hlWho.Text = sBandName;
					hlWho.NavigateUrl = Jam.JamRouteUrl.PickUp ( "band", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "name", sBandName } } );
                }
                else
                {
                    string sManName = GetManName((ulong)drv["Who"]);
                    hlWho.Text = sManName;
					hlWho.NavigateUrl = Jam.JamRouteUrl.PickUp ( "folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "name", sManName } } );
                }
            }

            Label lbDescr = e.Item.FindControl("lbNowEvent") as Label;
            if (lbDescr != null)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                lbDescr.Text = drv["Description"].ToString();
            }
        }
    }
    protected void rpNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbDate = e.Item.FindControl("lbNewsDate") as Label;
            if (lbDate != null)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                lbDate.Text = ((DateTime)drv["Created"]).ToString("dd.MM");
            }

            Label lbNews = e.Item.FindControl("lbNewsText") as Label;
            if(lbNews != null)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                lbNews.Text = drv["News_Text"].ToString();
            }
        }
    }
}
