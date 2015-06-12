using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Jam;
using MySql.Data.MySqlClient;

public partial class SongWriter : JamPagePrivate
{
    public SongWriter()
    {
        m_Code = 19;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ItemId = Request["lid"];
            TableName = "lyrics";

            if (!IsAuthor()) //if ItemId is empty, function will return true;
            {
                this.Visible = false;
                return;
            }

            FillDDGroups(ddGroup);
            if (ddGroup.Items == null || ddGroup.Items.Count == 0)
            {
                trDDGroup.Visible = false;
            }

            FillDDVisibility(ddVisib);

            if (!String.IsNullOrEmpty(ItemId))
            {
                FillForm();
            }
        }
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Name, Text, Style, Language, BandId, Visibility from lyrics where id=?id and Deleted=0;", con);
                cmd.Parameters.Add("?id", MySqlDbType.UInt64).Value = UInt64.Parse(ItemId);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        tbTitle.Text = rdr.GetString("Name");
                        ctrEditor.Content = rdr.GetString("Text");
                        tbStyle.Text = !rdr.IsDBNull(rdr.GetOrdinal("Style")) ? rdr.GetString("Style") : "";
                        tbLang.Text = !rdr.IsDBNull(rdr.GetOrdinal("Language")) ? rdr.GetString("Language") : "";
                        ddGroup.SelectedValue = rdr.IsDBNull(rdr.GetOrdinal("BandId")) ? "" : rdr.GetUInt64("BandId").ToString();
                        ddVisib.SelectedValue = rdr.IsDBNull(rdr.GetOrdinal("Visibility")) ? "0" : rdr.GetInt16("Visibility").ToString();
                        tbLang.Text = rdr.IsDBNull(rdr.GetOrdinal("Language")) ? "" : rdr.GetString("Language");
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "SongWriter", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ctrEditor.Content))
        {
            if (!String.IsNullOrEmpty(ItemId) && !IsAuthor())
                return;

            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    if (!String.IsNullOrEmpty(ItemId)) //update
                    {
                        MySqlCommand cmd = new MySqlCommand(@"update lyrics set 
Name=?Name, 
Text=?Text, 
Updated=?Updated, 
Style=?Style, 
Language=?Language, 
BandId=?BandId, 
Visibility=?Visibility 
where id=?LyricId", con);
                        cmd.Parameters.Add("?Name", MySqlDbType.VarChar, 100).Value = Utils.SQLEscape(tbTitle.Text).Trim();
                        cmd.Parameters.Add("?Text", MySqlDbType.VarChar, 2048).Value = Utils.SQLEscape(ctrEditor.Content).Trim();
                        string sStyle = Utils.SQLEscape(tbStyle.Text).Trim();
                        cmd.Parameters.Add("?Style", MySqlDbType.VarChar, 80).Value = !String.IsNullOrEmpty(sStyle) ? sStyle : null;
                        string sLang = Utils.SQLEscape(tbLang.Text).Trim();
                        cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = !String.IsNullOrEmpty(sLang) ? sLang : null;
                        cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = DateTime.UtcNow;

                        if (!String.IsNullOrEmpty(ddGroup.SelectedValue))
                            cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt16.Parse(ddGroup.SelectedValue);
                        else
                            cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = null;

                        cmd.Parameters.Add("?Visibility", MySqlDbType.Int16).Value = UInt64.Parse(ddVisib.SelectedValue);
                        cmd.Parameters.Add("?LyricId", MySqlDbType.UInt64).Value = UInt64.Parse(ItemId);

                        cmd.ExecuteNonQuery();
                    }
                    else //create
                    {
                        MySqlCommand cmd = new MySqlCommand(@"insert into lyrics 
(Name, Text, Author, Created, Updated, Deleted, Style, Language, BandId, Visibility) 
values 
(?Name, ?Text, ?Author, ?Created, ?Updated, 0, ?Style, ?Language, ?BandId, ?Visibility); SELECT LAST_INSERT_ID();", con);
                        cmd.Parameters.Add("?Name", MySqlDbType.VarChar, 100).Value = Utils.SQLEscape(tbTitle.Text).Trim();
                        cmd.Parameters.Add("?Text", MySqlDbType.VarChar, 2048).Value = Utils.SQLEscape(ctrEditor.Content);
                        cmd.Parameters.Add("?Author", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                        string sStyle = Utils.SQLEscape(tbStyle.Text).Trim();
                        cmd.Parameters.Add("?Style", MySqlDbType.VarChar, 80).Value = !String.IsNullOrEmpty(sStyle) ? sStyle : null;

                        string sLang = Utils.SQLEscape(tbLang.Text).Trim();
                        cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = !String.IsNullOrEmpty(sLang) ? sLang : null;

                        DateTime dtNow = DateTime.UtcNow;
                        cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value = dtNow;
                        cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = dtNow;

                        if (!String.IsNullOrEmpty(ddGroup.SelectedValue))
                            cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(ddGroup.SelectedValue);
                        else
                            cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = null;

                        cmd.Parameters.Add("?Visibility", MySqlDbType.Int16).Value = Int16.Parse(ddVisib.SelectedValue);

                        ItemId = cmd.ExecuteScalar().ToString();
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "SongWriter", "SaveButton_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            Response.Redirect("~/MyLyrics.aspx");
        }
    }
    protected void ClearButton_Click(object sender, EventArgs e)
    {
        ctrEditor.Content = string.Empty;
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MyLyrics.aspx");
    }
    protected void PreviewButton_Click(object sender, EventArgs e)
    {
        TextPreview.InnerHtml = ctrEditor.Content;
    }
}
