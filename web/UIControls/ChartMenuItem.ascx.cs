using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UIControls_ChartMenuItem : TabMenuItem
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    override public string Text
    {
        set
        {
            lnkb.Text = value;
        }
    }

    /// <summary>
    /// true if left item, false if right
    /// </summary>
    override public bool Left
    {
        set
        {
            if (value)
                dvChartItem.Attributes["style"] = "left: 3px;";
            else
                dvChartItem.Attributes["style"] = "left: -3px;";
        }
    }

    protected void lnkb_Click(object sender, EventArgs e)
    {
        if (OnClick != null)
            OnClick(sender, e);
    }
}
