using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Bands : JamPage
{
    public Bands()
    {
        m_Code = 8;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetPageTitleDescr(new string[] { 
                "Music bands", 
                "Музыкальные группы" },
                new string[] { 
                    "Music bands registered on music-head.net", 
                    "Музыкальные группы, зарегистрированные на music-head.net" });

            FillForm();
        }
        this.Form.DefaultButton = btnFind.UniqueID;
    }

    private string BandName
    {
        get
        {
            return (string)ViewState["BandName"];
        }
        set
        {
            ViewState["BandName"] = value;
        }
    }

    private string BandStyle
    {
        get
        {
            return (string)ViewState["BandStyle"];
        }
        set
        {
            ViewState["BandStyle"] = value;
        }
    }

    private string BandLang
    {
        get
        {
            return (string)ViewState["BandLang"];
        }
        set
        {
            ViewState["BandLang"] = value;
        }
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            DataSet ds = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand("", con);

                string sBandName = BandName;
                string sBandStyle = BandStyle;
                string sBandLang = BandLang;

                string sQuery = @"select bands.Id as BandId, bands.Name, bands.Style, bands.Leader as LeaderId, userinfo.SiteName as LeaderName
                from bands left outer join userinfo on (bands.Leader=userinfo.Id and userinfo.Deleted=0){0} 
where bands.Deleted=0{1}";

                if (!String.IsNullOrEmpty(sBandName))
                {
                    sQuery = String.Format(sQuery, "{0}", " and LOWER(bands.Name) like ?BandName{1}");
                    cmd.Parameters.Add("?BandName", MySqlDbType.VarChar, 45).Value = sBandName;
                }
                else
                {
                    sQuery = String.Format(sQuery, "{0}", "{1}");
                }

                if (!String.IsNullOrEmpty(sBandStyle))
                {
                    sQuery = String.Format(sQuery, "{0}", " and LOWER(bands.Style)=?BandStyle{1}");
                    cmd.Parameters.Add("?BandStyle", MySqlDbType.VarChar, 80).Value = sBandStyle;
                }
                else
                {
                    sQuery = String.Format(sQuery, "{0}", "{1}");
                }

                if (!String.IsNullOrEmpty(sBandLang))
                {
                    sQuery = String.Format(sQuery, ", bandlanguages", " and bandlanguages.Deleted=0 and bandlanguages.BandId=bands.Id and LOWER(bandlanguages.Language)=?Lang");
                    cmd.Parameters.Add("?Lang", MySqlDbType.VarChar, 45).Value = sBandLang;
                }
                else
                {
                    sQuery = String.Format(sQuery, "", "");
                }

                if (!String.IsNullOrEmpty(SortExpr))
                {
                    sQuery += " order by " + Utils.SQLEscape(SortExpr) + (SortDir == SortDirection.Ascending ? " ASC" : " DESC");
                }

                cmd.CommandText = sQuery;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                adp.Fill(ds);
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Bands", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            gvBands.DataSource = ds; //here because we open one more connection in gvBands_RowDataBound
            gvBands.DataBind();
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        //paradigm: in sql query use function LOWER, and params pass to query in low case.
        BandName = Utils.SQLEscape(tbName.Text).ToLower();
        BandStyle = Utils.SQLEscape(tbStyle.Text).ToLower();
        BandLang = Utils.SQLEscape(tbLang.Text).ToLower();

        FillForm();
    }

    protected void gvBands_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            UInt64 nId = (UInt64)gvBands.DataKeys[e.Row.RowIndex].Values["BandId"];
            Repeater rp_Lang = (Repeater)e.Row.Cells[2].FindControl("rpLang");
            FillBandLang(rp_Lang, nId);
        }
    }

    protected void gvBands_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBands.PageIndex = e.NewPageIndex;
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

    protected void gvBands_Sorting(object sender, GridViewSortEventArgs e)
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
}
