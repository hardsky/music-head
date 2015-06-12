using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class ForumSubj : JamPage
{
    public ForumSubj()
    {
        m_Code = 16;
    }

    private string SubjId
    {
        get
        {
            return (string)ViewState["SubjId"];
        }
        set
        {
            ViewState["SubjId"] = value;
        }
    }

    private string SubForumId
    {
        get
        {
            return (string)ViewState["SubForumId"];
        }
        set
        {
            ViewState["SubForumId"] = value;
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

            SubjId = (string)HttpContext.Current.Items["subj_id"];
            SubForumId = (string)HttpContext.Current.Items["subforum_id"];

            btnAnswer.Visible = IsRegisteredUser;
            SetForumPath();
            FillForm();

            SetPageTitleDescr(new string[] { 
                                lbSubject.Text, 
                                lbSubject.Text },
                new string[] { 
                    "Discussion about " + lbSubject.Text + ".", 
                    "Обсуждение " + lbSubject.Text + "."});
        }
    }

    private void SetForumPath()
    {
        hlForums.NavigateUrl = JamRouteUrl.PickUp("forum", this.LangEnum, null);
        if (!String.IsNullOrEmpty(SubjId))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select fm.Subj as SubForum, fm.Id as SubForumId, fs.Subj as Subject
from forum_main as fm, forum_subj as fs 
where fs.Id=?SubjId and fs.main_forum_id=fm.Id;", con);
                    cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = UInt64.Parse(SubjId);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        if (rdr.Read())
                        {
                            hlForum.Text = rdr.GetString("SubForum");
                            hlForum.NavigateUrl = Jam.JamRouteUrl.PickUp("forum_sub", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "subforum_id", rdr.GetUInt64("SubForumId").ToString() } });

                            lbSubject.Text = rdr.GetString("Subject");
                        }
                        rdr.Close();
                    }

                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "ForumSubj", "SetForumPath: " + ex.Message);
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
        if (!String.IsNullOrEmpty(SubjId))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select forum.Text, forum.Created, userinfo.SiteName as AuthorName, userinfo.UserPicId from forum, userinfo 
where forum.SubjId=?SubjId and forum.AuthorId=userinfo.Id order by forum.Created;", con);
                    cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = UInt64.Parse(SubjId);

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    gvSubj.DataSource = ds;
                    gvSubj.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "ForumSubj", "FillForm: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }

    protected void gvSubj_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;

            Image img = (Image)e.Row.Cells[0].FindControl("imgUserPic");
            string sUserPicId = dr["UserPicId"].ToString();
            img.ImageUrl = !String.IsNullOrEmpty(sUserPicId) ? "~/GetImage.aspx?id=" + sUserPicId : "~/img/userpic.gif";

            HyperLink hlName = (HyperLink)e.Row.Cells[0].FindControl("hlUser");
            hlName.Text = dr["AuthorName"].ToString();

            hlName.NavigateUrl = Jam.JamRouteUrl.PickUp("folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "name", hlName.Text } });
            hlName.CssClass = "spCommentUserName";

            object oCr = dr["Created"];
            if (oCr != null && oCr != DBNull.Value)
            {
                DateTime dt = (DateTime)oCr;
                if (UserInfo != null)
                    dt = dt + UserInfo.TimeZone;

                Label lbMessageHeader = (Label)e.Row.Cells[1].FindControl("lbMsgHead");
                lbMessageHeader.Text = "Posted on " + dt.ToString();
            }

            Label lbMessageBody = (Label)e.Row.Cells[1].FindControl("lbMsg");
            lbMessageBody.Text = dr["Text"].ToString();
        }
    }

    protected void btnAnswer_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ForumMessage.aspx?forumid=" + SubForumId + "&subjid=" + SubjId);
    }
    protected void gvSubj_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSubj.PageIndex = e.NewPageIndex;
        FillForm();
    }
}
