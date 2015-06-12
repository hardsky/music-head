using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;

public partial class MyLFB : JamPage
{
    public MyLFB()
    {
        m_Code = 51;
        bDoLocalize = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillForm();
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        if (!IsPostBack)
        {
            LocalizeControls();
        }
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Id, LookingFor, Comment from looking_band where Creater=?UserId order by Created DESC", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
                {
                    rpSeachedBands.Visible = true;
                    btnDelete.Visible = true;
                    rpSeachedBands.DataSource = ds;
                    rpSeachedBands.DataBind();
                }
                else
                {
                    rpSeachedBands.Visible = false;
                    btnDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyLFB", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        tblDetails.Visible = false;
        btnAdd.Visible = true;
        btnDelete.Visible = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ctrDetails.Save())
            Response.Redirect("~/MyLFB.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        tblDetails.Visible = true;
        btnAdd.Visible = false;
        btnDelete.Visible = false;
        ctrDetails.FillForm();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string sIds = "";
        foreach (RepeaterItem item in rpSeachedBands.Items)
        {
            if ((item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem))
            {
                CheckBox cb = item.FindControl("cbSelected") as CheckBox;
                if (cb != null && cb.Checked)
                {
                    HiddenField hd = item.FindControl("hdId") as HiddenField;
                    if (hd != null)
                        sIds += hd.Value + ",";
                }
            }
        }

        sIds = sIds.TrimEnd(',');

        if (!String.IsNullOrEmpty(sIds))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("delete from looking_band where Id in ('" + sIds + "')", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyLFP", "btnDelete_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            FillForm();
        }
    }
}
