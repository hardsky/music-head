using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Web.Routing;
using System.Web.UI.HtmlControls;

public partial class MainMenu : Jam.JamUIControl
{
    public MainMenu()
    {
        m_Code = 1; //used in site_interface table
    }

	protected override void OnLoad ( EventArgs e )
	{
		//if ( !IsPostBack )
		{
			string sHomeUrl = null;
			if ( UserInfo != null && !String.IsNullOrEmpty ( UserInfo.Id ) )
			{
                sHomeUrl = JamRouteUrl.PickUp("folk", this.LangEnum, new Dictionary<string, string>() { {"name", UserInfo.Name}});
			}
			else
			{
				sHomeUrl = JamRouteUrl.PickUp ( "default", this.LangEnum, null );
			}

			string [] arUrls = new string []{
				sHomeUrl,
				JamRouteUrl.PickUp("folks", this.LangEnum, null),
				JamRouteUrl.PickUp("bands", this.LangEnum, null),
				JamRouteUrl.PickUp("lyrics", this.LangEnum, null),
				JamRouteUrl.PickUp("music", this.LangEnum, null),
				JamRouteUrl.PickUp("lfg", this.LangEnum, null),
				JamRouteUrl.PickUp("forum", this.LangEnum, null)
			};

			//link Ids (needed for localization from base. see parent class)
			string [] arIds = new string [] {
				"hlHome",
				"hlArtists",
				"hlGroups",
				"hlLyrics",
				"hlMusic",
				"hlLFG",
				"hlForum"
			};

			JamPage pg = (JamPage) Page;
			string [] arCssClasses = new string []{
				(pg.Code == 6 || pg.Code == 38) ? "csRoundMenuSelect" : "csRoundMenu", //home
				(pg.Code == 7) ? "csRoundMenuSelect" : "csRoundMenu", //folks
				(pg.Code == 8) ? "csRoundMenuSelect" : "csRoundMenu", //Bands
				(pg.Code == 11) ? "csRoundMenuSelect" : "csRoundMenu", //lyrics
				(pg.Code == 12) ? "csRoundMenuSelect" : "csRoundMenu", //music
				(pg.Code == 201) ? "csRoundMenuSelect" : "csRoundMenu", //looking
				(pg.Code == 14) ? "csRoundMenuSelect" : "csRoundMenu" //forum
			};

			string [] arDefaultText = new string [] {
				"Home",
				"Folks",
				"Bands",
				"Lyrics",
				"Music",
				"Search",
				"Forum"
			};

			for ( int i = 0; i < arIds.Length; i++ )
			{
				dvTopMenu.Controls.Add (
					CreateMenuCell ( arIds [ i ], arUrls [ i ], arDefaultText[i], arCssClasses [ i ] )
				);
			}
		}

		base.OnLoad ( e	);//now localize
	}

	HtmlGenericControl CreateMenuCell ( string sLinkId, string sUrl, string sDefaultText, string sCssClass )
	{
		/*
    <div id="dvHome" class="csRoundMenu" runat="server">
        <div>
            <div>
                <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>&nbsp;
            </div>
        </div>
    </div>
		 */

		HtmlGenericControl div1 = new HtmlGenericControl ( "div" );
		div1.Attributes [ "class" ] = sCssClass;

		HtmlGenericControl div2 = new HtmlGenericControl ( "div" );
		HtmlGenericControl div3 = new HtmlGenericControl ( "div" );

		HyperLink link = new HyperLink ( );
		link.ID = sLinkId;
		link.NavigateUrl = sUrl;
		link.Text = sDefaultText;

		div1.Controls.Add ( div2 );
		div2.Controls.Add ( div3 );
		div3.Controls.Add ( link );

		return div1;
	}
}
