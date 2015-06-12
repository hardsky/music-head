using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Events : JamPage
{
    public Events()
    {
        m_Code = 57;
    }

    private string Country
    {
        get
        {
            return (string)ViewState["Country"];
        }
        set
        {
            ViewState["Country"] = value;
        }
    }

    private string City
    {
        get
        {
            return (string)ViewState["City"];
        }
        set
        {
            ViewState["City"] = value;
        }
    }

    private string Language
    {
        get
        {
            return (string)ViewState["Language"];
        }
        set
        {
            ViewState["Language"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Country = tbCountry.Text.ToLower().Trim();
        City = tbCity.Text.ToLower().Trim();
        Language = tbLanguage.Text.ToLower().Trim();

        if (!IsPostBack)
        {
            SetPageTitleDescr(new string[] { 
                                "music-head.net: Events", 
                                "music-head.net: Афиша" },
                new string[] { 
                               "Music-head users post there about their events.", 
                                "Объявления о концертах пользователей music-head.net" });

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
                MySqlCommand cmd = new MySqlCommand("select Id, Description, Event_datetime, Country, City, Language from afisha", con);
                bool bWhereAdded = false;
                if (!String.IsNullOrEmpty(Country))
                {
                    cmd.CommandText += " where LOWER(Country)=?Country";
                    cmd.Parameters.Add("?Country", MySqlDbType.VarChar, 80).Value = Country;
                    bWhereAdded = true;
                }
                if (!String.IsNullOrEmpty(City))
                {
                    if (!bWhereAdded)
                    {
                        cmd.CommandText += " where";
                        bWhereAdded = true;
                    }
                    cmd.CommandText += " LOWER(City)=?City";
                    cmd.Parameters.Add("?City", MySqlDbType.VarChar, 80).Value = City;
                }
                if (!String.IsNullOrEmpty(Language))
                {
                    if (!bWhereAdded)
                    {
                        cmd.CommandText += " where";
                    }
                    cmd.CommandText += " LOWER(Language)=?Lang";
                    cmd.Parameters.Add("?Lang", MySqlDbType.VarChar, 45).Value = Language;
                }

                cmd.CommandText += " order by Event_datetime desc";

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvEvents.DataSource = ds;
                gvEvents.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Events", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        FillForm();
    }
}
