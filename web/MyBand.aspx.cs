using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class MyBand : JamPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;
    }
}
