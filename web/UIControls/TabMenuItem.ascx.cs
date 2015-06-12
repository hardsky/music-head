using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UIControls_TabMenuItem : TabMenuItem
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
                dvTabItem.Style.Add("left", "3px");
            else
                dvTabItem.Style.Add("left", "-3px");
        }
    }

    protected void lnkb_Click(object sender, EventArgs e)
    {
        if (OnClick != null)
            OnClick(sender, e);
    }

    public override int Width
    {
        set
        {
            if (value > 0)
                dvTabItem.Style.Add("width", value.ToString() + "px");
        }
    }
}
