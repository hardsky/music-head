using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using System.Web.UI.HtmlControls;

public class TabContainer : JamUIControl
{
    private TabControl m_ctr = null;
    protected string[] arMenuCommand;
    protected string[] arMenuText;
    protected string[] arTabs;

    protected PlaceHolder m_phMenu;
    protected PlaceHolder m_phControl;

    protected string m_sMenuItem = "~/UIControls/TabMenuItem.ascx";
    protected string m_sSelectedMenuItem = "~/UIControls/TabMenuSelectedItem.ascx";

    protected int m_nMenuItemWidth = -1;

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

    protected override void OnLoad(EventArgs e)
    {
        CreateContainer();
        CreateMenu();
        CreateForm();

        if (!IsPostBack)
            m_ctr.FillForm();

        base.OnLoad(e);
    }

    private void CreateContainer()
    {
        /*
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
        <div class="csChartMenu">
            <asp:PlaceHolder ID="phMenu" runat="server"></asp:PlaceHolder>
        </div>
        <asp:PlaceHolder ID="phControl" runat="server"></asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
         */

        UpdatePanel upd = new UpdatePanel();
        upd.ID = "upd_TabContainer";
        upd.ChildrenAsTriggers = true;
        //upd.ContentTemplate
        HtmlGenericControl dv = new HtmlGenericControl("div");
        dv.ID = "dvMenu_TabContainer";
        dv.Attributes["class"] = "csTabMenu";
        m_phMenu = new PlaceHolder();
        m_phMenu.ID = "phMenu_TabContainer";
        dv.Controls.Add(m_phMenu);
        upd.ContentTemplateContainer.Controls.Add(dv);
        m_phControl = new PlaceHolder();
        m_phControl.ID = "phControl_TabContainer";
        upd.ContentTemplateContainer.Controls.Add(m_phControl);
        this.Controls.Add(upd);
    }

    private void CreateMenu()
    {
        int nFirstIdxForText = FindFirstIdxForText();
        bool bLeft = true;
        for (int i = 0; i < arMenuCommand.Length; i++)
        {
            Control ctrItem = null;
            if (i == SelectedMenuIdx)
            {
                bLeft = false;
                ctrItem = CreateSelectedMenuItem(i, nFirstIdxForText);
            }
            else
            {
                ctrItem = CreateMenuItem(i, nFirstIdxForText, bLeft);
            }

            m_phMenu.Controls.Add(ctrItem);
        }
    }

    private int FindFirstIdxForText()
    {
        for (int i = 0; i < m_arLanguages.Length; i++)
        {
            if (m_arLanguages[i] == LangEnum)
            {
                return i;
            }
        }

        return 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nItemIdx"></param>
    /// <param name="bLeft">indicate that item is situated left from selected item (true) or right (false)</param>
    /// <returns></returns>
    private Control CreateMenuItem(int nCommandIdx, int nFirstIdxForText, bool bLeft)
    {
        TabMenuItem ctr = (TabMenuItem)LoadControl(m_sMenuItem);
        ctr.Width = m_nMenuItemWidth;
        ctr.ID = "Tab_Item_" + nCommandIdx.ToString();
        ctr.Left = bLeft;
        ctr.Text = arMenuText[nFirstIdxForText + nCommandIdx * m_arLanguages.Length];
        ctr.OnClick -= new EventHandler(OnItemClick);
        ctr.OnClick += new EventHandler(OnItemClick);
        ctr.Idx = nCommandIdx;

        return ctr;
    }

    private Control CreateSelectedMenuItem(int nCommandIdx, int nFirstIdxForText)
    {
        TabMenuSelectedItem ctr = (TabMenuSelectedItem)LoadControl(m_sSelectedMenuItem);
        ctr.Text = arMenuText[nFirstIdxForText + nCommandIdx * m_arLanguages.Length];
        ctr.Idx = nCommandIdx;
        if (m_nMenuItemWidth > 0)
        ctr.Width = m_nMenuItemWidth + 1;

        return ctr;
    }

    private void OnItemClick(object sender, EventArgs e)
    {
        TabMenuItem itm = null;
        Control ctr = sender as Control;
        if (ctr != null)
        {
            itm = FindParentTabItem(ctr);
        }
        if (itm != null)
        {
            SelectedMenuIdx = itm.Idx;
            this.Controls.Clear();
            CreateContainer();
            m_phMenu.Controls.Clear();
            CreateMenu();
            CreateForm();
            m_ctr.FillForm();
        }
    }

    private TabMenuItem FindParentTabItem(Control ctr)
    {
        if (ctr == null)
            return null;

        if (ctr is TabMenuItem)
            return (TabMenuItem)ctr;

        return FindParentTabItem(ctr.Parent);
    }

    private void CreateForm()
    {
        m_phControl.Controls.Clear();
        m_ctr = (TabControl)LoadControl(arTabs[SelectedMenuIdx]);
        m_phControl.Controls.Add(m_ctr);
    }
}

public class TabMenuItem : TabMenuSelectedItem
{
    public virtual bool Left
    {
        set
        {
            
        }
    }

    public EventHandler OnClick;
}

public class TabMenuSelectedItem : System.Web.UI.UserControl
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

    virtual public string Text
    {
        set
        {
        }
    }

    virtual public int Width
    {
        set
        {
        }
    }
}

abstract public class TabControl: JamUIControl
{
    abstract public void FillForm();
}