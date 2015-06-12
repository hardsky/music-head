using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class MyRaider : JamPage
{
    public MyRaider()
    {
        m_Code = 53;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FilForm();
        }
    }

    private void FilForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select af.Id, af.Event_name, af.Event_datetime, af.Who, af.IsBand, 
af.Description, af.Country, af.City, af.Language 
from afisha as af 
where (af.IsBand<>1 and af.Who=?UserId) or 
(af.IsBand=1 and af.Who in (select ba.Id from bands as ba where ba.Leader=?UserId and ba.Deleted=0))", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvAfisha.DataSource = ds;
                gvAfisha.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyRaider", "FillForm: " + ex.Message);
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
                JamLog.log(JamLog.enEntryType.error, "MyRaider", "FillWhoDD: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
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
                JamLog.log(JamLog.enEntryType.error, "MyRaider", "FillBandDD: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        tblEvent.Visible = true;
        btnAdd.Visible = false;
        btnDelete.Visible = false;

        FillWhoDD();
        FillTimeDD();
    }

    private void FillTimeDD()
    {
        ddHour.Items.Clear();
        for (int i = 0; i < 24; i++)
        {
            ddHour.Items.Add(new ListItem(String.Format("{0:D2}", i), i.ToString()));
        }

        ddMinute.Items.Clear();
        for (int i = 0; i < 60; i++)
        {
            ddMinute.Items.Add(new ListItem(String.Format("{0:D2}", i), i.ToString()));
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        List<ulong> lstIds = new List<ulong>();
        foreach (GridViewRow row in gvAfisha.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("chSelected");
            if (cb.Checked)
            {
                UInt64 nId = (UInt64)gvAfisha.DataKeys[row.RowIndex].Values["Id"];
                lstIds.Add(nId);
            }
        }

        if (lstIds.Count > 0)
        {
            DeleteAfisha(lstIds);
        }

        Response.Redirect("~/MyRaider.aspx");
    }

    private void DeleteAfisha(List<ulong> lstIds)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("delete from afisha where id in (", con);
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
                JamLog.log(JamLog.enEntryType.error, "MyRaider", "DeleteAfisha: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sName = tbEvent.Text.Trim();
        string sDescr = tbDescription.Text.Trim();
        string sCountry = tbCountry.Text.Trim();
        string sCity = tbCity.Text.Trim();
        string sLang = tbLanguage.Text.Trim();

        if (String.IsNullOrEmpty(sName) || String.IsNullOrEmpty(sDescr))
            return;

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                DateTime dt = new DateTime(ctrCalendar.SelectedDate.Year, ctrCalendar.SelectedDate.Month, 
                    ctrCalendar.SelectedDate.Day, int.Parse(ddHour.SelectedValue), int.Parse(ddMinute.SelectedValue), 0);
                bool bIsBand = int.Parse(ddWho.SelectedValue) != 0;
                ulong WhoId = bIsBand ? ulong.Parse(ddBand.SelectedValue) : UserInfo.UIntId;

                MySqlCommand cmd = new MySqlCommand(@"insert into afisha 
(Event_Name, Description, Event_datetime, Who, IsBand, Created, AuthorId, Country, City, Language) 
values(?Name, ?Descr, ?EDate, ?Who, ?IsBand, UTC_TIMESTAMP(), ?UserId, ?Country, ?City, ?Language)", con);
                cmd.Parameters.Add("?Name", MySqlDbType.VarChar, 128).Value = sName;
                cmd.Parameters.Add("?Descr", MySqlDbType.VarChar, 512).Value = sDescr;
                cmd.Parameters.Add("?EDate", MySqlDbType.DateTime).Value = dt;
                cmd.Parameters.Add("?Who", MySqlDbType.UInt64).Value = WhoId;
                cmd.Parameters.Add("?IsBand", MySqlDbType.Bit).Value = bIsBand;
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?Country", MySqlDbType.VarChar, 80).Value = sCountry;
                cmd.Parameters.Add("?City", MySqlDbType.VarChar, 80).Value = sCity;
                cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = sLang;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyRaider", "btnSave_Click: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        Response.Redirect("~/MyRaider.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        tblEvent.Visible = false;
        btnAdd.Visible = true;
        btnDelete.Visible = true;
    }

    protected void ctrCalendar_SelectionChanged(object sender, EventArgs e)
    {
        lbDate.Text = ctrCalendar.SelectedDate.ToShortDateString();
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

    protected void dvAfisha_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            object oId = gvAfisha.DataKeys[e.Row.RowIndex].Values["Id"];
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

                    if(!String.IsNullOrEmpty(sBandName))
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

                    DataRowView drw = (DataRowView)e.Row.DataItem;
                    AppendToolTip(e.Row, drw["Country"]);
                    AppendToolTip(e.Row, drw["City"]);
                    AppendToolTip(e.Row, drw["Language"]);
                    e.Row.ToolTip = e.Row.ToolTip.TrimEnd();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyRaider", "dvAfisha_RowDataBound: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }

    private void AppendToolTip(GridViewRow rw, object p)
    {
        try
        {
            rw.ToolTip += Convert.ToString(p);
            if (!String.IsNullOrEmpty(rw.ToolTip))
                rw.ToolTip += " ";
        }
        catch
        {
        }
    }
}
