using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.Security;

namespace Jam
{
    /// <summary>
    /// Summary description for JamPage
    /// </summary>
    public class JamPage : System.Web.UI.Page
    {
        protected string m_sDefaultAvatarUrl = "~/img/userpic.gif";

        protected bool IsRegisteredUser
        {
            get
            {
                return UserInfo != null && !String.IsNullOrEmpty(UserInfo.Id);
            }
        }

        protected JamTypes.User UserInfo 
        { 
            get 
            {
                return JamTypes.User.GetUserFromSession(Session);
            } 
            set 
            { 
                Session["JamUser_Info"] = value; 
            } 
        }

        protected ulong LangUId
        {
            get
            {
                return Utils.GetLangId(Response, Request, Session);
            }
        }

        protected enLang LangEnum
        {
            get
            {
                return Utils.GetLangEnum(Response, Request, Session);
            }
        }

        public JamPage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected void FillDDVisibility(DropDownList dd)
        {
            string sLangCode = "en";
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select LangCode from site_language where Id=?LangId", con);
                    cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = LangUId;
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        if (rdr.Read())
                        {
                            sLangCode = rdr.GetString("LangCode");
                        }
                        rdr.Close();
                    }

                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillDDVisibility: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            dd.Items.Clear();

            if (sLangCode == "ru")
            {
                dd.Items.Add(new ListItem("Все", "0"));
                dd.Items.Add(new ListItem("Зарегистрированные пользователи", "1"));
                dd.Items.Add(new ListItem("Я", "2"));
                dd.Items.Add(new ListItem("Группа", "3"));
            }
            else
            {
                dd.Items.Add(new ListItem("All", "0"));
                dd.Items.Add(new ListItem("Registred Users", "1"));
                dd.Items.Add(new ListItem("Me", "2"));
                dd.Items.Add(new ListItem("Group", "3"));
            }
        }

        protected void FillDDGroups(DropDownList ddGroup)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    ddGroup.Items.Clear();

                    MySqlCommand cmd = new MySqlCommand("select ub.BandId, bands.Name from usertoband as ub, bands where ub.UserId=?UserId and ub.Deleted=0 and bands.Id=ub.BandId and bands.Deleted=0;", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                    
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    ddGroup.DataSource = ds;
                    ddGroup.DataBind();

                    if (ddGroup.Items != null && ddGroup.Items.Count > 0)
                    {
                        ddGroup.Items.Insert(0, new ListItem("", ""));
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillDDGroups: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillDDWay(DropDownList ddWays)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select wl.WayId, wl.Text as WayText from ways, waylocal as wl where wl.LangId=?LangId and ways.Id=wl.WayId order by WayText", con);
                    cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = LangUId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    DataRow dr = ds.Tables[0].NewRow(); //empty, 'Any' way
                    ds.Tables[0].Rows.InsertAt(dr, 0);

                    ddWays.DataSource = ds;
                    ddWays.DataBind();

                    ddWays.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillDDWay: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillInstr(Repeater rp_Instr, ulong nId)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Instrument from instruments as instr where instr.UserId=?UserId and instr.Deleted=0", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = nId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    rp_Instr.DataSource = ds;
                    rp_Instr.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillInstr (Repeater): " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillInstr(GridView grid_Instr, ulong nId)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Id, Instrument from instruments as instr where instr.UserId=?UserId and instr.Deleted=0", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = nId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    grid_Instr.DataSource = ds;
                    grid_Instr.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillInstr: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillWays(Repeater rp_way, ulong nId)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select wl.Text as WayName from userways as uw, waylocal as wl where uw.UserId=?UserId and uw.Deleted=0 and wl.WayId=uw.WayId and wl.LangId=?LangId", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = nId;
                    cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = LangUId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    rp_way.DataSource = ds;
                    rp_way.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillWays (Repeater): " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillWays(GridView grid_way, ulong nId)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select wl.Text as WayName from userways as uw, waylocal as wl where uw.UserId=?UserId and uw.Deleted=0 and wl.WayId=uw.WayId and wl.LangId=?LangId", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = nId;
                    cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = LangUId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    grid_way.DataSource = ds;
                    grid_way.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillWays: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillWays(GridView grid_way, ulong nId, string sSortExpr, SortDirection sort_dir)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select wl.Text as WayName 
from userways as uw, waylocal as wl where uw.UserId=?UserId and uw.Deleted=0 and wl.WayId=uw.WayId and wl.LangId=?LangId", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = nId;
                    cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = LangUId;

                    if (!String.IsNullOrEmpty(sSortExpr))
                    {
                        cmd.CommandText += " order by ?SortExpr " + ((sort_dir == SortDirection.Ascending) ? "ASC" : "DESC");
                        cmd.Parameters.Add("?SortExpr", MySqlDbType.String).Value = sSortExpr;
                    }

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    grid_way.DataSource = ds;
                    grid_way.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillWays: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillStyles(Repeater rp_style, ulong nId)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select StyleName from userstyles as ust where ust.UserId=?UserId", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = nId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    rp_style.DataSource = ds;
                    rp_style.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillStyles (Repeater): " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillStyles(GridView grid_style, ulong nId)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Id, StyleName from userstyles as ust where ust.UserId=?UserId", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = nId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    grid_style.DataSource = ds;
                    grid_style.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillStyles: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillLang(Repeater rp_Lang, ulong nId)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Language from userlanguages as ul where ul.UserId=?UserId and ul.Deleted=0", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = nId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    rp_Lang.DataSource = ds;
                    rp_Lang.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillLang (Repeater): " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillLang(GridView grid_Lang, ulong nId)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Id, Language from userlanguages as ul where ul.UserId=?UserId and ul.Deleted=0", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = nId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    grid_Lang.DataSource = ds;
                    grid_Lang.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillLang: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void FillBandLang(Repeater rp_Lang, ulong nId)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Language from bandlanguages as bl where bl.BandId=?BandId and bl.Deleted=0", con);
                    cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nId;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet("BandLangDs");
                    adp.Fill(ds);

                    rp_Lang.DataSource = ds;
                    rp_Lang.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "JamPage", "FillBandLang (repeater): " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected ulong m_Code = 0; //used in site_interface table
        protected bool bDoLocalize = true;

        public ulong Code
        {
            get
            {
                return m_Code;
            }
        }

        protected void LocalizeControls()
        {
            Utils.CommonLocalize(m_Code, LangUId, this.Controls);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UserInfo == null)
                {
                    HttpCookie auth_co = Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (auth_co != null)
                    {
                        FormsAuthenticationTicket ti = FormsAuthentication.Decrypt(auth_co.Value);
                        if (ti != null)
                        {
                            CreateUserInfo(ti.Name);
                        }
                    }
                }

                string sLang = (string)HttpContext.Current.Items["lang"];
                if (!String.IsNullOrEmpty(sLang))
                {
                    sLang = sLang.ToLower();
                    if (sLang == "ru" && LangEnum != enLang.ru)
                    {
                        SetRuLang();
                    }
                    else if (sLang == "en" && LangEnum != enLang.en)
                    {
                        SetEnLang();
                    }
                }
            }

            if (!IsPostBack && bDoLocalize)
            {
                LocalizeControls();
            }
            base.OnLoad(e);
        }

