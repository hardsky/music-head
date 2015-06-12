using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class Looking : JamPage
{
    public Looking()
    {
        m_Code = 201;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            SetPageTitleDescr(new string[] { 
                "Looking for group or musician", 
                "Поиск группы или музыканта" },
                new string[] { 
                    "Musicians, registered on music-head.net, can post signs, that they are looking for band(musicians), and other people can find, what they are looking for.", 
                    "Музыканты, зарегистрированные на music-head.net, могут оставлять объявления о поиске группы(музыканта), а посетители сайта могут поискать среди этих объявлений то, что им походит." });
        }
    }
}
