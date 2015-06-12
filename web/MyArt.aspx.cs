using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;
using Jam;
using System.IO;
using System.Data;
using System.Web.Security;

public partial class MyArt : JamPage
{
    public MyArt()
    {
        m_Code = 33;
    }

    private string AvatarImgId
    {
        get
        {
            return (string)ViewState["AvatarImgId"];
        }
        set
        {
            ViewState["AvatarImgId"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Form.Action = Request.RawUrl;

        if (!IsPostBack)
        {
            FillForm();
        }
    }

    private void FillForm()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                lbName.Text = UserInfo.Name;

                MySqlCommand cmd = new MySqlCommand(@"select userinfo.OwnInfo, userinfo.UserPicId, userinfo.Country, userinfo.City, TimeZone 
from userinfo where id=?id", con);
                cmd.Parameters.Add("?id", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        ctrEditor.Content = rdr.IsDBNull(rdr.GetOrdinal("OwnInfo")) ? "" : rdr.GetString("OwnInfo");

                        if (rdr.IsDBNull(rdr.GetOrdinal("UserPicId")))
                        {//load defaul pic
                            imgAvatar.ImageUrl = m_sDefaultAvatarUrl;
                        }
                        else
                        {
                            AvatarImgId = rdr.GetUInt64("UserPicId").ToString();
                            imgAvatar.ImageUrl = "~/GetImage.aspx?id=" + AvatarImgId;
                        }

                        tbCountry.Text = rdr.IsDBNull(rdr.GetOrdinal("Country")) ? "" : rdr.GetString("Country");
                        tbCity.Text = rdr.IsDBNull(rdr.GetOrdinal("City")) ? "" : rdr.GetString("City");
                        ddTimeZone.SelectedValue = rdr.IsDBNull(rdr.GetOrdinal("TimeZone")) ? "0" : rdr.GetInt32("TimeZone").ToString();
                    }
                    rdr.Close();
                }
            }
            catch(Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyArt", "FillForm: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            FillDDWay(ddWay);
            FillWaysGrid();
            if (ddWay.Items.Count < 2)
            {
                trDDWay.Visible = false;
                btnAddWay.Visible = false;
            }
            else
            {
                trDDWay.Visible = true;
                btnAddWay.Visible = true;
            }

            FillInstr(gvInst, UserInfo.UIntId);
            if (gvInst.Rows != null && gvInst.Rows.Count > 0)
            {
                btnInstrDel.Visible = true;
            }
            else
            {
                btnInstrDel.Visible = false;
            }
            FillStyles(gvStyles, UserInfo.UIntId);
            if (gvStyles.Rows != null && gvStyles.Rows.Count > 0)
            {
                btnStyleDel.Visible = true;
            }
            else
            {
                btnStyleDel.Visible = false;
            }
            FillLang(gvLang, UserInfo.UIntId);
            if (gvLang.Rows != null && gvLang.Rows.Count > 0)
            {
                btnLangDel.Visible = true;
            }
            else
            {
                btnLangDel.Visible = false;
            }
        }
    }

