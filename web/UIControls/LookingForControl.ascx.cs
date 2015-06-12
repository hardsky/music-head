using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class UIControls_LookingForControl : TabContainer
{
    public UIControls_LookingForControl()
    {
        arMenuCommand = new string[] {
        "lfp",
        "lfb"
        };

        m_arLanguages = new enLang[]{
        enLang.en,
        enLang.ru
        };

        arMenuText = new string[] {
        "Looking For People", "Поиск людей",
        "Looking For Band", "Поиск группы"
        };

        arTabs = new string[]{
            "~/UIControls/LFPControl.ascx",
            "~/UIControls/LFBControl.ascx",
        };

        m_nMenuItemWidth = 200;
    }
}
