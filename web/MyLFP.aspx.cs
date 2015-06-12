using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class MyLFP : JamPage
{
    public MyLFP()
    {
        m_Code = 50;
        bDoLocalize = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillForm();
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        if (!IsPostBack)
        {
            LocalizeControls();
        }
    }
    private void FillForm()
    {
        FillGrid();
        FillDD();
    }

    private void FillDD()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Id, Name from bands where Leader=?UserID", con);
                cmd.Parameters.Add("?UserID", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                ddBand.DataSource = ds;
                ddBand.DataBind();

                if (ddBand.Items != null && ddBand.Items.Count > 0)
                {
                    trBand.Visible = true;
                    ddBand.Items.Insert(0, "");
                }
                else
                {
                    trBand.Visible = false;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyLFP", "FillDD: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillGrid()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select lp.Id, lp.LookingFor, lp.Comment, bands.Name as BandName 
from looking_people as lp, bands where lp.Creater=?UserId and bands.Id=lp.BandId order by lp.Created", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
                {
                    rpSeachedMembers.Visible = true;
                    btnDelete.Visible = true;

                    rpSeachedMembers.DataSource = ds;
                    rpSeachedMembers.DataBind();
                }
                else
                {
                    rpSeachedMembers.Visible = false;
                    btnDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyLFP", "FillGrid: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void ddBand_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBandProps(ddBand.SelectedValue);
    }

    private void FillBandProps(string sBandId)
    {
        ddLangs.Items.Clear();
        tbCountry.Text = "";
        tbCity.Text = "";
        tbLooking.Text = "";
        tbComment.Text = "";
        tblDetails.Visible = false;

        if (!String.IsNullOrEmpty(sBandId))
        {
            tblDetails.Visible = true;
            btnDelete.Visible = false;
            trBand.Visible = false;

            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Id, Language from bandlanguages where BandId=?BandId", con);
                    cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(sBandId);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    ddLangs.DataSource = ds;
                    ddLangs.DataBind();

                    if (ddLangs.Items != null && ddLangs.Items.Count > 0)
                    {

                        ddLangs.Items.Insert(0, "");

                        ddLangs.Visible = true;
                        lbLang.Visible = false;
                    }
                    else
                    {
                        ddLangs.Visible = false;
                        lbLang.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyLFP", "FillBandProps: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        bool bRes = false;

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"insert into looking_people (BandId, Country, City, Language, LookingFor, Comment, Created, Creater) 
values(?BandId, ?Country, ?City, ?Language, ?LookingFor, ?Comment, UTC_TIMESTAMP(), ?UserId)", con);
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(ddBand.SelectedValue);
                string sCountry = Utils.SQLEscape(tbCountry.Text.Trim());
                cmd.Parameters.Add("?Country", MySqlDbType.VarChar, 80).Value = String.IsNullOrEmpty(sCountry) ? null : sCountry;
                string sCity = Utils.SQLEscape(tbCity.Text.Trim());
                cmd.Parameters.Add("?City", MySqlDbType.VarChar, 80).Value = String.IsNullOrEmpty(sCity) ? null : sCity;
                string sLang = Utils.SQLEscape(ddLangs.SelectedValue.Trim());
                cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = String.IsNullOrEmpty(sLang) ? null : sLang;
                string sLooking = Utils.SQLEscape(tbLooking.Text.Trim());
                cmd.Parameters.Add("?LookingFor", MySqlDbType.VarChar, 80).Value = String.IsNullOrEmpty(sLooking) ? null : sLooking;
                string sComment = Utils.SQLEscape(tbComment.Text.Trim());
                cmd.Parameters.Add("?Comment", MySqlDbType.VarChar, 255).Value = String.IsNullOrEmpty(sComment) ? null : sComment;
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                cmd.ExecuteNonQuery();

                bRes = true;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyLFP", "btnAdd_Click: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            if (bRes)
            {
                Response.Redirect("~/MyLFP.aspx");
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string sIds = "";
        foreach (RepeaterItem item in rpSeachedMembers.Items)
        {
            if ((item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem))
            {
                CheckBox cb = item.FindControl("cbSelected") as CheckBox;
                if (cb != null && cb.Checked)
                {
                    HiddenField hd = item.FindControl("hdId") as HiddenField;
                    if(hd != null)
                    sIds += hd.Value + ",";
                }
            }
        }

        sIds = sIds.TrimEnd(',');

        if (!String.IsNullOrEmpty(sIds))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("delete from looking_people where Id in ('" + sIds + "')", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyLFP", "btnDelete_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            FillGrid();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        tblDetails.Visible = false;
        btnDelete.Visible = rpSeachedMembers.Items != null && rpSeachedMembers.Items.Count > 0;
        trBand.Visible = ddBand.Items != null && ddBand.Items.Count > 0;
        ddBand.Text = "";
    }
}