    private void FillWaysGrid()
    {
        trWayDel.Visible = false;
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select wl.Text as WayName, wl.WayId from userways as uw, waylocal as wl where uw.UserId=?UserId and uw.Deleted=0 and wl.WayId=uw.WayId and wl.LangId=?LangId", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = base.LangUId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet("WayDs");
                adp.Fill(ds);

                gvArtWays.DataSource = ds;
                gvArtWays.DataBind();

                if (gvArtWays.Rows != null && gvArtWays.Rows.Count > 0)
                {
                    trWayDel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyArt", "FillWaysGrid: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            MySqlTransaction trans = null;
            try
            {
                trans = con.BeginTransaction();
                MySqlCommand cmd = null;

                ulong nNewImgId = 0;

                if (uplAvatar.HasFile && !String.IsNullOrEmpty(uplAvatar.FileName))//some avatar choosen
                {
                    //delete previous, if any
                    if (!string.IsNullOrEmpty(AvatarImgId))
                    {
                        //delete previous path

                        ulong nOldImgId = UInt64.Parse(AvatarImgId);
                        cmd = new MySqlCommand("select FileName from images where Id=?Id;", con, trans);
                        cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = nOldImgId;
                        string sFilename = cmd.ExecuteScalar().ToString();

                        string sDeletePath = this.MapPath(sFilename);
                        File.Delete(sDeletePath);

                        cmd = new MySqlCommand("delete from images where id=?id;", con, trans);
                        cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = nOldImgId;
                        cmd.ExecuteNonQuery();
                    }

                    //add new
                    string sNewFileName = "~/Images/" + UserInfo.Id + "/" + uplAvatar.FileName;
                    uplAvatar.SaveAs(MapPath(sNewFileName));

                    cmd = new MySqlCommand(@"insert into images (FileName, Visibility, Deleted, Created, Updated, Author) 
values (?FileName, 0, 0, ?Created, ?Created, ?UserId); SELECT LAST_INSERT_ID();", con, trans);
                    cmd.Parameters.Add("?FileName", MySqlDbType.VarChar, 255).Value = sNewFileName;
                    cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;

                    nNewImgId = Convert.ToUInt64(cmd.ExecuteScalar());
                }

                cmd = new MySqlCommand(@"update userinfo set UserPicId=?UserPicId, Updated=UTC_TIMESTAMP(), UpdateUser=?UserId, OwnInfo=?OwnInfo, 
Country=?Country, City=?City, TimeZone=?TimeZone where Id=?UserId", con, trans);

                if (nNewImgId > 0)
                    cmd.Parameters.Add("?UserPicId", MySqlDbType.UInt64).Value = nNewImgId;
                else if (!String.IsNullOrEmpty(AvatarImgId))
                    cmd.Parameters.Add("?UserPicId", MySqlDbType.UInt64).Value = UInt64.Parse(AvatarImgId);
                else
                    cmd.Parameters.Add("?UserPicId", MySqlDbType.UInt64).Value = null;

                int nTZ = int.Parse(ddTimeZone.SelectedValue);

                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?OwnInfo", MySqlDbType.VarChar, 512).Value = Utils.SQLEscape(ctrEditor.Content).Trim();
                cmd.Parameters.Add("?Country", MySqlDbType.VarChar, 80).Value = Utils.SQLEscape(tbCountry.Text).Trim();
                cmd.Parameters.Add("?City", MySqlDbType.VarChar, 80).Value = Utils.SQLEscape(tbCity.Text).Trim();
                cmd.Parameters.Add("?TimeZone", MySqlDbType.Int32).Value = nTZ;

                cmd.ExecuteNonQuery();

                JamTypes.User usr = UserInfo;
                usr.TimeZone = TimeSpan.FromMinutes(nTZ);
                UserInfo = usr;

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();

                JamLog.log(JamLog.enEntryType.error, "MyArt", "btnSave_Click: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        Response.Redirect("~/MyArt.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/folks/" + UserInfo.Name);
    }
    protected void gvArtWays_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sWayId = gvArtWays.DataKeys[e.Row.RowIndex].Values["WayId"].ToString();
            string sWayName = gvArtWays.DataKeys[e.Row.RowIndex].Values["WayName"].ToString();
            ddWay.Items.Remove(new ListItem(sWayName, sWayId));
        }
    }
    protected void btnAddWay_Click(object sender, EventArgs e)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"insert into userways (UserId, WayId, Deleted) 
values (?UserId, ?WayId, 0);", con);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?WayId", MySqlDbType.UInt64).Value = UInt64.Parse(ddWay.Text);

                cmd.ExecuteNonQuery();

                ddWay.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MyArt", "btnAddWay_Click: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            FillDDWay(ddWay);
            FillWaysGrid();
            if (ddWay.Items.Count < 2)
            {
                trDDWay.Visible = false;
                btnAddWay.Visible = false;
            }
            else
            {
                trDDWay.Visible = true;
                btnAddWay.Visible = true;
            }
        }
    }
    protected void btnAddInstr_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(tbInstr.Text))
            return;

        string sInstr = Utils.SQLEscape(tbInstr.Text).Trim();
        if (!String.IsNullOrEmpty(sInstr))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"insert into instruments (UserId, Instrument, Deleted) 
values (?UserId, ?Instr, 0);", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                    cmd.Parameters.Add("?Instr", MySqlDbType.VarChar, 100).Value = sInstr;

                    cmd.ExecuteNonQuery();

                    tbInstr.Text = "";
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyArt", "btnAddInstr_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }

                FillInstr(gvInst, UserInfo.UIntId);
                if (gvInst.Rows != null && gvInst.Rows.Count > 0)
                {
                    btnInstrDel.Visible = true;
                }
                else
                {
                    btnInstrDel.Visible = false;
                }
            }
        }
    }
    protected void btnAddStyle_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(tbStyle.Text))
            return;

        string sStyle = Utils.SQLEscape(tbStyle.Text).Trim();
        if (!String.IsNullOrEmpty(sStyle))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"insert into userstyles (UserId, StyleName) 
