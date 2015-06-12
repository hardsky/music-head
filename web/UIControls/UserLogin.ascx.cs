using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Web.Security;

public partial class UIControls_UserLogin : JamUIControl
{
    public UIControls_UserLogin()
    {
        m_Code = 3;
    }

	protected override void OnLoad ( EventArgs e )
	{
		base.OnLoad ( e );
		if ( !IsPostBack )
		{
			hlReg.NavigateUrl = Jam.JamRouteUrl.PickUp ( "registration", this.LangEnum, null );
			hlForgotPsw.NavigateUrl = Jam.JamRouteUrl.PickUp ( "password", this.LangEnum, null );
		}
	}

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        e.Authenticated = false;
        /*
        if (!Utils.IsValidEmail(Login1.UserName))
            return;
        */

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select Id, SiteName, UserPicId, TimeZone, PswHash, IsAdmin from userinfo where Email=?Email and Deleted=0";
                cmd.Connection = con;

                string sPsw = Login1.Password.Trim();
                string sEMail = Login1.UserName.ToLower();
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
                    tTZ = rdr.IsDBNull(rdr.GetOrdinal("TimeZone"))? TimeSpan.Zero : TimeSpan.FromMinutes(rdr.GetInt32("TimeZone"));
                    if (!rdr.IsDBNull(rdr.GetOrdinal("UserPicId")))
                        sAvaterPath = "~/GetImage.aspx?id=" + rdr.GetUInt64("UserPicId").ToString();
                    bIsAdmin = rdr.IsDBNull(rdr.GetOrdinal("IsAdmin")) ? false : rdr.GetBoolean("IsAdmin");
                    rdr.Close();
                }

                e.Authenticated = !String.IsNullOrEmpty(sName) && nId > 0 && IsRightPsw(sPsw, sPswHash);

                if (e.Authenticated)
                {
                    JamTypes.User user = new JamTypes.User(sName, nId, tTZ, sAvaterPath, bIsAdmin);
                    UserInfo = user;
                    /*Login1.DestinationPageUrl = "~/folks/" + user.Name;
                    FormsAuthentication.RedirectFromLoginPage(sName, Login1.RememberMeSet);//TODO: not working
                    */

                    FormsAuthenticationTicket ti = new FormsAuthenticationTicket(sEMail, Login1.RememberMeSet,
                        Login1.RememberMeSet ? 518400 // 1 year
                        : 60);                    
                    string encTicket = FormsAuthentication.Encrypt(ti);
                    HttpCookie auth_co = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    if (Login1.RememberMeSet)
                        auth_co.Expires = ti.Expiration;
                    Response.Cookies.Add(auth_co);
					Response.Redirect ( Jam.JamRouteUrl.PickUp ( "folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "name", user.Name } } ) );
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UserLogin", "Login1_Authenticate: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private bool IsRightPsw(string sPsw, string sPswHash)
    {
        if (String.IsNullOrEmpty(sPsw) || String.IsNullOrEmpty(sPswHash))
            return false;

        string salt = sPswHash.Substring(sPswHash.Length - 8); //i used array of 6 bytes to generate salt, but get salt string with length 8; need some reseach TODO
        string sPswHashAgain = Utils.CreatePasswordHash(sPsw, salt);
        bool bRet = sPswHash == sPswHashAgain;
        return bRet;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        TextBox tbPsw = (TextBox)Login1.FindControl("Password");
        tbPsw.Attributes["style"] = String.Format("background: transparent {0} no-repeat scroll 4px {1};", LangEnum == enLang.en ? "url(./img/psw_en.png)" : "url(./img/psw_ru.png)", LangEnum == enLang.en ? "3px" : "5px");
        tbPsw.Attributes["onblur"] = String.Format("if(!this.value || !this.value.length){{this.style.backgroundImage='{0}'}}", LangEnum == enLang.en ? "url(./img/psw_en.png)" : "url(./img/psw_ru.png)");
    }
}
