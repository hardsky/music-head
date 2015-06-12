using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using MySql.Data.MySqlClient;
using Jam;
using System.IO;

public partial class rssfeed : JamPage
{
	enum enRssType
	{
		none,
		folks
	}

	protected void Page_Load ( object sender, EventArgs e )
	{
		if ( !IsPostBack )
		{
			string sFeedType = (string) HttpContext.Current.Items [ "rss_type" ];
			if ( !String.IsNullOrEmpty ( sFeedType ) )
			{
				sFeedType = sFeedType.ToLower ( ).Trim ( );

				switch ( sFeedType )
				{
					case "folks":
						CreateFolksFeed ( );
						break;
					default:
						break;
				}
			}
		}
	}

	private void CreateFolksFeed ( )
	{
		Response.ContentType = "application/rss+xml";
		Response.ContentEncoding = Encoding.UTF8;

		XmlTextWriter rsswriter = new XmlTextWriter ( Response.OutputStream, Encoding.UTF8 );

		WriteRssOpening ( rsswriter, "Музыканты music-head", "Список музыкантов, создавших аккаунт на сайте music-head.net" );

		FillFolksBody ( rsswriter );

		WriteRssEnding ( rsswriter );

		rsswriter.Flush ( );
		Response.End ( );
	}

	private void FillFolksBody ( XmlTextWriter rsswriter )
	{
		MySqlConnection con = Utils.GetSqlConnection ( );
		if ( con != null )
		{
			try
			{
				MySqlCommand cmd = new MySqlCommand ( "select SiteName, Created from userinfo where Deleted=0 order by Created desc", con );
				MySqlDataReader rdr = cmd.ExecuteReader ( );
				if ( rdr != null )
				{
					while ( rdr.Read() )
					{
						string sName = rdr.GetString("SiteName" );
						rsswriter.WriteStartElement ( "item" );
						rsswriter.WriteElementString ( "title", sName);
                        UriBuilder ub = new UriBuilder("http", Request.Url.Host, Request.Url.Port, JamRouteUrl.PickUp("folk", this.LangEnum, new Dictionary<string, string>() { { "name", sName } }));
                        string sLink = ub.ToString();
                        rsswriter.WriteElementString("link", sLink);
                        rsswriter.WriteElementString("pubDate", rdr.GetDateTime("Created").ToString("s"));
						rsswriter.WriteEndElement ( );
					}
					rdr.Close ( );
				}
			}
			catch ( Exception ex )
			{
				JamLog.log ( JamLog.enEntryType.error, "rssfeed:folks", "btnFind_Click: " + ex.Message );
			}
			finally
			{
				con.Close ( );
			}
		}
	}

	private void WriteRssOpening ( XmlTextWriter rsswriter, string sFeedTitle, string sFeedDescr )
	{
		rsswriter.WriteStartDocument ( );
		rsswriter.WriteStartElement ( "rss" );
		rsswriter.WriteAttributeString ( "version", "2.0" );
		rsswriter.WriteStartElement ( "channel" );
		rsswriter.WriteElementString ( "title", sFeedTitle );
        UriBuilder ub = new UriBuilder("http", Request.Url.Host, Request.Url.Port);
        rsswriter.WriteElementString("link", ub.ToString());
		rsswriter.WriteElementString ( "description", sFeedDescr );
	}

	private void WriteRssEnding ( XmlTextWriter rsswriter )
	{
		rsswriter.WriteEndElement ( );
		rsswriter.WriteEndElement ( );
	}
}
