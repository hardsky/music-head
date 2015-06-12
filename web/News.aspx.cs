using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class News : JamPage
{
    public News()
    {
        m_Code = 48;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetPageTitleDescr(new string[] { 
                "News archives of music-head.net", 
                "Архив новостей сайта music-head.net" },
                new string[] { 
                    "Site news from administration of music-head.net", 
                    "Новости от администрации music-head.net" });

            FillForm();
        }
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select sn.Id, sn.Title, sn.Created 
from site_news as sn order by sn.Created desc", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                gvNews.DataSource = ds;
                gvNews.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "News", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNews.PageIndex = e.NewPageIndex;
        FillForm();
    }
}
