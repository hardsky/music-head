using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace JamTypes
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    public class User
    {
        private string m_name;
        private string m_Id;
        private ulong m_nId;
        private TimeSpan m_TimeZone = TimeSpan.Zero;
        private string m_sAvatartPath = "~/img/userpic.gif";
        private bool m_bIsAdmin = false;

        public string Name { get { return m_name; } set { m_name = value; } }
        public string Id { get { return m_Id; } set { m_Id = value; } }
        public ulong UIntId { get { return m_nId; } set { m_nId = value; } }
        public TimeSpan TimeZone { get { return m_TimeZone; } set { m_TimeZone = value; } }
        public string AvatarPath { get { return m_sAvatartPath; } set { m_sAvatartPath = value; } }
        public bool IsAdmin { get { return m_bIsAdmin; } set { m_bIsAdmin = value; } }

        public User()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public User(string sName, ulong nId, TimeSpan tTZ, string sAvatarPath, bool bIsAdmin)
        {
            m_name = sName;
            m_Id = nId.ToString();
            m_nId = nId;
            m_TimeZone = tTZ;
            if (!String.IsNullOrEmpty(sAvatarPath))
                m_sAvatartPath = sAvatarPath;
            m_bIsAdmin = bIsAdmin;
        }

        static public User GetUserFromSession(HttpSessionState session)
        {
            return session != null ? (User)session["JamUser_Info"] : null;
        }

        public static void ResetUserSession(HttpSessionState session)
        {
            session["JamUser_Info"] = null;
        }
    }
}
