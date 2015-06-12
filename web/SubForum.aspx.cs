using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;

public partial class SubForum : JamPage
{
    public SubForum()
    {
        m_Code = 15;
    }

    private string ForumId
    {
        get
        {
            return (string)ViewState["ForumId"];
        }
        set
        {
            ViewState["ForumId"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PrevLangId"] != null && Session["PrevLangId"] != Session["LANG_ID"])
            {
                Session["PrevLangId"] = Session["LANG_ID"];
                Response.Redirect(JamRouteUrl.PickUp("forum", this.LangEnum, null));
            }
            else
            {
                Session["PrevLangId"] = Session["LANG_ID"];
            }

            btnCreate.Visible = IsRegisteredUser;
            ForumId = (string)HttpContext.Current.Items["subforum_id"];
            SetCurForum();
            FillForm();
        }
    }

    private void SetCurForum()
    {
        hlForums.NavigateUrl = JamRouteUrl.PickUp("forum", this.LangEnum, null);
        if (!String.IsNullOrEmpty(ForumId))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Subj from forum_main where Id=?forumId;", con);
                    cmd.Parameters.Add("?forumId", MySqlDbType.UInt64).Value = UInt64.Parse(ForumId);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        if (rdr.Read())
                        {
                            lbCurForum.Text = rdr.GetString("Subj");
                        }
                        rdr.Close();
                    }

                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "SubForum", "SetCurForum: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select forum_subj.main_forum_id as subforum_id, forum_subj.Id as subj_id, forum_subj.Subj, userinfo.SiteName as AuthorName, 
count(forum.Id) as cnt_msg ,forum_subj.Updated 
from userinfo, forum_subj left outer join forum on forum.SubjId=forum_subj.Id 
where forum_subj.main_forum_id=?forumId and userinfo.Id=forum_subj.AuthorId 
group by forum_subj.Id order by forum_subj.Updated desc;", con);
                cmd.Parameters.Add("?forumId", MySqlDbType.UInt64).Value = UInt64.Parse(ForumId);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvForum.DataSource = ds;
                gvForum.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "SubForum", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ForumMessage.aspx?forumid=" + ForumId);
    }

    protected void gvForum_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvForum.PageIndex = e.NewPageIndex;
        FillForm();
    }
    protected void gvForum_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            object oUpd = drv["Updated"];
            if (oUpd != null && oUpd != DBNull.Value && UserInfo != null)
            {
                DateTime dt = (DateTime)oUpd;
                e.Row.Cells[3].Text = (dt + UserInfo.TimeZone).ToString();
            }
        }
    }
}
