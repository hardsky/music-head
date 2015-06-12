using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ChartMenuItem : System.Web.UI.UserControl
{
    public int Idx
    {
        get
        {
            return ViewState["Idx"] != null ? (int)ViewState["Idx"] : -1;
        }
        set
        {
            ViewState["Idx"] = value;
        }
    }
}

public interface ChartControl
{
    void FillForm();
}