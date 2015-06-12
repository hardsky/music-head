using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class MyNews : JamPage
{
    public MyNews()
    {
        m_Code = 54;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
                MySqlCommand cmd = new MySqlCommand(@"select news.Id, news.Who, news.IsBand, news.Created, news.Title, news.News_Text from news where 
(news.IsBand=0 and news.Who=?UserId) or 
(news.IsBand=1 and news.Who in (select ba.Id from bands as ba where ba.Leader=?UserId and ba.Deleted=0))", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvNews.DataSource = ds;
                gvNews.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyNews", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        tblNews.Visible = false;
        btnAdd.Visible = true;
        btnDelete.Visible = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        tblNews.Visible = true;
        btnAdd.Visible = false;
        btnDelete.Visible = false;

        FillWhoDD();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        List<ulong> lstIds = new List<ulong>();
        foreach (GridViewRow row in gvNews.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("chSelected");
            if (cb.Checked)
            {
                UInt64 nId = (UInt64)gvNews.DataKeys[row.RowIndex].Values["Id"];
                lstIds.Add(nId);
            }
        }

        if (lstIds.Count > 0)
        {
            DeleteNews(lstIds);
        }

        Response.Redirect("~/MyNews.aspx");
    }

    private void DeleteNews(List<ulong> lstIds)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from news where id in (", con);
                foreach (ulong nId in lstIds)
                {
                    cmd.CommandText += "'" + nId + "',";
                }

                cmd.CommandText = cmd.CommandText.TrimEnd(',');
                cmd.CommandText += ")";

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyNews", "DeleteNews: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillWhoDD()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                ddWho.Items.Clear();
                ddWho.Items.Add(new ListItem(LangEnum == enLang.ru ? "Я" : "Me", "0"));
                MySqlCommand cmd = new MySqlCommand(@"select bands.Id from bands, usertoband as ub 
where bands.Leader=?userId and ub.UserId=bands.Leader and ub.Deleted=0 and bands.Id=ub.BandId and bands.Deleted=0", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("Id")))
                        {
                            ddWho.Items.Add(new ListItem(LangEnum == enLang.ru ? "Группа" : "Band", "1"));
                        }
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyNews", "FillWhoDD: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void ddWho_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddWho.SelectedValue == "1") //band
        {
            tblBand.Visible = true;
            FillBandDD();
        }
        else
        {
            tblBand.Visible = false;
        }
    }
    private void FillBandDD()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select bands.Id, bands.Name from bands, usertoband as ub 
where bands.Leader=?UserId and ub.UserId=bands.Leader and ub.Deleted=0 and bands.Id=BandId and bands.Deleted=0", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                ddBand.Items.Clear();

                ddBand.DataSource = ds;
                ddBand.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyNews", "FillBandDD: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sTitle = tbTitle.Text.Trim();
        string sText = tbText.Text.Trim();
        if (String.IsNullOrEmpty(sTitle) || String.IsNullOrEmpty(sText))
            return;

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                bool bIsBand = int.Parse(ddWho.SelectedValue) != 0;
                ulong WhoId = bIsBand ? ulong.Parse(ddBand.SelectedValue) : UserInfo.UIntId;

                MySqlCommand cmd = new MySqlCommand(@"insert into news 
(Author, Created, Title, News_Text, IsBand, Who) 
values(?UserId, UTC_TIMESTAMP(), ?Title, ?Text, ?IsBand, ?Who)", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?Title", MySqlDbType.VarChar, 128).Value = sTitle;
                cmd.Parameters.Add("?Text", MySqlDbType.VarChar, 255).Value = sText;
                cmd.Parameters.Add("?IsBand", MySqlDbType.Bit).Value = bIsBand;
                cmd.Parameters.Add("?Who", MySqlDbType.UInt64).Value = WhoId;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyNews", "btnSave_Click: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        Response.Redirect("~/MyNews.aspx");
    }

    protected void gvNews_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            object oId = gvNews.DataKeys[e.Row.RowIndex].Values["Id"];
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select ba.Name from bands as ba, afisha as af 
where af.Id=?Id and af.IsBand=1 and af.Who=ba.Id and ba.Deleted=0", con);
                    cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = oId;
                    string sBandName = null;
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        if (rdr.Read())
                        {
                            if (!rdr.IsDBNull(rdr.GetOrdinal("Name")))
                            {
                                sBandName = rdr.GetString("Name");
                            }
                        }
                        rdr.Close();
                    }

                    if (!String.IsNullOrEmpty(sBandName))
                    {
                        Control lb = e.Row.Cells[3].FindControl("lbWho");
                        lb.Visible = false;

                        HyperLink hlWho = e.Row.Cells[3].FindControl("hlWho") as HyperLink;
                        hlWho.Visible = true;
                        hlWho.Text = sBandName;
                        hlWho.NavigateUrl = "~/bands/" + hlWho.Text;
                    }
                    else
                    {
                        Label lb = e.Row.Cells[3].FindControl("lbWho") as Label;
                        lb.Visible = true;
                        lb.Text = LangEnum == enLang.ru ? "Я" : "Me";
                        Control hlWho = e.Row.Cells[3].FindControl("hlWho");
                        hlWho.Visible = false;
                    }

                    DataRowView drv = e.Row.DataItem as DataRowView;
                    e.Row.ToolTip = (string)drv["News_Text"];

                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyNesw", "gvNews_RowDataBound: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
