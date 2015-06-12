using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;

public partial class ForumMessage : JamPage
{
    public ForumMessage()
    {
        m_Code = 17;
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

    private bool IsOpSubjectCreate //true - subj create, false - answer
    {
        get
        {
            return (bool)ViewState["IsOpSubjectCreate"];
        }
        set
        {
            ViewState["IsOpSubjectCreate"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PrevLangId"] != null && Session["PrevLangId"] != Session["LANG_ID"])
            {
                Session["PrevLangId"] = Session["LANG_ID"];
                Response.Redirect("~/Forum.aspx");
            }
            else
            {
                Session["PrevLangId"] = Session["LANG_ID"];
            }

            ForumId = Request["forumid"];
            SubjId = Request["subjid"];
            if (!CheckPassed())
            {
                Visible = false;
                return;
            }

            FillForm();
        }
    }

    //if ForumId than create subj
    //if SubjId than answer
    private bool CheckPassed()
    {
        bool bForumEmpty = String.IsNullOrEmpty(ForumId);
        bool bSubjEmpty = String.IsNullOrEmpty(SubjId);

        if (bForumEmpty)
            return false;

        IsOpSubjectCreate = bSubjEmpty;

        return true;
    }

    private void FillForm()
    {
        if (IsOpSubjectCreate)
        {
            lbSubj.Visible = false;
            tbSubj.Visible = true;
        }
        else
        {
            lbSubj.Visible = true;
            FillSubj();

            tbSubj.Visible = false;
        }
    }

    private void FillSubj()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Subj from forum_subj where Id=?SubjId;", con);
                cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = UInt64.Parse(SubjId);

                lbSubj.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "ForumMessage", "FillSubj: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(ctrEditor.Content))
        {
            bool bSucceed = false;
            if (IsOpSubjectCreate)
            {
                if (!String.IsNullOrEmpty(tbSubj.Text))
                {
                    ulong nSubjId = 0;
                    MySqlConnection con = Utils.GetSqlConnection();
                    if (con != null)
                    {
                        MySqlTransaction trans = null;
                        try
                        {
                            ulong nForumId = ulong.Parse(ForumId);

                            trans = con.BeginTransaction();

                            DateTime dtNow = DateTime.UtcNow;
                            nSubjId = CreateSubj(nForumId, con, trans, dtNow);
                            AddAnswer(nSubjId, con, trans, dtNow);


                            trans.Commit();

                            bSucceed = true;
                        }
                        catch (Exception ex)
                        {
                            if (trans != null)
                                trans.Rollback();

                            JamLog.log(JamLog.enEntryType.error, "ForumMessage", "btnAdd_Click(CreateSubj): " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }

                    if (bSucceed)
                    {
						Response.Redirect ( Jam.JamRouteUrl.PickUp ( "forum_sub_subject", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "subforum_id", ForumId }, { "subj_id", nSubjId.ToString ( ) } } ) );
                    }
                }
            }
            else
            {
                ulong nSubjId = 0;
                MySqlConnection con = Utils.GetSqlConnection();
                if (con != null)
                {
                    MySqlTransaction trans = null;
                    try
                    {
                        nSubjId = ulong.Parse(SubjId);

                        trans = con.BeginTransaction();

                        AddAnswer(nSubjId, con, trans, DateTime.UtcNow);

                        trans.Commit();

                        bSucceed = true;
                    }
                    catch (Exception ex)
                    {
                        if (trans != null)
                            trans.Rollback();

                        JamLog.log(JamLog.enEntryType.error, "ForumMessage", "btnAdd_Click(AddAnswer): " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                if (bSucceed)
                {
                    Response.Redirect(Jam.JamRouteUrl.PickUp("forum_sub_subject", this.LangEnum, new System.Collections.Generic.Dictionary<string, string>() { { "subforum_id", ForumId }, { "subj_id", nSubjId.ToString() } }));
                }
            }
        }
    }

    private void AddAnswer(ulong nSubjId, MySqlConnection con, MySqlTransaction trans, DateTime dtNow)
    {
        MySqlCommand cmd = new MySqlCommand(@"insert into forum (SubjId, Text, AuthorId, Created, Updated) 
values(?SubjId, ?Text, ?AuthorId, ?Created, ?Created);", con, trans);
        cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = nSubjId;
        cmd.Parameters.Add("?Text", MySqlDbType.VarChar, 2048).Value = Utils.SQLEscape(ctrEditor.Content);
        cmd.Parameters.Add("?AuthorId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
        cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value = dtNow;

        cmd.ExecuteNonQuery();

        cmd = new MySqlCommand(@"update forum_subj set Updated=?Updated where Id=?SubjId;", con, trans);
        cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = nSubjId;
        cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = dtNow;
        cmd.ExecuteNonQuery();
    }

    private ulong CreateSubj(ulong nForumId, MySqlConnection con, MySqlTransaction trans, DateTime dtNow)
    {
        MySqlCommand cmd = new MySqlCommand(@"insert into forum_subj (main_forum_id, Subj, AuthorId, Created, Updated) 
values(?main_forum_id, ?Subj, ?AuthorId, ?Created, ?Created); SELECT LAST_INSERT_ID();", con, trans);
        cmd.Parameters.Add("?main_forum_id", MySqlDbType.UInt64).Value = nForumId;
        cmd.Parameters.Add("?Subj", MySqlDbType.VarChar, 80).Value = Utils.SQLEscape(tbSubj.Text);
        cmd.Parameters.Add("?AuthorId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
        cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value = dtNow;

        return Convert.ToUInt64(cmd.ExecuteScalar());
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (IsOpSubjectCreate)
        {
			Response.Redirect ( Jam.JamRouteUrl.PickUp ( "forum_sub", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "subforum_id", ForumId } } ) );
        }
        else
        {
			Response.Redirect ( Jam.JamRouteUrl.PickUp ( "forum_sub_subject", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "subforum_id", ForumId }, { "subj_id", SubjId } } ) );
        }
    }
    protected void btnPreview_Click(object sender, EventArgs e)
    {
        dvPreview.InnerHtml = ctrEditor.Content;
        dvPreview.Visible = true;
    }
}
