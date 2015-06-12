using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;

public partial class UIControls_VideoFragment : JamUIControl
{
    public UIControls_VideoFragment()
    {
        m_Code = 13;
    }

    public PlaceHolder Player
    {
        get
        {
            return phPlayer;
        }
    }

    public string Title
    {
        set
        {
            lbTitle.Text = value;
        }
    }

    public string Author
    {
        set
        {
			if ( String.IsNullOrEmpty ( value ) )
			{
				trAuthor.Visible = false;
				return;
			}
			else
			{
				trAuthor.Visible = true;
			}

            hlAuthor.Text = value;
            hlAuthor.NavigateUrl = Jam.JamRouteUrl.PickUp ( "folk", 
				this.LangEnum, 
				new System.Collections.Generic.Dictionary<string, string> ( ) { { "name", value } } );
        }
    }

    public string Band
    {
        set
        {
            lbBand.Text = value;
            trBand.Visible = !String.IsNullOrEmpty(value);
        }
    }

    public string Style
    {
        set
        {
            lbStyle.Text = value;
            trStyle.Visible = !String.IsNullOrEmpty(value);
        }
    }

    public string ClipId
    {
        set
        {
			if ( String.IsNullOrEmpty ( value ) )
			{
				trMore.Visible = false;
				return;
			}

			trMore.Visible = true;
            hlMore.NavigateUrl = Jam.JamRouteUrl.PickUp("clip", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "clip_id", value } });
        }
    }

    public string Language
    {
        set
        {
            lbLang.Text = value;
            trLang.Visible = !String.IsNullOrEmpty(value);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
