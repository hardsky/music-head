using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class UIControls_FootMenu : JamUIControl
{
    public UIControls_FootMenu()
    {
        m_Code = 39;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (UserInfo != null && !String.IsNullOrEmpty(UserInfo.Id))
            {
                hlHome.NavigateUrl = JamRouteUrl.PickUp("folk", this.LangEnum, new Dictionary<string, string>() { { "name", UserInfo.Name } });
            }
            else
            {
                hlHome.NavigateUrl = JamRouteUrl.PickUp("default", this.LangEnum, null);
            }
            hlFolks.NavigateUrl = JamRouteUrl.PickUp("folks", this.LangEnum, null);
            hlLyrics.NavigateUrl = JamRouteUrl.PickUp("lyrics", this.LangEnum, null);
            hlMusic.NavigateUrl = JamRouteUrl.PickUp("music", this.LangEnum, null);
            hlVideo.NavigateUrl = JamRouteUrl.PickUp("video", this.LangEnum, null);
            hlAfisha.NavigateUrl = JamRouteUrl.PickUp("events", this.LangEnum, null);
            hlSearch.NavigateUrl = JamRouteUrl.PickUp("lfg", this.LangEnum, null);
            hlBands.NavigateUrl = JamRouteUrl.PickUp("bands", this.LangEnum, null);
            hlForum.NavigateUrl = JamRouteUrl.PickUp("forum", this.LangEnum, null);
            hlAbout.NavigateUrl = JamRouteUrl.PickUp("about", this.LangEnum, null);
            hlSiteNews.NavigateUrl = JamRouteUrl.PickUp("news", this.LangEnum, null);

            string sUrl = Request.RawUrl.Trim('?').ToLower();
            if (sUrl.Contains("folks"))
                hlFolks.CssClass = "FootMenuItemSelect";
            else if (sUrl.Contains("lyrics"))
                hlLyrics.CssClass = "FootMenuItemSelect";
            else if (sUrl.Contains("music"))
                hlMusic.CssClass = "FootMenuItemSelect";
            else if (sUrl.Contains("video"))
                hlVideo.CssClass = "FootMenuItemSelect";
            else if (sUrl.Contains("lfp") || sUrl.Contains("lfb") || sUrl.Contains("lfg"))
                hlSearch.CssClass = "FootMenuItemSelect";
            else if (sUrl.Contains("bands"))
                hlBands.CssClass = "FootMenuItemSelect";
            else if (sUrl.Contains("forum"))
                hlForum.CssClass = "FootMenuItemSelect";
            else if (sUrl.Contains("about"))
                hlAbout.CssClass = "FootMenuItemSelect";
            else if (sUrl.Contains("events"))
                hlAfisha.CssClass = "FootMenuItemSelect";
            else if (sUrl.Contains("news"))
                hlSiteNews.CssClass = "FootMenuItemSelect";
            else
                hlHome.CssClass = "FootMenuItemSelect";
        }
    }
}
