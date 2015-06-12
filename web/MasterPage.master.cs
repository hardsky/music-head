using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using System.Web.Security;
using MySql.Data.MySqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected enLang LangEnum
    {
        get
        {
            return Utils.GetLangEnum(Response, Request, Session);
        }
    }

    protected ulong LangUId
    {
        get
        {
            return Utils.GetLangId(Response, Request, Session);
        }
    }
    protected ulong m_Code = 45; //used in site_interface table
    protected void LocalizeControls()
    {
        Utils.CommonLocalize(m_Code, LangUId, this.form1.Controls);
    }

    //!!! same as UserInfo in JamPage !!!
    private JamTypes.User UserInfo
    {
        get
        {
            return JamTypes.User.GetUserFromSession(Session);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

		hlReg.NavigateUrl = Jam.JamRouteUrl.PickUp ( "registration", this.LangEnum, null );
		hlAvt.NavigateUrl = Jam.JamRouteUrl.PickUp ( "default", this.LangEnum, null );

        if (UserInfo != null && !String.IsNullOrEmpty(UserInfo.Id))
        {
            dvTopReg.Visible = false;
            dvTopExit.Visible = true;
            hlMyPage.NavigateUrl = Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", UserInfo.Name } });
        }
        else
        {
            dvTopReg.Visible = true;
            dvTopExit.Visible = false;
        }

        LocalizeControls();
    }

    protected void lnkbLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        JamTypes.User.ResetUserSession(Session);
        Response.Redirect(Request.RawUrl);
    }
}
