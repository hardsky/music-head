using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UIControls_ChartMenuSelectedItem : TabMenuSelectedItem
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    override public string Text
    {
        set
        {
            lb.Text = value;
        }
    }
}
