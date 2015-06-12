using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UIControls_TabMenuSelectedItem : TabMenuSelectedItem
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

    public override int Width
    {
        set
        {
            if (value > 0)
                dvTabItem.Style.Add("width", value.ToString() + "px");
        }
    }
}