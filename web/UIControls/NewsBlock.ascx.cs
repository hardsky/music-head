using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class UIControls_NewsBlock : JamUIControl
{
    public UIControls_NewsBlock()
    {
        m_Code = 47;
    }

    public string Title
    {
        set
        {
            lbBody.Text = value;
        }
    }

    public DateTime Date
    {
        set
        {
            lbDate.Text = (value + (UserInfo != null ? UserInfo.TimeZone : TimeSpan.Zero)).ToString("dd.MM.yyyy");
        }
    }

    public string NewsId
    {
        set
        {
			lnkGo.NavigateUrl = Jam.JamRouteUrl.PickUp ( "news_issue", this.LangEnum, new Dictionary<string, string> ( ) { { "id", value } } );
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
