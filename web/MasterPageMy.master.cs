using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MySql.Data.MySqlClient;
using Jam;

public partial class MasterPageMy : System.Web.UI.MasterPage
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

    protected ulong m_Code = 49; //used in site_interface table

    protected void LocalizeControls()
    {
        Utils.CommonLocalize(m_Code, LangUId, this.Controls);
    }

    //!!! same as UserInfo in JamPage !!!
    private JamTypes.User UserInfo
    {
        get
        {
            return JamTypes.User.GetUserFromSession(Session);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int nMsgNum = 0;
        int nInvtNum = 0;
        if (UserInfo != null && UserInfo.UIntId > 0)
        {
            dvAvatar.Visible = true;
            ctrMyMenu.Visible = true;
            dvLogoutBtn.Visible = true;

            imgAvatar.ImageUrl = UserInfo.AvatarPath;

            nMsgNum = getMsgNums();
            nInvtNum = getInvtNums();
        }
        else
        {
            dvAvatar.Visible = false;
            ctrMyMenu.Visible = false;
            dvLogoutBtn.Visible = false;
        }

        if (ctrMyMenu.Visible)
        {
            /*
            ctrMyMenu.m_arMenu = new UIControls_VerticalMenu.MenuItem[] { 
                            new UIControls_VerticalMenu.MenuItem("~/MyLyrics.aspx", "Мои стихи"),
                            new UIControls_VerticalMenu.MenuItem("~/MyMusic.aspx", "Моя музыка"),
                            new UIControls_VerticalMenu.MenuItem("~/MyVideo.aspx", "Мои видео"),
                            new UIControls_VerticalMenu.MenuItem("~/MyBands.aspx", "Мои группы"),
                            new UIControls_VerticalMenu.MenuItem("~/MyInvites.aspx", "Приглашения" + (nInvtNum > 0 ? " (" + nInvtNum.ToString() + ")": "")),
                            new UIControls_VerticalMenu.MenuItem("~/Messages.aspx", "Сообщения" + (nMsgNum > 0 ? " (" + nMsgNum.ToString() + ")": "")),
                            new UIControls_VerticalMenu.MenuItem("~/MyLFP.aspx", "Поиск людей"),
                            new UIControls_VerticalMenu.MenuItem("~/MyLFB.aspx", "Поиск групп"),
                            new UIControls_VerticalMenu.MenuItem("~/MyRaider.aspx", "Мой райдер"),
                            new UIControls_VerticalMenu.MenuItem("~/MyNews.aspx", "Мои новости"),
                            UserInfo.IsAdmin? new UIControls_VerticalMenu.MenuItem("~/WriteSiteNews.aspx", "Новости сайта"):null,
                            new UIControls_VerticalMenu.MenuItem("~/MyArt.aspx", "Настройки")
                            };*/
        }

        LocalizeControls();
    }

    private int getInvtNums()
    {
        int nRet = 0;
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select count(invites.Id) invt_num from invites where invites.UserId=?UserId", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("invt_num")))
                            nRet = rdr.GetInt32("invt_num");
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "string", "string: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return nRet;
    }

    private int getMsgNums()
    {
        int nRet = 0;
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(
@"select count(messages.Id) as msg_num
from messages, subjects where 
messages.RecipientDelete=0 and messages.ToId=?UserId and subjects.Id=messages.SubjId and messages.IsReaded=0", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("msg_num")))
                            nRet = rdr.GetInt32("msg_num");
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MasterPageMy", "geMsgNums: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return nRet;
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        JamTypes.User.ResetUserSession(Session);
        Response.Redirect(Request.RawUrl);
    }
}
