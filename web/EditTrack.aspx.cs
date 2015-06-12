using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.Data;
using System.IO;
using System.Text;

public partial class EditTrack : JamPagePrivate
{
    public EditTrack()
    {
        m_Code = 24;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ItemId = Request["id"];
            TableName = "music";

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

            FillForm();
        }
    }

    private void FillForm()
    {
        if (!String.IsNullOrEmpty(ItemId))
        {
            uplTrack.Visible = false;
            lbFile.Visible = true;
            trCHBtn.Visible = true;

            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select
Title, FileName, Description, Style, BandId, Visibility, Language, ImgId  
from music where Id=?TrackId and Deleted=0", con);
                    cmd.Parameters.Add("?TrackId", MySqlDbType.UInt64).Value = UInt64.Parse(ItemId);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        if (rdr.Read())
                        {
                            tbTitle.Text = rdr.GetString("Title");
                            string sRelativeFilePath = rdr.GetString("FileName");
                            lbFile.Text = sRelativeFilePath.Substring(("~/music/" + UserInfo.Id + "/").Length);
                            tbDescr.Text = rdr.IsDBNull(rdr.GetOrdinal("Description")) ? "" : rdr.GetString("Description");
                            tbStyle.Text = rdr.IsDBNull(rdr.GetOrdinal("Style")) ? "" : rdr.GetString("Style");
                            ddGroup.SelectedValue = rdr.IsDBNull(rdr.GetOrdinal("BandId")) ? "" : rdr.GetUInt64("BandId").ToString();
                            ddVisib.SelectedValue = rdr.GetInt16("Visibility").ToString();
                            tbLang.Text = rdr.IsDBNull(rdr.GetOrdinal("Language")) ? "" : rdr.GetString("Language");
                        }

                        rdr.Close();
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "EditTrack", "FillForm: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        else
        {
            uplTrack.Visible = true;
            lbFile.Visible = false;
            trCHBtn.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (String.IsNullOrEmpty(ItemId)) //create
        {
            if (!uplTrack.HasFile)
                return;

            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                MySqlTransaction trans = con.BeginTransaction();
                try
                {
                    ctrImgCover.BandId = ddGroup.SelectedValue;
                    ctrImgCover.Visibility = ddVisib.SelectedValue;
                    string sImgCoverId = ctrImgCover.Save(con, trans);
                    string sRelativeFilePath = "~/music/" + UserInfo.Id + "/" + uplTrack.FileName;

                    MySqlCommand cmd = new MySqlCommand(@"insert into music 
(Title, FileName, Description, Style, BandId, Visibility, Deleted, Created, Updated, Author, ImgId, Language) 
VALUES 
(?Title, ?FileName, ?Description, ?Style, ?BandId, ?Visibility, 0, ?Created, ?Updated, ?Author, ?ImgId, ?Language);
SELECT LAST_INSERT_ID();", con, trans);
                    cmd.Parameters.Add("?Title", MySqlDbType.VarChar, 255).Value = tbTitle.Text.Trim();
                    cmd.Parameters.Add("?FileName", MySqlDbType.VarChar, 255).Value = sRelativeFilePath;

                    if (!String.IsNullOrEmpty(sImgCoverId))
                        cmd.Parameters.Add("?ImgId", MySqlDbType.UInt64).Value = UInt64.Parse(sImgCoverId);
                    else
                        cmd.Parameters.Add("?ImgId", MySqlDbType.UInt64).Value = null;

                    string sDescr = tbDescr.Text.Trim();
                    cmd.Parameters.Add("?Description", MySqlDbType.VarChar, 512).Value = !String.IsNullOrEmpty(sDescr) ? sDescr : null;
                    
                    string sStyle = tbStyle.Text.Trim();
                    cmd.Parameters.Add("?Style", MySqlDbType.VarChar, 80).Value = !String.IsNullOrEmpty(sStyle) ? sStyle : null;

                    if (!String.IsNullOrEmpty(ddGroup.SelectedValue))
                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(ddGroup.SelectedValue);
                    else
                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = null;

                    cmd.Parameters.Add("?Visibility", MySqlDbType.Int16).Value = Int16.Parse(ddVisib.SelectedValue);
                    cmd.Parameters.Add("?Author", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                    string sLang = tbLang.Text.Trim();
                    cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = !String.IsNullOrEmpty(sLang) ? sLang : null;

                    DateTime dt = DateTime.UtcNow;
                    cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value = dt;
                    cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = dt;

                    string sTmpTrackId = cmd.ExecuteScalar().ToString();
                    if (!String.IsNullOrEmpty(sTmpTrackId))
                    {
                        string sPath = this.MapPath(sRelativeFilePath);
                        uplTrack.SaveAs(sPath);

                        trans.Commit();

                        ItemId = sTmpTrackId;
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "EditTrack", "btnSave_Click(create): " + ex.Message);
                    if (trans != null)
                        trans.Rollback();//if exception when saving file
                }
                finally
                {
                    con.Close();
                }
            }
        }
        else//update
        {
            if (!IsAuthor())
                return;

            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                MySqlTransaction trans = con.BeginTransaction();
                try
                {
                    ctrImgCover.BandId = ddGroup.SelectedValue;
                    ctrImgCover.Visibility = ddVisib.SelectedValue;
                    string sImgCoverId = ctrImgCover.Save(con, trans);

                    string sRelativeFilePath = "~/music/" + UserInfo.Id + "/" + ((uplTrack.Visible && uplTrack.HasFile) ? uplTrack.FileName : lbFile.Text);
                    string sQuery = @"update music set
Title=?Title, 
FileName=?FileName, 
ImgId=?ImgId, 
Description=?Description, 
Style=?Style, 
BandId=?BandId, 
Visibility=?Visibility, 
Language=?Language, 
Updated=?Updated  
 where Id=?TrackId;
";

                    MySqlCommand cmd = new MySqlCommand(sQuery, con, trans);
                    cmd.Parameters.Add("?Title", MySqlDbType.VarChar, 255).Value = tbTitle.Text.Trim();
                    cmd.Parameters.Add("?FileName", MySqlDbType.VarChar, 255).Value = sRelativeFilePath;
                    
                    if (!String.IsNullOrEmpty(sImgCoverId))
                        cmd.Parameters.Add("?ImgId", MySqlDbType.UInt64).Value = UInt64.Parse(sImgCoverId);
                    else
                        cmd.Parameters.Add("?ImgId", MySqlDbType.UInt64).Value = null;

                    string sDescr = tbDescr.Text.Trim();
                    cmd.Parameters.Add("?Description", MySqlDbType.VarChar, 512).Value = !String.IsNullOrEmpty(sDescr) ? sDescr : null;

                    string sStyle = tbStyle.Text.Trim();
                    cmd.Parameters.Add("?Style", MySqlDbType.VarChar, 80).Value = !String.IsNullOrEmpty(sStyle) ? sStyle : null;

                    if (!String.IsNullOrEmpty(ddGroup.SelectedValue))
                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(ddGroup.SelectedValue);
                    else
                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = null;

                    cmd.Parameters.Add("?Visibility", MySqlDbType.Int16).Value = UInt64.Parse(ddVisib.SelectedValue);

                    string sLang = tbLang.Text.Trim();
                    cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 45).Value = !String.IsNullOrEmpty(sLang) ? sLang : null;

                    cmd.Parameters.Add("?TrackId", MySqlDbType.UInt64).Value = UInt64.Parse(ItemId);
                    cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = DateTime.UtcNow;

                    cmd.ExecuteNonQuery();

                    if (uplTrack.Visible && uplTrack.HasFile)
                    {
                        //delete previous path
                        string sDeletePath = this.MapPath("~/Music/") + UserInfo.Id + "/" + lbFile.Text.Trim();
                        File.Delete(sDeletePath);
                        string sNewPath = this.MapPath(sRelativeFilePath);
                        uplTrack.SaveAs(sNewPath);
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "EditTrack", "btnSave_Click(update): " + ex.Message);
                    if (trans != null)
                        trans.Rollback();//if exception when saving file
                }
                finally
                {
                    con.Close();
                }
            }
        }

        Response.Redirect("~/MyMusic.aspx");
    }

    protected void btnChangeFile_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.ID == "btnChangeFile")
        {
            lbFile.Visible = false;
            uplTrack.Visible = true;
            btnChangeFile.Visible = false;
            btnUplCancel.Visible = true;
        }
        else
        {
            lbFile.Visible = true; ;
            uplTrack.Visible = false;
            btnChangeFile.Visible = true;
            btnUplCancel.Visible = false;
        }
    }
    protected void bntCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MyMusic.aspx");
    }
}
