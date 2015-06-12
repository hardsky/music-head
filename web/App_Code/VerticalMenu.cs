using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jam;

/// <summary>
/// Summary description for VerticalMenu
/// </summary>
public class VerticalMenu : JamUIControl
{
    public List<MenuItem> ItemsSchema
    {
        set
        {
            ViewState["ItemsSchema"] = value;
        }
        get
        {
            return (List<MenuItem>)ViewState["ItemsSchema"];
        }
    }

    [Serializable]
    public class MenuItem
    {
        string m_sUrl;
        string m_sName;
        bool m_bIsForAdmin = false;

        public string Url
        {
            get
            {
                return m_sUrl;
            }
            set
            {
                m_sUrl = value;
            }
        }

        public string Name
        {
            get
            {
                return m_sName;
            }
            set
            {
                m_sName = value;
            }
        }

        public bool IsForAdmin
        {
            get
            {
                return m_bIsForAdmin;
            }
            set
            {
                m_bIsForAdmin = value;
            }
        }

        public MenuItem(string sUrl, string sName, bool bIsForAdmin)
        {
            m_sUrl = sUrl;
            m_sName = sName;
            m_bIsForAdmin = bIsForAdmin;
        }

        public MenuItem(MenuItem item)
        {
            m_sUrl = item.m_sUrl;
            m_sName = item.m_sName;
            m_bIsForAdmin = item.m_bIsForAdmin;
        }
    }

    public VerticalMenu()
    {
        //
        // TODO: Add constructor logic here
        //
    }


}
