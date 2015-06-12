using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class UIControls_AboutControl : TabContainer
{
    public UIControls_AboutControl()
    {
        arMenuCommand = new string[] {
        "about_site",
        "about_components"
        };

        m_arLanguages = new enLang[]{
        enLang.en,
        enLang.ru
        };

        arMenuText = new string[] {
        "Site", "Сайт",
        "Thanks", "Благодарности"
        };

        arTabs = new string[]{
            "~/UIControls/AboutSiteControl.ascx",
            "~/UIControls/AboutComponentsControl.ascx"
        };

        //m_nMenuItemWidth = 200;
    }
}
