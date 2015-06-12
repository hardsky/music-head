using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UIControls_AboutCreditsControl : TabControl
{
    public UIControls_AboutCreditsControl()
    {
        m_Code = 44;
        bDoLocalize = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LocalizeControls();
    }

    public override void FillForm()
    {

    }
}
