using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UIControls_TabConteinerControl : System.Web.UI.UserControl
{
    string[] arMenuCommand = new string[] {
        "lyrics",
        "music",
        "video"
    };
    string[] m_arLanguages = new string[]{
        "en",
        "ru"
    };
    string[] arMenuText = new string[] {
        "Стихи",
        "Музыка",
        "Видео"
    };
    string[] arTabs = new string[]{
    };

    private int SelectedMenuIdx
    {
        get
        {
            return ViewState["SelectedMenuIdx"] != null ? (int)ViewState["SelectedMenuIdx"] : 0;
        }
        set
        {
            ViewState["SelectedMenuIdx"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CreateMenu();
        if (!IsPostBack)
        {
            FillForm();
        }
    }

    private void CreateMenu()
    {
        bool bLeft = true;
        for (int i = 0; i < arMenuText.Length; i++)
        {
            Control ctrItem = null;
            if (i == SelectedMenuIdx)
            {
                bLeft = false;
                ctrItem = CreateSelectedMenuItem(i);
            }
            else
            {
                ctrItem = CreateMenuItem(i, bLeft);
            }

            phMenu.Controls.Add(ctrItem);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nItemIdx"></param>
    /// <param name="bLeft">indicate that item is situated left from selected item (true) or right (false)</param>
    /// <returns></returns>
    private Control CreateMenuItem(int nItemIdx, bool bLeft)
    {
        /*
        UIControls_ChartMenuItem ctr = (UIControls_ChartMenuItem)LoadControl("~/UIControls/ChartMenuItem.ascx");
        ctr.ID = "Chart_Item_" + nItemIdx.ToString();
        ctr.Left = bLeft;
        ctr.Text = arMenuText[nItemIdx];
        ctr.OnClick -= new EventHandler(OnItemClick);
        ctr.OnClick += new EventHandler(OnItemClick);
        ctr.Idx = nItemIdx;

        return ctr;
         */

        return null;
    }

    private Control CreateSelectedMenuItem(int nItemIdx)
    {
        /*
        UIControls_ChartMenuSelectedItem ctr = (UIControls_ChartMenuSelectedItem)LoadControl("~/UIControls/ChartMenuSelectedItem.ascx");
        ctr.Text = arMenuText[nItemIdx];
        ctr.Idx = nItemIdx;

        return ctr;
         */
        return null;
    }

    private void OnItemClick(object sender, EventArgs e)
    {
        ChartMenuItem itm = null;
        Control ctr = sender as Control;
        if (ctr != null)
        {
            itm = FindParentChartItem(ctr);
        }
        if (itm != null)
        {
            SelectedMenuIdx = itm.Idx;
            phMenu.Controls.Clear();
            CreateMenu();
            FillForm();
        }
    }

    private ChartMenuItem FindParentChartItem(Control ctr)
    {
        if (ctr == null)
            return null;

        if (ctr is ChartMenuItem)
            return (ChartMenuItem)ctr;

        return FindParentChartItem(ctr.Parent);
    }

    private void FillForm()
    {
        for (int i = 0; i < arMenuCommand.Length; i++)
        {
            ChartControl ctr = null;

            switch (arMenuCommand[i])
            {
                case "music":
                    {
                        //ctr = ctrMusic;
                    }
                    break;
                case "video":
                    {
                        //ctr = ctrVideo;
                    }
                    break;
                default:
                    {
                        //ctr = ctrLyrics;
                    }
                    break;
            }

            Control as_ctr = (Control)ctr;
            if (i == SelectedMenuIdx)
            {
                ctr.FillForm();
                as_ctr.Visible = true;
            }
            else
            {
                as_ctr.Visible = false;
            }
        }
    }
}
