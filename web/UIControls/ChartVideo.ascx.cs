using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;

public partial class UIControls_ChartVideo : TabControl
{
    public UIControls_ChartVideo()
    {
        m_Code = 46;
        bDoLocalize = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    override public void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select 
video.Id as id, 
video.Title as Title, 
ui.SiteName as ArtName, 
bands.Name as BandName, 
video.Style,  
SUM(rates.Vote) as Rating
from video left outer join (rates, commentsubjtables) on 
(video.Id=rates.SubjId and rates.SubjTableId=commentsubjtables.Id and commentsubjtables.TableName='video') 
left outer join (userinfo as ui) on (video.Author=ui.Id) left outer join bands on video.BandId=bands.Id
where video.Deleted=0 
", con);

                if (UserInfo != null)
                {
                    cmd.CommandText += @" and (video.Author=?UserId or video.Visibility IS NULL or video.Visibility=0 or video.Visibility=1 or 
(video.Visibility=3 and video.BandId is Not null and 
?UserId in (select UserId from usertoband where usertoband.BandId=video.BandId and usertoband.Deleted=0)))";
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                }
                else
                {
                    cmd.CommandText += " and (video.Visibility IS NULL or video.Visibility=0)";
                }

                cmd.CommandText += "group by video.Id order by Rating desc, Title limit 100";

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                rpChartVideo.DataSource = ds;
                rpChartVideo.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "ChartVideo", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void rpChartVideo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LocalizeControls(e.Item.Controls);
        DataRowView drv = (DataRowView)e.Item.DataItem;
        if (drv != null)
        {
            HyperLink hl = e.Item.FindControl("hlComments") as HyperLink;
            if (hl != null)
                hl.Text += " (" + GetCommentsCount(drv["id"]) + ")";
        }
    }
    private string GetCommentsCount(object oId)
    {
        string sCommentsCount = "";
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select count(*) as cnt from comments, commentsubjtables, userinfo 
where comments.SubjId=?SubjId and comments.SubjTableId=commentsubjtables.Id and commentsubjtables.TableName=?SubjKind and comments.Author=userinfo.Id", con);
                cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = oId;
                cmd.Parameters.Add("?SubjKind", MySqlDbType.VarChar, 30).Value = "video";
                sCommentsCount = "0";
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        sCommentsCount = rdr.GetString("cnt");
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "ChartVideo", "GetCommentsCount: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return sCommentsCount;
    }
}
