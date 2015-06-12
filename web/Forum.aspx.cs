using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;

public partial class Forum : JamPage
{
    public Forum()
    {
        m_Code = 14;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["PrevLangId"] = Session["LANG_ID"];
            FillForm();

            SetPageTitleDescr(new string[] { 
                                "Forum", 
                                "Форум" },
                new string[] { 
                    "Forum about music and lyrics.", 
                    "Форум, посвященный стихам, музыке."});
        }
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select fm.Id, fm.Subj, count(distinct fs.Id) as cnt_subj, 
count(distinct fr.Id) as cnt_msg, max(fr.Updated) as last_msg
from forum_main as fm left outer join (forum_subj as fs, forum as fr) on (fm.Id=fs.main_forum_id and fs.Id=fr.SubjId)
where fm.LangId=?LangId
group by fm.id", con);
                cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = LangUId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvForum.DataSource = ds;
                gvForum.DataBind();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Forum", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void gvForum_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            object obj = drv["last_msg"];
            if (obj != null && obj != DBNull.Value && UserInfo != null)
            {
                DateTime dt = (DateTime)obj;
                e.Row.Cells[3].Text = (dt + UserInfo.TimeZone).ToString();
            }
        }
    }
}
