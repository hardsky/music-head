using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;
using System.IO;

public partial class MyVideo : JamPage
{
    public MyVideo()
    {
        m_Code = 25;
    }
    /*
	<a class="flowplayer" href="http://localhost:3709/web/Video/5/a879bc39-80c9-4e50-bd53-2854f5a5fbbd_five.flv">
	<img src="img/2m.jpg" />
	</a>                
     */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnDelete.Visible = false;
            FillGrid();
        }
    }

    private void FillGrid()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Id, Title, Description, ImgId, FileName from video where Author = ?userId", con);
                cmd.Parameters.Add("?userId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvVideo.DataSource = ds;
                gvVideo.DataBind();

                if (gvVideo.Rows != null && gvVideo.Rows.Count > 0)
                {
                    btnDelete.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyVideo", "FillGrid: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void gvVideo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sId = gvVideo.DataKeys[e.Row.RowIndex].Values["Id"].ToString();
            PlaceHolder ph = (PlaceHolder)e.Row.Cells[1].FindControl("phPlayer");
            string sImgId = gvVideo.DataKeys[e.Row.RowIndex].Values["ImgId"].ToString();
            ph.Controls.Add(AddPlayer(sId, sImgId));

            HyperLink hl = (HyperLink)e.Row.Cells[3].FindControl("hlGo");
            hl.NavigateUrl = "~/EditVideo.aspx?id=" + sId;
        }
    }

    private Control AddPlayer(string sId, string sImageId)
    {
        StringBuilder sb = new StringBuilder(150);
        sb.AppendFormat("<a class=\"flowplayer\" href=\"{0}{1}\">", this.Request.Url.GetLeftPart(UriPartial.Authority), this.ResolveUrl("~/GetVideo.aspx?id=" + sId));
        if (!String.IsNullOrEmpty(sImageId))
        {
            sb.AppendFormat("<img src=\"{0}\" />", "./GetImage.aspx?id=" + sImageId);
        }
        else
        {
            sb.Append("<img src=\"img/video_cover.gif\" />");
        }
        sb.Append("</a>");

        HtmlGenericControl hc = new HtmlGenericControl();
        hc.InnerHtml = sb.ToString();

        return hc;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EditVideo.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvVideo.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("chSelected");
            if (cb.Checked)
            {
                DeleteClip(row);
            }
        }

        Response.Redirect("~/MyVideo.aspx");
    }

    private void DeleteClip(GridViewRow row)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                string sFileName = (string)gvVideo.DataKeys[row.RowIndex].Values["FileName"];
                UInt64 nId = (UInt64)gvVideo.DataKeys[row.RowIndex].Values["Id"];
                string sDeletePath = this.MapPath(sFileName);
                File.Delete(sDeletePath);

                MySqlCommand cmd = new MySqlCommand("delete from video where Id = ?id and Author=?User", con);
                cmd.Parameters.Add("?id", MySqlDbType.UInt64).Value = nId;
                cmd.Parameters.Add("?User", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyVideo", "DeleteClip: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
