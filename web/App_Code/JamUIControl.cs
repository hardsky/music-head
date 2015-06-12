using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jam
{
    /// <summary>
    /// Summary description for JamUIControl
    /// </summary>
    public class JamUIControl : System.Web.UI.UserControl
    {
        protected bool bDoLocalize = true;
        //set by user; for localization stuff
        protected enLang[] m_arLanguages; //tabcontrol
        //

        protected ulong m_Code = 0; //used in site_interface table
        protected void LocalizeControls()
        {
            Utils.CommonLocalize(m_Code, LangUId, this.Controls);
        }

        protected void LocalizeControls(ControlCollection controls)
        {
            if (controls == null || controls.Count < 1)
                return;

            Utils.CommonLocalize(m_Code, LangUId, controls);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack && bDoLocalize)
            {
                LocalizeControls();
            }
        }

        public JamUIControl()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected JamTypes.User UserInfo
        {
            get
            {
                return JamTypes.User.GetUserFromSession(Session);
            }
            set
            {
                Session["JamUser_Info"] = value;
            }
        }

        protected ulong LangUId
        {
            get
            {
                return Utils.GetLangId(Response, Request, Session);
            }
        }

        protected enLang LangEnum
        {
            get
            {
                return Utils.GetLangEnum(Response, Request, Session);
            }
        }
    }
}
