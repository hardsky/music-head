using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class About : JamPage
{
    public About()
    {
        m_Code = 4;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetPageTitleDescr(new string[] { 
                                "About music-head", 
                                "Информация о music-head" },
                new string[] { 
                               "Page with music-head brief.", 
                                "Страничка с кратким описанием проекта." });
        }
    }
}