        private void SetRuLang()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select site_language.Id from site_language where LangCode='ru'", con);
                    Utils.SetLangId(Response, Session, (ulong)cmd.ExecuteScalar());
                    Utils.SetLangEnum(Response, Session, enLang.ru);
                    //Response.Redirect(Request.RawUrl, false);
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "UIControls_Language", "SetRuLang: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void SetEnLang()
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select site_language.Id from site_language where LangCode='en'", con);
                    Utils.SetLangId(Response, Session, (ulong)cmd.ExecuteScalar());
                    Utils.SetLangEnum(Response, Session, enLang.en);
                    //Response.Redirect(Request.RawUrl, false);
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "UIControls_Language", "imgRu_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void CreateUserInfo(string sEMail)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "select Id, SiteName, UserPicId, TimeZone, PswHash, IsAdmin from userinfo where Email=?Email and Deleted=0";
                    cmd.Connection = con;

                    cmd.Parameters.Add("?Email", MySqlDbType.VarChar, 30).Value = sEMail;

                    string sName = null;
                    ulong nId = 0;
                    string sPswHash = null;
                    TimeSpan tTZ = TimeSpan.MinValue;
                    string sAvaterPath = "~/img/userpic.gif";
                    bool bIsAdmin = false;

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        sPswHash = rdr.GetString("PswHash");
                        sName = rdr.GetString("SiteName");
                        nId = rdr.GetUInt64("Id");
                        tTZ = rdr.IsDBNull(rdr.GetOrdinal("TimeZone")) ? TimeSpan.Zero : TimeSpan.FromMinutes(rdr.GetInt32("TimeZone"));
                        if (!rdr.IsDBNull(rdr.GetOrdinal("UserPicId")))
                            sAvaterPath = "~/GetImage.aspx?id=" + rdr.GetUInt64("UserPicId").ToString();
                        bIsAdmin = rdr.IsDBNull(rdr.GetOrdinal("IsAdmin")) ? false : rdr.GetBoolean("IsAdmin");

                        rdr.Close();

                        UserInfo = new JamTypes.User(sName, nId, tTZ, sAvaterPath, bIsAdmin);
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "CreateUserInfo", "JamPage: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void SetPageTitleDescr(string[] arTitle, string[] arDescr)
        {
            Title = arTitle[(int)LangEnum];
            HtmlMeta hm = new HtmlMeta();
            hm.Name = "Description";
            hm.Content = arDescr[(int)LangEnum];
            Header.Controls.Add(hm);
        }
    }
}
