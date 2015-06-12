using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class UIControls_Finder : JamUIControl
{
    public JamTypes.UI.ButtonClick onFindBtnClick;

    #region Visibility
    public bool AddBand
    {
        get
        {
            return ViewState["AddBand"] != null ? (bool)ViewState["AddBand"] : false;
        }
        set
        {
            ViewState["AddBand"] = value;
        }
    }
    public bool AddAuthor
    {
        get
        {
            return ViewState["AddAuthor"] != null ? (bool)ViewState["AddAuthor"] : false;
        }
        set
        {
            ViewState["AddAuthor"] = value;
        }
    }
    #endregion

    #region Filter
    public string Name
    {
        get
        {
            return (string)ViewState["FinderName"];
        }
        set
        {
            ViewState["FinderName"] = value;
        }
    }

    public string Author
    {
        get
        {
            return (string)ViewState["FinderAuthor"];
        }
        set
        {
            ViewState["FinderAuthor"] = value;
        }
    }

    public string Band
    {
        get
        {
            return (string)ViewState["FinderBand"];
        }
        set
        {
            ViewState["FinderBand"] = value;
        }
    }

    public string Style
    {
        get
        {
            return (string)ViewState["FinderStyle"];
        }
        set
        {
            ViewState["FinderStyle"] = value;
        }
    }

    public string Lang
    {
        get
        {
            return (string)ViewState["FinderLang"];
        }
        set
        {
            ViewState["FinderLang"] = value;
        }
    }
    #endregion

    public UIControls_Finder()
    {
        m_Code = 10;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            trAuthor.Visible = AddAuthor;
            trBand.Visible = AddBand;
        }
        this.Page.Form.DefaultButton = btnFind.UniqueID;
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        //paradigm: in sql query use function LOWER, and params pass to query in low case.
        Name = Utils.SQLEscape(tbName.Text).ToLower();
        Author = Utils.SQLEscape(tbAuthor.Text).ToLower();
        Band = Utils.SQLEscape(tbBand.Text).ToLower();
        Style = Utils.SQLEscape(tbStyle.Text).ToLower();
        Lang = Utils.SQLEscape(tbLang.Text).ToLower();

        if (onFindBtnClick != null)
            onFindBtnClick(sender, e);
    }
}
