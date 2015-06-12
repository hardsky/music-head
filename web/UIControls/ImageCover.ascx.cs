using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;
using System.IO;

public partial class UIControls_ImageCover : JamUIControl
{
    public UIControls_ImageCover()
    {
        m_Code = 56;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillForm();
        }
    }

    public string DefaultImgUrl
    {
        get
        {
            return (string)ViewState["DefaultImgUrl"];
        }
        set
        {
            ViewState["DefaultImgUrl"] = value;
        }
    }

    public string ImgId
    {
        get
        {
            return (string)ViewState["ImgId"];
        }
        set
        {
            ViewState["ImgId"] = value;
        }
    }

    public string BandId
    {
        get
        {
            return (string)ViewState["BandId"];
        }
        set
        {
            ViewState["BandId"] = value;
        }
    }

    public string Visibility
    {
        get
        {
            return (string)ViewState["Visibility"];
        }
        set
        {
            ViewState["Visibility"] = value;
        }
    }

    private string NewImgFile
    {
        get
        {
            return (uplImg.Visible && uplImg.HasFile) ? "~/images/" + JamTypes.User.GetUserFromSession(Session).Id + "/" + uplImg.FileName : null;
        }
    }

    public bool Deleted
    {
        get
        {
            return ViewState["Deleted"] != null ? (bool)ViewState["Deleted"] : false;
        }

        private set
        {
            ViewState["Deleted"] = value;
        }
    }

    protected void btnChangeCover_Click(object sender, EventArgs e)
    {
        if (btnChangeCover.Text == "Change")
        {
            lbImgCoverFile.Visible = false;
            uplImg.Visible = true;
            btnChangeCover.Text = "Cancel";
        }
        else
        {
            lbImgCoverFile.Visible = true;
            uplImg.Visible = false;
            btnChangeCover.Text = "Change";
        }
    }

    private void FillForm()
    {
        lbImgCoverFile.Text = "";
        imgCover.ImageUrl = DefaultImgUrl;

        if (!String.IsNullOrEmpty(ImgId))
        {
            uplImg.Visible = false;
            lbImgCoverFile.Visible = true;
            trCoverBtn.Visible = true;

            imgCover.ImageUrl = "~/GetImage.aspx?id=" + ImgId;
            FillImageName(ImgId);
        }
        else
        {
            uplImg.Visible = true;
            lbImgCoverFile.Visible = false;
            trCoverBtn.Visible = false;
        }
    }

    private void FillImageName(string sImgId)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select FileName from images where Id=?Id", con);
                cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = UInt64.Parse(sImgId);

                string sImgFile = cmd.ExecuteScalar().ToString();

                if (!String.IsNullOrEmpty(sImgFile))
                {
                    sImgFile = sImgFile.Substring(("~/images/" + JamTypes.User.GetUserFromSession(Session).Id + "/").Length);
                    lbImgCoverFile.Text = sImgFile;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "ImageCover", "FillImageName: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    //return Id in tables images
    public string Save(MySqlConnection con, MySqlTransaction trans)
    {
        if(!String.IsNullOrEmpty(ImgId))//update
        {
            if (!Deleted)
            {
                MySqlCommand cmd = new MySqlCommand("", con, trans);
                cmd.CommandText = "update images set ";
                if (!String.IsNullOrEmpty(NewImgFile))
                {
                    cmd.CommandText += " FileName = ?FileName,";
                    cmd.Parameters.Add("?FileName", MySqlDbType.VarChar, 100).Value = NewImgFile;
                }
                cmd.CommandText += @"BandId=?BandId, Visibility=?Visibility, Updated=?Updated where Id=?Id;";

                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = null;
                if (!String.IsNullOrEmpty(BandId))
                    cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);
                cmd.Parameters.Add("?Visibility", MySqlDbType.Int16).Value = Int16.Parse(Visibility);
                cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = UInt64.Parse(ImgId);

                cmd.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(NewImgFile))
                {
                    uplImg.SaveAs(MapPath(NewImgFile));
                    if (!String.IsNullOrEmpty(lbImgCoverFile.Text))
                    {
                        //delete previous path
                        string sDeletePath = this.MapPath("~/images/") + JamTypes.User.GetUserFromSession(Session).Id + "/" + lbImgCoverFile.Text.Trim();
                        File.Delete(sDeletePath);
                    }
                }

                return ImgId;
            }
            else //delete
            {
                MySqlCommand cmd = new MySqlCommand("delete from images where Id=?Id", con, trans);
                cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = UInt64.Parse(ImgId);
                cmd.ExecuteNonQuery();
                if (!String.IsNullOrEmpty(lbImgCoverFile.Text))
                {
                    //delete previous path
                    string sDeletePath = this.MapPath("~/images/") + JamTypes.User.GetUserFromSession(Session).Id + "/" + lbImgCoverFile.Text.Trim();
                    File.Delete(sDeletePath);
                }

                return null;
            }
        }
        else if(!String.IsNullOrEmpty(NewImgFile)) //create
        {
            MySqlCommand cmd = new MySqlCommand("", con, trans);
            cmd.CommandText = @"insert into images (FileName, BandId, Visibility, Updated) 
values(?FileName, ?BandId, ?Visibility, ?Updated); SELECT LAST_INSERT_ID();";
            cmd.Parameters.Add("?FileName", MySqlDbType.VarChar, 100).Value = NewImgFile;

            if (!String.IsNullOrEmpty(BandId))
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);
            else
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = null;

            cmd.Parameters.Add("?Visibility", MySqlDbType.Int16).Value = Int16.Parse(Visibility);
            cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = DateTime.UtcNow;

            string sRet = cmd.ExecuteScalar().ToString();

            uplImg.SaveAs(MapPath(NewImgFile));

            return sRet;
        }

        return null;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Deleted = true;
        imgCover.ImageUrl = DefaultImgUrl;
        uplImg.Visible = true;
        lbImgCoverFile.Visible = false;
        trCoverBtn.Visible = false;
    }
}
