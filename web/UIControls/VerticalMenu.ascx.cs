using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Jam;

public partial class UIControls_VerticalMenu : VerticalMenu
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateMenu();
    }

    private string GetRootUrl()
    {
        if (Request.RawUrl.ToLower().EndsWith(".aspx"))
        {
            string[] arParts = Request.RawUrl.Split('/');
            string sLast = arParts.Last();
            return Request.RawUrl.Substring(0, Request.RawUrl.Length - sLast.Length);
        }
        else
        {
            return Request.RawUrl;
        }
    }

    private string MakeUrl(string sRootUrl, string sUrl)
    {
        if (sUrl.StartsWith(@"~/#"))
        {
            return sRootUrl + sUrl.Substring(2);
        }

        return sUrl;
    }

    private void CreateMenu()
    {
        if (ItemsSchema != null && ItemsSchema.Count > 0)
        {
            string sUrl = Request.RawUrl.ToLower();
            string sRootUrl = GetRootUrl();

            foreach (MenuItem item in ItemsSchema)
            {
                if (item.IsForAdmin && (UserInfo == null || !UserInfo.IsAdmin))
                    continue;

                Control ctr = null;
                MenuItem real_item = new MenuItem( //need resolve url, for ~/#lyrics, for an example
                        MakeUrl(sRootUrl, item.Url),
                        item.Name, item.IsForAdmin);

                string sItemUrl = this.ResolveUrl(real_item.Url).ToLower();
                if (sItemUrl == sUrl)
                    ctr = CreateItem(new MenuItem(real_item), "dvSelectedMenuItem");
                else
                    ctr = CreateItem(real_item, "dvMyMenuItem");

                dvMenu.Controls.Add(ctr);
            }
        }
    }

    private Control CreateItem(MenuItem item, string sClassName)
    {
        /*
    <div class="dvMyMenuItem">
        <div>
            <div>
                <asp:HyperLink ID="hlLyrics" runat="server" NavigateUrl="~/MyLyrics.aspx">My Lyrics</asp:HyperLink>    
            </div>
        </div>
    </div>
         */

        HtmlGenericControl dv1 = new HtmlGenericControl("div");
        dv1.Attributes["class"] = sClassName;
        HtmlGenericControl dv2 = new HtmlGenericControl("div");
        dv1.Controls.Add(dv2);
        HtmlGenericControl dv3 = new HtmlGenericControl("div");
        dv2.Controls.Add(dv3);

        HyperLink hl = new HyperLink();
        hl.Text = item.Name;
        hl.NavigateUrl = item.Url;

        dv3.Controls.Add(hl);

        return dv1;
    }
}
