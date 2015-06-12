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
using System.Web.Compilation;
using System.Collections.Generic;

namespace Jam
{
    public class JamRouteHandler : IRouteHandler
    {
        public JamRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        public string VirtualPath { get; private set; }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            foreach (var urlParm in requestContext.RouteData.Values)
            {
                requestContext.HttpContext.Items[urlParm.Key] = urlParm.Value;
            }

            var page = BuildManager.CreateInstanceFromVirtualPath
                 (VirtualPath, typeof(Page)) as IHttpHandler;
            return page;
        }

        #endregion
    }

    public class JamRouteFactory
    {
        public static Route CreateRoute(string sTemplate, string sVirtualPath)
        {
            //example: {lang}/foks/{name}
            string[] arParts = sTemplate.Split('/');
            if (arParts != null && arParts.Length > 0)
            {
                Route route = new Route (sTemplate, new Jam.JamRouteHandler(sVirtualPath));
				route.Defaults = new RouteValueDictionary ( );
				route.Defaults.Add ( "lang", "en" );
				route.Constraints = new RouteValueDictionary ( );
                route.Constraints.Add("lang", "[a-z]{2}");

                if (arParts.Length > 2)
                {
					for ( int i = 1; i < arParts.Length; i++ )
					{
						string sAction = arParts [ i ];
						if ( System.Text.RegularExpressions.Regex.IsMatch ( sAction, @"\{*\}" ) )
						{
							sAction = sAction.TrimStart ( '{' ).TrimEnd ( '}' );
							route.Constraints.Add ( sAction, @"[\w\- :\.,]*" );
						}
					}
                }

				return route;
            }

            return null;
        }
    }

	public class JamRouteUrl
	{
		public static string PickUp ( string sRouteName, enLang enSiteLang, Dictionary<string, string> dctParams )
		{

			if ( String.IsNullOrEmpty ( sRouteName ))
				return string.Empty;

			if ( dctParams != null )
			{
				var d = from c in dctParams.Values.ToArray ( ) where String.IsNullOrEmpty ( c ) select c;
				if ( d != null  && d.Count() > 0)
					return string.Empty;
			}

			RouteValueDictionary parameters = new RouteValueDictionary { { "lang", enSiteLang == enLang.ru ? "ru" : "en" } };

			if ( dctParams != null && dctParams.Count > 0 )
			{
				foreach ( KeyValuePair<string, string> param in dctParams )
				{
					parameters.Add ( param.Key, param.Value );
				}
			}

			VirtualPathData vpd = RouteTable.Routes.GetVirtualPath ( null, sRouteName, parameters );
			return vpd.VirtualPath;
		}
	}
}