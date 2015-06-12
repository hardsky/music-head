using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class UIControls_UserComments : JamUIControl
{
    public UIControls_UserComments()
    {
        m_Code = 35;
    }

    public string SubjectID
    {
        get
        {
            return (string)ViewState["SubjectID"];
        }
        set
        {
            ViewState["SubjectID"] = value;
        }
    }

    public string SubjKind
    {
        get
        {
            return (string)ViewState["SubjKind"];
        }
        set
        {
            ViewState["SubjKind"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillForm();
            tbNewCommentTxt.Visible = btnAddComment.Visible = JamTypes.User.GetUserFromSession(Session) != null &&
                !String.IsNullOrEmpty(SubjectID) && !String.IsNullOrEmpty(SubjKind);
        }
    }
    protected void btnAddComment_Click(object sender, EventArgs e)
    {
        bool bSucceeded = false;

        if (!String.IsNullOrEmpty(SubjectID) && !String.IsNullOrEmpty(SubjKind) && JamTypes.User.GetUserFromSession(Session) != null)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    DateTime dtCreated = DateTime.UtcNow;
                    MySqlCommand cmd = new MySqlCommand(@"insert into comments (SubjId, Msg, Author, Created, Updated, SubjTableId) 
select ?SubjId as SubjId, ?Msg as Msg, ?Author as Author, ?Created as Created, ?Updated as Updated, Id as SubjTableId from commentsubjtables where TableName=?TableName", con);
                    cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = UInt64.Parse(SubjectID);
                    cmd.Parameters.Add("?Msg", MySqlDbType.VarChar, 1024).Value = Utils.SQLEscape(tbNewCommentTxt.Text.Trim());
                    cmd.Parameters.Add("?Author", MySqlDbType.UInt64).Value = JamTypes.User.GetUserFromSession(Session).UIntId;
                    cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value = dtCreated;
                    cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = dtCreated;
                    cmd.Parameters.Add("?TableName", MySqlDbType.VarChar, 30).Value = SubjKind;

                    cmd.ExecuteNonQuery();

                    bSucceeded = true;
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "UserComments", "btnAddComent: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }

                if (bSucceeded)
                    FillForm();
            }
        }
    }

    private void FillForm()
    {
        if (!String.IsNullOrEmpty(SubjectID) && !String.IsNullOrEmpty(SubjKind))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select comments.Author, comments.Msg, comments.Created, userinfo.SiteName as AuthorName, userinfo.UserPicId from comments, commentsubjtables, userinfo where comments.SubjId=?SubjId and comments.SubjTableId=commentsubjtables.Id and commentsubjtables.TableName=?SubjKind and comments.Author=userinfo.Id
                    order by comments.Created", con);
                    cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = UInt64.Parse(SubjectID);
                    cmd.Parameters.Add("?SubjKind", MySqlDbType.VarChar, 30).Value = SubjKind;

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    if (JamTypes.User.GetUserFromSession(Session) == null && (ds.Tables[0].Rows == null || ds.Tables[0].Rows.Count == 0))
                        trCom.Visible = false;
                    else
                        trCom.Visible = true;

                    gvComments.DataSource = ds;
                    gvComments.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "UserComments", "FillForm: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        tbNewCommentTxt.Text = "";
    }
    protected void gvComments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;

            Image img = (Image)e.Row.Cells[0].FindControl("imgUserPic");
            string sUserPicId = dr["UserPicId"].ToString();
            img.ImageUrl = !String.IsNullOrEmpty(sUserPicId) ? "~/GetImage.aspx?id=" + sUserPicId : "~/img/userpic.gif";

            HyperLink hl = (HyperLink)e.Row.Cells[0].FindControl("hlUser");
            hl.Text = dr["AuthorName"].ToString();
			hl.NavigateUrl = Jam.JamRouteUrl.PickUp ( "folk", this.LangEnum, new System.Collections.Generic.Dictionary<string, string> ( ) { { "name", hl.Text } } );

            object oCr = dr["Created"];
            if (oCr != null && oCr != DBNull.Value)
            {
                DateTime dt = (DateTime)oCr;
                if (UserInfo != null)
                {
                    dt = dt + UserInfo.TimeZone;
                }

                Label lbMessageHeader = (Label)e.Row.Cells[1].FindControl("lbMsgHead");
                lbMessageHeader.Text += " " + dt.ToString("dd.MM.yyyy hh:mm");
            }

            Label lbMessageBody = (Label)e.Row.Cells[1].FindControl("lbMsg");
            lbMessageBody.Text = dr["Msg"].ToString();
        }
    }
}
