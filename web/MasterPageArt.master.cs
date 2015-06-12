﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MySql.Data.MySqlClient;
using Jam;

public partial class MasterPageArt : System.Web.UI.MasterPage
{
    protected enLang LangEnum
    {
        get
        {
            return Utils.GetLangEnum(Response, Request, Session);
        }
    }

    protected ulong LangUId
    {
        get
        {
            return Utils.GetLangId(Response, Request, Session);
        }
    }
    protected ulong m_Code = 45; //used in site_interface table
    protected void LocalizeControls()
    {
        Utils.CommonLocalize(m_Code, LangUId, this.form1.Controls);
    }
    //!!! same as UserInfo in JamPage !!!
    private JamTypes.User UserInfo
    {
        get
        {
            return JamTypes.User.GetUserFromSession(Session);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LocalizeControls();
    }

}
