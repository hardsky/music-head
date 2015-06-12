using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;

public partial class UIControls_LFPControl : TabControl
{
    public UIControls_LFPControl()
    {
        m_Code = 40;
        bDoLocalize = false;
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

    private string Looking
    {
        get
        {
            return (string)ViewState["Looking"];
        }
        set
        {
            ViewState["Looking"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LocalizeControls();
        if (!IsPostBack)
        {
            SortExpr = "BandName";
            SortDir = SortDirection.Ascending;
            gvSearchMembers.DataBind();
        }
        this.Page.Form.DefaultButton = btnFind.UniqueID;
    }

    public override void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select lp.Id, lp.Country, lp.City, lp.Language,
                lp.LookingFor, lp.Comment, lp.Created, bd.Name as BandName from looking_people as lp, bands as bd where lp.BandId=bd.Id", con);
                
                if (!String.IsNullOrEmpty(Language))
                {
                    cmd.CommandText += " and LOWER(lp.Language) like ?Lang";
                    cmd.Parameters.Add("?Lang", MySqlDbType.VarChar, 45).Value = Language;
                }

                if (!String.IsNullOrEmpty(Country))
                {
                    cmd.CommandText += " and LOWER(lp.Country) like ?Country";
                    cmd.Parameters.Add("?Country", MySqlDbType.VarChar, 80).Value = Country;
                }

                if (!String.IsNullOrEmpty(City))
                {
                    cmd.CommandText += " and LOWER(lp.City) like ?City";
                    cmd.Parameters.Add("?City", MySqlDbType.VarChar, 80).Value = City;
                }

                if (!String.IsNullOrEmpty(Looking))
                {
                    cmd.CommandText += " and LOWER(lp.LookingFor) like ?Look";
                    cmd.Parameters.Add("?Look", MySqlDbType.VarChar, 80).Value = Looking;
                }

                cmd.CommandText += " order by ";
                if (!String.IsNullOrEmpty(SortExpr))
                {
                    cmd.CommandText += Utils.SQLEscape(SortExpr) + (SortDir == SortDirection.Ascending ? " ASC" : " DESC");
                    cmd.CommandText += ", lp.Created desc";
                }
                else
                {
                    cmd.CommandText += "lp.Created desc";
                }

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvSearchMembers.DataSource = ds;
                gvSearchMembers.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "LFP", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void gvSearchMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearchMembers.PageIndex = e.NewPageIndex;
        FillForm();
    }

    private string SortExpr
    {
        get
        {
            return (string)ViewState["SortExpr"];
        }
        set
        {
            ViewState["SortExpr"] = value;
        }
    }

    private SortDirection SortDir
    {
        get
        {
            return (SortDirection)ViewState["SortDir"];
        }
        set
        {
            ViewState["SortDir"] = value;
        }
    }

    protected void gvSearchMembers_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == SortExpr)
        {
            if (SortDir == SortDirection.Ascending)
                e.SortDirection = SortDirection.Descending;
            else
                e.SortDirection = SortDirection.Ascending;
        }
        SortExpr = e.SortExpression;
        SortDir = e.SortDirection;

        FillForm();
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        Language = Utils.SQLEscape(tbLanguage.Text).Trim().ToLower();
        if (!String.IsNullOrEmpty(Language) && !Language.EndsWith("%") && Language.Length < 45)
            Language += "%";
        Country = Utils.SQLEscape(tbCountry.Text).Trim().ToLower();
        if (!String.IsNullOrEmpty(Country) && !Country.EndsWith("%") && Country.Length < 80)
            Country += "%";
        City = Utils.SQLEscape(tbCity.Text).Trim().ToLower();
        if (!String.IsNullOrEmpty(City) && !City.EndsWith("%") && City.Length < 80)
            City += "%";
        Looking = Utils.SQLEscape(tbLooking.Text).Trim().ToLower();

        FillForm();
    }

    protected void gvSearchMembers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            object oCr = drv["Created"];
            if (oCr != null && oCr != DBNull.Value && UserInfo != null)
            {
                DateTime dt = (DateTime)oCr;
                e.Row.Cells[6].Text = (dt + UserInfo.TimeZone).ToString("dd.MM.yyyy");
            }
        }
    }
}
