using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.IO;
using System.Web.Security;
using System.Security.Cryptography;

public partial class Registration : JamPage
{
    public Registration()
    {
        m_Code = 37;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CaptchaImage.GenerateText(Session);
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        AddEmailCheckScript();
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbPsw.Text) &&
            !String.IsNullOrEmpty(tbRePsw.Text) && !String.IsNullOrEmpty(tbSiteName.Text) &&
            !String.IsNullOrEmpty(tbCodeNumberTextBox.Text) &&
            CaptchaImage.CheckCaptcha(tbCodeNumberTextBox.Text, Session) && Utils.IsValidEmail(tbEmail.Text))
        {
            CaptchaImage.GenerateText(Session);

            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    if (IsUserCredsExist(con))
                    {
                        return;
                    }

                    string sPsw = tbPsw.Text.Trim();                    
                    string sPswHash = Utils.CreatePasswordHash(sPsw);

                    MySqlCommand cmd = new MySqlCommand(@"insert into userinfo (Email, PswHash, SiteName, Deleted, Updated, UpdateUser, Created) 
values (?Email, ?PswHash, ?SiteName, 0, ?Updated, ?UpdateUser, ?Created);
SELECT LAST_INSERT_ID();", con);
                    string sEmail = tbEmail.Text.Trim().ToLower();
                    cmd.Parameters.Add("?Email", MySqlDbType.VarChar, 30).Value = sEmail;
                    cmd.Parameters.Add("?PswHash", MySqlDbType.VarChar, 48).Value = sPswHash;
                    cmd.Parameters.Add("?SiteName", MySqlDbType.VarChar, 45).Value = tbSiteName.Text.Trim();
                    cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value =
                        cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                    cmd.Parameters.Add("?UpdateUser", MySqlDbType.UInt64).Value = null;

                    object obj = cmd.ExecuteScalar();
                    UInt64 nId = Convert.ToUInt64(obj);

                    JamTypes.User ui = new JamTypes.User(tbSiteName.Text, nId, TimeSpan.Zero, null, false);
                    UserInfo = ui;

                    //User Directories!!!
                    Directory.CreateDirectory(MapPath("~/Music/") + UserInfo.Id);
                    Directory.CreateDirectory(MapPath("~/Video/") + UserInfo.Id);
                    Directory.CreateDirectory(MapPath("~/Images/") + UserInfo.Id);

                    FormsAuthentication.SetAuthCookie(sEmail, false);
					Response.Redirect ( Jam.JamRouteUrl.PickUp ( "folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "name", UserInfo.Name } } ), false );
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Registration", "btnRegister_Click: " + ex.Message);
                    return;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        else
        {
            CaptchaImage.GenerateText(Session);
        }
    }

    private void AddEmailCheckScript()
    {
        string sScript = @"
function validate_email()
{{
    var field = document.getElementById('{0}');
    var emailfilter = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{{0,66}})\.([a-z]{{2,6}}(?:\.[a-z]{{2}})?)$/i
    with (field)
    {{
        if(emailfilter.test(field.value) == false)
        {{
            alert('Please enter a valid email address.')
            field.select()
            return false;
        }}
        else
            return true;
    }}
}}
";
        sScript = String.Format(sScript, tbEmail.ClientID);
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JamEmailCheckScript"))
            ClientScript.RegisterClientScriptBlock(this.GetType(), "JamEmailCheckScript", sScript, true);

        btnRegister.OnClientClick = "return validate_email();";
    }

    /// <summary>
    /// return true, if such credentials does not exist
    /// </summary>
    /// <returns></returns>
    private bool IsUserCredsExist(MySqlConnection con)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand(@"select Id from userinfo where STRCMP(LOWER(Email), ?Email)=0 or STRCMP(LOWER(SiteName), ?SiteName)=0;", con);
            cmd.Parameters.Add("?Email", MySqlDbType.VarChar, 30).Value = tbEmail.Text.Trim().ToLower();
            cmd.Parameters.Add("?SiteName", MySqlDbType.VarChar, 45).Value = tbSiteName.Text.ToLower().Trim();

            object obj = cmd.ExecuteScalar();

            if (obj != null && obj != DBNull.Value)
                return true;
        }
        catch (Exception ex)
        {
            JamLog.log(JamLog.enEntryType.error, "Registration", "IsUserCredsExist: " + ex.Message);
            throw ex;
        }

        return false;
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        CaptchaImage.GenerateText(Session);
        tbCodeNumberTextBox.Text = "";
    }
}
