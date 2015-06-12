using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class UIControls_ChartsControl : TabContainer
{
    public UIControls_ChartsControl()
    {
        arMenuCommand = new string[] {
        "music",
        "lyrics",
        "video"
        };

        m_arLanguages = new enLang[]{
        enLang.en,
        enLang.ru
        };

        arMenuText = new string[] {
        "Music", "Музыка",
        "Lyrics", "Стихи",
        "Video", "Видео"
        };

        arTabs = new string[]{
            "~/UIControls/ChartMusic.ascx",
            "~/UIControls/ChartLyrics.ascx",
            "~/UIControls/ChartVideo.ascx"
        };

        /*
        m_sMenuItem = "~/UIControls/ChartMenuItem.ascx";
        m_sSelectedMenuItem = "~/UIControls/ChartMenuSelectedItem.ascx";
         */
    }
}
