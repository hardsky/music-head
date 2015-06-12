using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UIControls_AboutComponentsControl : TabControl
{
    public UIControls_AboutComponentsControl()
    {
        m_Code = 43;
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
