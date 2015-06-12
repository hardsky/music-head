using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class WriteSiteNews : JamPage
{
    public WriteSiteNews()
    {
        m_Code = 55;
    }

    private string NewsId
    {
        get
        {
            return (string)ViewState["NewsId"];
        }
        set
        {
            ViewState["NewsId"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo == null || !UserInfo.IsAdmin)
        {
            this.Visible = false;
            return;
        }

        if (!IsPostBack)
        {
            FillDDLang();
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
                MySqlCommand cmd = new MySqlCommand("select sn.Id, sn.Title, sl.Text as Lang, sn.Created from site_news as sn, site_language as sl where sn.LangId=sl.Id order by sn.Created desc", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvNews.DataSource = ds;
                gvNews.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "WriteSiteNews", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillDDLang()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Id, Text from site_language order by Text", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                ddLang.DataSource = ds;
                ddLang.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "WriteSiteNews", "FillDDLang: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        tblMain.Visible = true;
        btnAdd.Visible = false;
        btnDelete.Visible = false;
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        tblMain.Visible = false;
        btnAdd.Visible = true;
        btnDelete.Visible = true;
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(NewsId))
        {
            Update();
        }
        else
        {
            Insert();
        }

        Response.Redirect("~/WriteSiteNews.aspx");
    }

    private void Insert()
    {
        string sTitle = tbTitle.Text.Trim();
        string sText = ctrEditor.Content.Trim();
        if (String.IsNullOrEmpty(sTitle) || String.IsNullOrEmpty(sText))
            return;

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"insert into site_news (Title, News_Text, LangId, Author, Created, Updated) 
values (?title, ?news_text, ?langId, ?userId, ?upd, ?upd)", con);
                cmd.Parameters.Add("?title", MySqlDbType.VarChar, 128).Value = sTitle;
                cmd.Parameters.Add("?news_text", MySqlDbType.VarChar, 512).Value = sText;
                cmd.Parameters.Add("?langId", MySqlDbType.UInt64).Value = UInt64.Parse(ddLang.SelectedValue);
                cmd.Parameters.Add("?userId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?upd", MySqlDbType.DateTime).Value = DateTime.UtcNow;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "WriteSiteNews", "Insert: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void Update()
    {
        string sTitle = tbTitle.Text.Trim();
        string sText = ctrEditor.Content.Trim();
        if (String.IsNullOrEmpty(sTitle) || String.IsNullOrEmpty(sText))
            return;

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"update site_news set 
Title=?title,
News_Text=?news_text,
LangId=?langId,
Updated=UTC_TIMESTAMP() 
where Id=?id", con);
                cmd.Parameters.Add("?title", MySqlDbType.VarChar, 128).Value = sTitle;
                cmd.Parameters.Add("?news_text", MySqlDbType.VarChar, 512).Value = sText;
                cmd.Parameters.Add("?langId", MySqlDbType.UInt64).Value = UInt64.Parse(ddLang.SelectedValue);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "WriteSiteNews", "Update: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
