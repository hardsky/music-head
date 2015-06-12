using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Routing;

public partial class UIControls_Language : JamUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Url.AbsoluteUri.Contains("/en/"))
            {
                hlEn.Enabled = false;
                hlRu.NavigateUrl = Request.Url.AbsoluteUri.Replace("/en/", "/ru/");
            }
            else if (Request.Url.AbsoluteUri.Contains("/ru/"))
            {
                hlRu.Enabled = false;
                hlEn.NavigateUrl = Request.Url.AbsoluteUri.Replace("/ru/", "/en/");
            }
            else
            {
                hlEn.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "default", new RouteValueDictionary() { { "lang", "en" } }).VirtualPath;
                hlRu.NavigateUrl = RouteTable.Routes.GetVirtualPath(null, "default", new RouteValueDictionary() { { "lang", "ru" } }).VirtualPath;

                hlEn.Enabled = LangEnum != enLang.en;
                hlRu.Enabled = !hlEn.Enabled;
            }
        }
    }
}