values (?UserId, ?Style);", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                    cmd.Parameters.Add("?Style", MySqlDbType.VarChar, 80).Value = sStyle;

                    cmd.ExecuteNonQuery();

                    tbStyle.Text = "";
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyArt", "btnAddStyle_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }

                FillStyles(gvStyles, UserInfo.UIntId);
                if (gvStyles.Rows != null && gvStyles.Rows.Count > 0)
                {
                    btnStyleDel.Visible = true;
                }
                else
                {
                    btnStyleDel.Visible = false;
                }
            }
        }
    }
    protected void btnAddLang_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(tbLang.Text))
            return;

        string sLang = Utils.SQLEscape(tbLang.Text).Trim();
        if (!String.IsNullOrEmpty(sLang))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"insert into userlanguages (UserId, Language, Deleted) 
values (?UserId, ?Language, 0);", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                    cmd.Parameters.Add("?Language", MySqlDbType.VarChar, 80).Value = sLang;

                    cmd.ExecuteNonQuery();

                    tbLang.Text = "";
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyArt", "btnAddLang_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }

                FillLang(gvLang, UserInfo.UIntId);
                if (gvLang.Rows != null && gvLang.Rows.Count > 0)
                {
                    btnLangDel.Visible = true;
                }
                else
                {
                    btnLangDel.Visible = false;
                }
            }
        }
    }

    protected void btnWayDel_Click(object sender, EventArgs e)
    {
        string sIds = "";
        foreach (GridViewRow row in gvArtWays.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("cbSelect");
            if (cb.Checked)
            {
                UInt64 nId = (UInt64)gvArtWays.DataKeys[row.RowIndex].Values["WayId"];
                sIds += "'" + nId + "',";
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
                    MySqlCommand cmd = new MySqlCommand("delete from userways where UserId=?UserId and WayId in (" + sIds + ")", con);
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyArt", "btnWayDel_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            FillDDWay(ddWay);
            FillWaysGrid();
            if (ddWay.Items.Count < 2)
            {
                trDDWay.Visible = false;
                btnAddWay.Visible = false;
            }
            else
            {
                trDDWay.Visible = true;
                btnAddWay.Visible = true;
            }
        }
    }
    protected void btnInstrDel_Click(object sender, EventArgs e)
    {
        string sIds = "";
        foreach (GridViewRow row in gvInst.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("cbSelect");
            if (cb.Checked)
            {
                UInt64 nId = (UInt64)gvInst.DataKeys[row.RowIndex].Values["Id"];
                sIds += "'" + nId + "',";
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
                    MySqlCommand cmd = new MySqlCommand("delete from instruments where Id in (" + sIds + ")", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyArt", "btnInstrDel_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            FillInstr(gvInst, UserInfo.UIntId);
            if (gvInst.Rows != null && gvInst.Rows.Count > 0)
            {
                btnInstrDel.Visible = true;
            }
            else
            {
                btnInstrDel.Visible = false;
            }
        }
    }
    protected void btnStyleDel_Click(object sender, EventArgs e)
    {
        string sIds = "";
        foreach (GridViewRow row in gvStyles.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("cbSelect");
            if (cb.Checked)
            {
                UInt64 nId = (UInt64)gvStyles.DataKeys[row.RowIndex].Values["Id"];
                sIds += "'" + nId + "',";
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
                    MySqlCommand cmd = new MySqlCommand("delete from userstyles where Id in (" + sIds + ")", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyArt", "btnStyleDel_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            FillStyles(gvStyles, UserInfo.UIntId);
            if (gvStyles.Rows != null && gvStyles.Rows.Count > 0)
            {
                btnStyleDel.Visible = true;
            }
            else
            {
                btnStyleDel.Visible = false;
            }
        }
    }
    protected void btnLangDel_Click(object sender, EventArgs e)
    {
        string sIds = "";
        foreach (GridViewRow row in gvLang.Rows)
        {
            CheckBox cb = (CheckBox)row.Cells[0].FindControl("cbSelect");
            if (cb.Checked)
            {
                UInt64 nId = (UInt64)gvLang.DataKeys[row.RowIndex].Values["Id"];
                sIds += "'" + nId + "',";
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
                    MySqlCommand cmd = new MySqlCommand("delete from userlanguages where Id in (" + sIds + ")", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MyArt", "btnLangDel_Click: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            FillLang(gvLang, UserInfo.UIntId);
            if (gvLang.Rows != null && gvLang.Rows.Count > 0)
            {
                btnLangDel.Visible = true;
            }
            else
            {
                btnLangDel.Visible = false;
            }
        }
    }
}
