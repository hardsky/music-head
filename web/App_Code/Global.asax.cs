using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Routing;
using Jam;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global : HttpApplication
{
    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
		routes.Add ( "default", JamRouteFactory.CreateRoute ( "{lang}", "~/Default.aspx" ) );
		routes.Add ( "registration", JamRouteFactory.CreateRoute ( "{lang}/registration", "~/Registration.aspx" ) );
        routes.Add("password", JamRouteFactory.CreateRoute("{lang}/password", "~/RememberPsw.aspx"));

		routes.Add ( "rss", JamRouteFactory.CreateRoute ( "{lang}/rss/{rss_type}", "~/rssfeed.aspx" ) );

		//by name
		routes.Add ( "folks", JamRouteFactory.CreateRoute ( "{lang}/folks", "~/Folks.aspx" ) );
		routes.Add ( "folk", JamRouteFactory.CreateRoute ( "{lang}/folks/{name}", "~/Art.aspx" ) );
		routes.Add ( "bands", JamRouteFactory.CreateRoute ( "{lang}/bands", "~/Bands.aspx" ) );
		routes.Add ( "band", JamRouteFactory.CreateRoute ( "{lang}/bands/{name}", "~/Band.aspx" ) );

        //by id
		routes.Add ( "music", JamRouteFactory.CreateRoute ( "{lang}/music", "~/Music.aspx" ) );
		routes.Add ( "song", JamRouteFactory.CreateRoute ( "{lang}/music/{song_id}", "~/Track.aspx" ) );
		routes.Add ( "lyrics", JamRouteFactory.CreateRoute ( "{lang}/lyrics", "~/Lyrics.aspx" ) );
		routes.Add ( "poem", JamRouteFactory.CreateRoute ( "{lang}/lyrics/{poem_id}", "~/Lyric.aspx" ) );
		routes.Add ( "video", JamRouteFactory.CreateRoute ( "{lang}/video", "~/Video.aspx" ) );
		routes.Add ( "clip", JamRouteFactory.CreateRoute ( "{lang}/video/{clip_id}", "~/Clip.aspx" ) );

		routes.Add ( "lfg", JamRouteFactory.CreateRoute ( "{lang}/lfg", "~/Looking.aspx" ) );

		routes.Add ( "about", JamRouteFactory.CreateRoute ( "{lang}/about", "~/About.aspx" ) );
		routes.Add ( "charts", JamRouteFactory.CreateRoute ( "{lang}/charts", "~/Charts.aspx" ) );
		routes.Add ( "events", JamRouteFactory.CreateRoute ( "{lang}/events", "~/Events.aspx" ) );
		routes.Add ( "news", JamRouteFactory.CreateRoute ( "{lang}/news", "~/News.aspx" ) );
		routes.Add ( "news_issue", JamRouteFactory.CreateRoute ( "{lang}/news/{id}", "~/SiteNews.aspx" ) );

		routes.Add ( "forum", JamRouteFactory.CreateRoute ( "{lang}/forum", "~/Forum.aspx" ) );
		routes.Add ( "forum_sub", JamRouteFactory.CreateRoute ( "{lang}/forum/{subforum_id}", "~/SubForum.aspx" ) );
		routes.Add ( "forum_sub_subject", JamRouteFactory.CreateRoute ( "{lang}/forum/{subforum_id}/{subj_id}", "~/ForumSubj.aspx" ) );
		routes.Add ( "forum_sub_subject_message", JamRouteFactory.CreateRoute ( "{lang}/forum/{part}/{id}/create", "~/ForumSubj.aspx" ) );

		//my
		routes.Add ( "my", JamRouteFactory.CreateRoute ( "{lang}/my", "~/MyArt.aspx" ) );
		routes.Add ( "my_bands", JamRouteFactory.CreateRoute ( "{lang}/my/bands", "~/MyBands.aspx" ) );
		routes.Add ( "my_band", JamRouteFactory.CreateRoute ( "{lang}/my/bands/{name}", "~/MyBand.aspx" ) );
		routes.Add ( "my_music", JamRouteFactory.CreateRoute ( "{lang}/my/music", "~/MyMusic.aspx" ) );
		routes.Add ( "my_lyrics", JamRouteFactory.CreateRoute ( "{lang}/my/lyrics", "~/MyLyrics.aspx" ) );
		routes.Add ( "my_video", JamRouteFactory.CreateRoute ( "{lang}/my/video", "~/MyVideo.aspx" ) );
		routes.Add ( "my_invites", JamRouteFactory.CreateRoute ( "{lang}/my/invites", "~/MyInvites.aspx" ) );
		routes.Add ( "my_lfb", JamRouteFactory.CreateRoute ( "{lang}/my/looking_for_band", "~/MyLFB.aspx" ) );
		routes.Add ( "my_lfp", JamRouteFactory.CreateRoute ( "{lang}/my/looking_for_musicians", "~/MyLFP.aspx" ) );
		routes.Add ( "my_news", JamRouteFactory.CreateRoute ( "{lang}/my/news", "~/MyNews.aspx" ) );
		routes.Add ( "my_raider", JamRouteFactory.CreateRoute ( "{lang}/my/raider", "~/MyRaider.aspx" ) );
		routes.Add ( "my_messages", JamRouteFactory.CreateRoute ( "{lang}/my/messages", "~/Messages.aspx" ) );
		routes.Add ( "my_messages_create", JamRouteFactory.CreateRoute ( "{lang}/my/messages/create", "~/CreateMessage.aspx" ) );
		routes.Add ( "my_music_edit", JamRouteFactory.CreateRoute ( "{lang}/my/music/{id}", "~/EditTrack.aspx" ) );
		routes.Add ( "my_video_edit", JamRouteFactory.CreateRoute ( "{lang}/my/video/{id}", "~/EditVideo.aspx" ) );

		//site admin
		routes.Add ( "site_news", JamRouteFactory.CreateRoute ( "{lang}/site/news", "~/WriteSiteNews.aspx" ) );

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

}
