using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class UIControls_MessagesControl : TabContainer
{
    public UIControls_MessagesControl()
    {
        arMenuCommand = new string[] {
        "inbox",
        "outbox"
        };

        m_arLanguages = new enLang[]{
        enLang.en,
        enLang.ru
        };

        arMenuText = new string[] {
        "Inbox", "Входящие",
        "Outbox", "Отправленные"
        };

        arTabs = new string[]{
            "~/UIControls/InboxMessages.ascx",
            "~/UIControls/OutboxMessages.ascx"
        };

        //m_nMenuItemWidth = 200;
    }
}
