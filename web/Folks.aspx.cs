using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Folks : JamPage
{

    public string ArtName { get { return (string)ViewState["ArtName"]; } set { ViewState["ArtName"] = value; } }
    public string Country { get { return (string)ViewState["Country"]; } set { ViewState["Country"] = value; } }
    public string City { get { return (string)ViewState["City"]; } set { ViewState["City"] = value; } }
    public string Instrument { get { return (string)ViewState["Instrument"]; } set { ViewState["Instrument"] = value; } }
    public string Style { get { return (string)ViewState["Style"]; } set { ViewState["Style"] = value; } }
    public string Band { get { return (string)ViewState["Band"]; } set { ViewState["Band"] = value; } }
    public string Language { get { return (string)ViewState["Language"]; } set { ViewState["Language"] = value; } }

    public Folks()
    {
        m_Code = 7;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
			//Header.Controls.Add(new HtmlGeneric
			HtmlGenericControl rss_header = new HtmlGenericControl ( "link" );
			rss_header.Attributes [ "rel" ] = "alternate";
			rss_header.Attributes [ "type" ] = "application/rss+xml";
			rss_header.Attributes [ "href" ] = JamRouteUrl.PickUp ( "rss", this.LangEnum, new Dictionary<string, string> ( ) { { "rss_type", "folks" } } );
			rss_header.Attributes [ "title" ] = this.LangEnum == enLang.ru ? "Музыканты на music-head.net" : "Musicians on music-head";

			Header.Controls.Add ( rss_header );

            SetPageTitleDescr(new string[] { 
                                "Folks", 
                                "Народ" },
                new string[] { 
                               "People registered on music-head. Summary info about music style, instruments and languages.", 
                                @"Пользователи зарегистрированные на music-head.net. Страничка содержит сводную информацию 
о музыкальном стиле, иструментах и языках, которыми владеет пользвователь." });
            FillDDWay(ddWay);
            FillForm();

			rss_link.NavigateUrl = JamRouteUrl.PickUp ( "rss", this.LangEnum, new Dictionary<string, string> ( ) { { "rss_type", "folks" } } );
        }

        this.Form.DefaultButton = btnFind.UniqueID;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        AddNotInBandScript();
    }

    private void AddNotInBandScript()
    {

        string sScript = String.Format(@"
function NotInBandFunc(obj)
{{
    if(obj)
    {{
        var oTb = document.getElementById('{0}');
        if(obj.checked)
        {{
                oTb.value = '';
                oTb.disabled = obj.checked;
        }}
        else
        {{
                oTb.disabled = obj.checked;
        }}
    }}
}};
NotInBandFunc(document.getElementById('{1}'));
", tbBand.ClientID, cbNotInBand.ClientID);

        if(!this.ClientScript.IsStartupScriptRegistered(this.GetType(), "NotInBandScript"))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "NotInBandScript", sScript, true);
        }

        cbNotInBand.InputAttributes["onclick"] = "NotInBandFunc(this)";
    }

    protected void gvArtists_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            UInt64 nId = (UInt64)gvArtists.DataKeys[e.Row.RowIndex].Values["Id"];

            Repeater rp_way = (Repeater)e.Row.Cells[1].FindControl("rpWay");
            FillWays(rp_way, nId);

            Repeater rp_style = (Repeater)e.Row.Cells[2].FindControl("rpStyle");
            FillStyles(rp_style, nId);

            Repeater rp_Instr = (Repeater)e.Row.Cells[3].FindControl("rpInstr");
            FillInstr(rp_Instr, nId);

            Repeater rp_Lang = (Repeater)e.Row.Cells[4].FindControl("rpLang");
            FillLang(rp_Lang, nId);
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        ArtName = Utils.SQLEscape(tbName.Text).ToLower(); //can be part of word
        Country = Utils.SQLEscape(tbCountry.Text).ToLower();
        City = Utils.SQLEscape(tbCity.Text).ToLower();
        Instrument = Utils.SQLEscape(tbInstrument.Text).ToLower();
        Style = Utils.SQLEscape(tbStyle.Text).ToLower();
        Band = Utils.SQLEscape(tbBand.Text).ToLower();//can be part of word
        Language = Utils.SQLEscape(tbLanguage.Text).ToLower();

        FillForm();
    }


    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();

                //query cases from textboxes
                string sNameCase = ArtName; //can be part of word
                string sCountry = Country;
                string sCity = City;

                string sWayId = Utils.SQLEscape(ddWay.SelectedValue);
                string sInstrument = Instrument;
                string sStyle = Style;
                string sBand = Band;//can be part of word
                bool bNotInBand = cbNotInBand.Checked;
                string sLanguage = Language;

                bool bHasWork = cbWorksExist.Checked;

                //It's my choice to permit 'part words' in Name and Band, only. (ONLY!!!)

                string sQuery = "select userinfo.Id, userinfo.SiteName as Name from userinfo{0} where userinfo.Deleted=0";

                if (!String.IsNullOrEmpty(sCountry))
                {
                    sQuery += " and LOWER(userinfo.Country)=?Country";
                    cmd.Parameters.Add("?Country", MySqlDbType.VarChar, 80).Value = sCountry;
                }

                if (!String.IsNullOrEmpty(sCity))
                {
                    sQuery += " and LOWER(userinfo.City)=?City";
                    cmd.Parameters.Add("?City", MySqlDbType.VarChar, 80).Value = sCity;
                }

                if (!String.IsNullOrEmpty(sNameCase))
                {
                    sQuery += " and LOWER(userinfo.SiteName) like ?Name";
                    cmd.Parameters.Add("?Name", MySqlDbType.VarChar, 45).Value = sNameCase;
                }

                //
                if (!String.IsNullOrEmpty(sWayId))
                {
                    sQuery = String.Format(sQuery, ", userways{0}");
                    sQuery += " and userways.Deleted=0 and userways.UserId=userinfo.Id and userways.WayId=?WayId";
                    cmd.Parameters.Add("?WayId", MySqlDbType.UInt64).Value = UInt64.Parse(sWayId);
                }
                else
                {
                    sQuery = String.Format(sQuery, "{0}");
                }

                if (!String.IsNullOrEmpty(sInstrument))
                {
                    sQuery = String.Format(sQuery, ", instruments{0}");
                    sQuery += " and instruments.Deleted=0 and instruments.UserId=userinfo.Id and LOWER(instruments.Instrument)=?Instrument";
                    cmd.Parameters.Add("?Instrument", MySqlDbType.VarChar, 100).Value = sInstrument;
                }
                else
                {
                    sQuery = String.Format(sQuery, "{0}");
                }

                if (!String.IsNullOrEmpty(sStyle))
                {
                    sQuery = String.Format(sQuery, ", userstyles{0}");
                    sQuery += " and userstyles.UserId=userinfo.Id and LOWER(userstyles.StyleName)=?StyleName";
                    cmd.Parameters.Add("?StyleName", MySqlDbType.VarChar, 80).Value = sStyle;
                }
                else
                {
                    sQuery = String.Format(sQuery, "{0}");
                }

                if (!String.IsNullOrEmpty(sBand) && !bNotInBand)
                {
                    sQuery = String.Format(sQuery, ", usertoband, bands{0}");
                    sQuery += " and usertoband.Deleted=0 and usertoband.UserId=userinfo.Id and usertoband.BandId=bands.Id and bands.Deleted=0 and LOWER(bands.Name) like ?BandName";
                    cmd.Parameters.Add("?BandName", MySqlDbType.VarChar, 45).Value = sBand;
                }
                else if (bNotInBand) //??? may be wrong query
                {
                    sQuery = String.Format(sQuery, "{0}");
                    sQuery += " and (userinfo.Id not in (select distinct usertoband.UserId from usertoband, bands where usertoband.Deleted=0 and usertoband.BandId=bands.Id and bands.Deleted=0))";
                }
                else
                {
                    sQuery = String.Format(sQuery, "{0}");
                }

                if (!String.IsNullOrEmpty(sLanguage))
                {
                    sQuery = String.Format(sQuery, ", userlanguages");
                    sQuery += " and userlanguages.Deleted=0 and userlanguages.UserId=userinfo.Id and LOWER(userlanguages.Language)=?Language";
                    cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = sLanguage;
                }
                else
                {
                    sQuery = String.Format(sQuery, "");
                }

                if (bHasWork)
                {
					sQuery += @" and (select if(((select lyrics.Id from lyrics where lyrics.Author=userinfo.Id limit 1) is not null) or
((select music.Id from music where music.Author=userinfo.Id limit 1) is not null) or
((select video.Id from video where video.Author=userinfo.Id limit 1)is not null), 1, null)) is not null";
                }

                if (!String.IsNullOrEmpty(SortExpr))
                {
                    sQuery += " order by " + Utils.SQLEscape(SortExpr) + (SortDir == SortDirection.Ascending ? " ASC" : " DESC");
                }

                cmd.CommandText = sQuery;
                cmd.Connection = con;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet("ClickDs");
                adp.Fill(ds);

                gvArtists.DataSource = ds;
                gvArtists.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Artists", "btnFind_Click: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void gvArtists_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvArtists.PageIndex = e.NewPageIndex;
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

    protected void gvArtists_Sorting(object sender, GridViewSortEventArgs e)
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
