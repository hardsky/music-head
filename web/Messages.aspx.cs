using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Jam;

public partial class Messages : JamPage
{
    public Messages()
    {
        m_Code = 30;
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/CreateMessage.aspx");
    }
}
