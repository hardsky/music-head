using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

public partial class MyMusic : JamPage
{
    public MyMusic()
    {
        m_Code = 20;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*
<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0" width="400" height="170" id="xspf_player" align="middle">
<param name="allowScriptAccess" value="sameDomain" />
<param name="movie" value="/web/Player/xspf_player.swf?playlist_url=http://localhost:3709/web/Player/playlistlist.xspf&autoload=true" />
<param name="quality" value="high" />
<param name="bgcolor" value="#e6e6e6" />
<embed src="/web/Player/xspf_player.swf?playlist_url=http://localhost:3709/web/Player/playlistlist.xspf&autoload=true" quality="high" bgcolor="#e6e6e6" width="400" height="170" name="xspf_player" align="middle" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
</object>
             */
            btnDelete.Visible = false;
            FillGrid();
        }
    }

    private Control AddButtonPlayer(ulong nTrackId)
    {
        /*
<object type="application/x-shockwave-flash" data="http://musicplayer.sourceforge.net/button/musicplayer.swf?&amp;playlist_url=?playlist_url=allshows.xspf&amp;" width="17" height="17">
<param name="movie" value="http://musicplayer.sourceforge.net/button/musicplayer.swf?&amp;playlist_url=?playlist_url=allshows.xspf&amp;">
<img src="noflash.gif" alt="" width="17" height="17">
</object>
         */
        string sPlayer = String.Format(@"
<object type='application/x-shockwave-flash' data='{0}' width='17' height='17'>
<param name='movie' value='{0}'>
<img src='noflash.gif' alt='' width='17' height='17'>
</object>
", this.ResolveUrl("~/Player/Button/musicplayer.swf") + "?song_url=" + this.ResolveUrl("~/GetMusic.aspx?id=" + nTrackId));//this.ResolveUrl("~/Music/") + Uri.EscapeUriString(sFileName));
        HtmlGenericControl hc = new HtmlGenericControl();
        hc.InnerHtml = sPlayer;

        return hc;
    }

    private void FillGrid()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Id, Title, FileName, Description, Style, Language from music where Author = ?userId", con);
                cmd.Parameters.Add("?userId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvMusic.DataSource = ds;
                gvMusic.DataBind();

                if (gvMusic.Rows != null && gvMusic.Rows.Count > 0)
                {
                    btnDelete.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyMusic", "FillGrid: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void gvMusic_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            PlaceHolder ph = (PlaceHolder)e.Row.Cells[5].FindControl("phButtonPlayer");
            UInt64 nId = (UInt64)gvMusic.DataKeys[e.Row.RowIndex].Values["Id"];
            ph.Controls.Add(AddButtonPlayer(nId));
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvMusic.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("chSelected");
            if (cb.Checked)
            {
                DeleteTrack(row);
            }
        }

        Response.Redirect("~/MyMusic.aspx");
    }

    private void DeleteTrack(GridViewRow row)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                string sFileName = (string)gvMusic.DataKeys[row.RowIndex].Values["FileName"];
                UInt64 nId = (UInt64)gvMusic.DataKeys[row.RowIndex].Values["Id"];
                string sDeletePath = this.MapPath(sFileName);
                File.Delete(sDeletePath);

                MySqlCommand cmd = new MySqlCommand("delete from music where id = ?id and Author=?User", con);
                cmd.Parameters.Add("?id", MySqlDbType.UInt64).Value = nId;
                cmd.Parameters.Add("?User", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyMusic", "DeleteTrack: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EditTrack.aspx");
    }
}
