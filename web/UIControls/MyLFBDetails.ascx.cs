using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class UIControls_MyLFBDetails : JamUIControl
{
    public UIControls_MyLFBDetails()
    {
        m_Code = 52;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void FillForm()
    {
        tbLooking.Text = "";
        tbCity.Text = "";
        tbComment.Text = "";
        tbCountry.Text = "";
        tbStyle.Text = "";

        FillLangDD();

        ddLangs.Text = "";
    }

    private void FillLangDD()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Language from userlanguages where UserId=?UserId", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
                {
                    lbLang.Visible = false;
                    ddLangs.Visible = true;
                    ddLangs.DataSource = ds;
                    ddLangs.DataBind();

                    ddLangs.Items.Insert(0, new ListItem(""));
                }
                else
                {
                    lbLang.Visible = true;
                    ddLangs.Visible = false;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_MyLFBDetails", "FillLangDD: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    public bool Save()
    {
        string sLooking = Utils.SQLEscape(tbLooking.Text.Trim());
        if (!String.IsNullOrEmpty(sLooking))
        {
            string sCity = Utils.SQLEscape(tbCity.Text.Trim());
            string sComment = Utils.SQLEscape(tbComment.Text.Trim());
            string sCountry = Utils.SQLEscape(tbCountry.Text.Trim());
            string sLang = ddLangs.Visible ? Utils.SQLEscape(ddLangs.Text.Trim()) : null;
            string sStyle = Utils.SQLEscape(tbStyle.Text.Trim());

            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"insert into looking_band 
(LookingFor, Country, City, Language, Created, Creater, Comment, Style)
values (?LookingFor, ?Country, ?City, ?Language, UTC_TIMESTAMP(), ?Creater, ?Comment, ?Style); select LAST_INSERT_ID();", con);
                    cmd.Parameters.Add("?LookingFor", MySqlDbType.VarChar, 80).Value = String.IsNullOrEmpty(sLooking) ? null : sLooking;
                    cmd.Parameters.Add("?Country", MySqlDbType.VarChar, 80).Value = String.IsNullOrEmpty(sCountry) ? null : sCountry;
                    cmd.Parameters.Add("?City", MySqlDbType.VarChar, 80).Value = String.IsNullOrEmpty(sCity) ? null : sCity;
                    cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = String.IsNullOrEmpty(sLang) ? null : sLang;
                    cmd.Parameters.Add("?Comment", MySqlDbType.VarChar, 255).Value = String.IsNullOrEmpty(sComment) ? null : sComment;
                    cmd.Parameters.Add("?Creater", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                    cmd.Parameters.Add("?Style", MySqlDbType.VarChar, 80).Value = String.IsNullOrEmpty(sStyle) ? null : sStyle;

                    object oId = cmd.ExecuteScalar();
                    if (oId != null && oId != DBNull.Value)
                    {
                        UInt64 nId = Convert.ToUInt64(oId);
                        if (nId > 0)
                            return true;
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "UIControls_MyLFBDetails", "Save: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        return false;
    }
}
