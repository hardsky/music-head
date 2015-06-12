using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;

public partial class UIControls_ChartLyrics : TabControl
{
    public UIControls_ChartLyrics()
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
lyrics.Id as lid, 
lyrics.Name as Title, 
ui.SiteName as ArtName, 
bands.Name as BandName, 
lyrics.Style,  
SUM(rates.Vote) as Rating
from lyrics left outer join (rates, commentsubjtables) on 
(lyrics.Id=rates.SubjId and rates.SubjTableId=commentsubjtables.Id and commentsubjtables.TableName='lyrics') 
left outer join (userinfo as ui) on (lyrics.Author=ui.Id) left outer join bands on lyrics.BandId=bands.Id
where lyrics.Deleted=0 
", con);

                if (UserInfo != null)
                {
                    cmd.CommandText += @" and (lyrics.Author=?UserId or lyrics.Visibility IS NULL or lyrics.Visibility=0 or lyrics.Visibility=1 or 
(lyrics.Visibility=3 and lyrics.BandId is Not null and 
?UserId in (select UserId from usertoband where usertoband.BandId=lyrics.BandId and usertoband.Deleted=0)))";
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                }
                else
                {
                    cmd.CommandText += " and (lyrics.Visibility IS NULL or lyrics.Visibility=0)";
                }

                cmd.CommandText += "group by lyrics.Id order by Rating desc, Title limit 100";

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                rpChartLyrics.DataSource = ds;
                rpChartLyrics.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "ChartLyrics", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void rpChartLyrics_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LocalizeControls(e.Item.Controls);
        DataRowView drv = (DataRowView)e.Item.DataItem;
        if (drv != null)
        {
            HyperLink hl = e.Item.FindControl("hlComments") as HyperLink;
            if (hl != null)
                hl.Text += " (" + GetCommentsCount(drv["lid"]) + ")";
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
                cmd.Parameters.Add("?SubjKind", MySqlDbType.VarChar, 30).Value = "lyrics";
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
                JamLog.log(JamLog.enEntryType.error, "ChartLyrics", "GetCommentsCount: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return sCommentsCount;
    }
}
