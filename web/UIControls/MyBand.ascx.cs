using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class UIControls_MyBand : JamUIControl
{
    public UIControls_MyBand()
    {
        m_Code = 28;
    }

    private string BandId
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BandId = Request["id"];

            if (!String.IsNullOrEmpty(BandId) && !IsMember())
            {
                this.Visible = false;
                return;
            }

            try
            {
                FillForm();
                FillMembers();
                FillInvitedGrid();
                FillLangs();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "Page_Load: " + ex.Message);
            }

            if (!String.IsNullOrEmpty(BandId) && !IsLeader()) //disable controls
            {
                DisableControls(this.Controls);
            }
        }
    }

    private void DisableControls(ControlCollection controlCollection)
    {
        foreach (Control ctr in controlCollection)
        {

            if (ctr.Controls != null && ctr.Controls.Count > 0)
                DisableControls(ctr.Controls);

            WebControl webCtr = ctr as WebControl;
            if (webCtr != null)
                webCtr.Enabled = false;
        }
    }

    private bool IsLeader()
    {
        bool bRet = false;

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select Leader from bands where Id=?BandId and Leader=?UserId", con);
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = ulong.Parse(BandId);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        bRet = !rdr.IsDBNull(rdr.GetOrdinal("Leader"));
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "IsLeader: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return bRet;
    }

    private bool IsMember()
    {
        bool bRet = false;

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"select ub.UserId from userinfo as ui, usertoband as ub where
ui.Id=?UserId and ui.Deleted = 0 and ub.Deleted=0 and ui.id = ub.UserId and ub.BandId = ?BandId", con);
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = ulong.Parse(BandId);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    if (rdr.Read())
                    {
                        bRet = !rdr.IsDBNull(rdr.GetOrdinal("UserId"));
                    }
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "IsMember: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return bRet;
    }

    private void FillForm()
    {
        tbName.Text = "";
        tbDescr.Text = "";

        if (!String.IsNullOrEmpty(BandId))
        {
            dvName.Visible = false;
            lbName.Visible = true;
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Name, Description from bands where Id=?Id and Deleted=0;", con);
                    cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        if (rdr.Read())
                        {
                            lbName.Text = rdr.GetString("Name");
                            tbDescr.Text = rdr.GetString("Description");
                        }
                        rdr.Close();
                    }

                }
                catch(Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "FillForm: " + ex.Message);
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }

    private void FillMembers()
    {
        lbMembersLabel.Visible = false;
        trInviteBtns.Visible = false;
        lbLabelLanguages.Visible = false;
        tblLang.Visible = false;
        if (!String.IsNullOrEmpty(BandId))
        {
            lbMembersLabel.Visible = true;
            trInviteBtns.Visible = true;
            lbLabelLanguages.Visible = true;
            tblLang.Visible = true;
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select ui.SiteName, ub.Comment from userinfo as ui, usertoband as ub where
ui.Deleted = 0 and ub.Deleted=0 and ui.id = ub.UserId and ub.BandId = ?BandId order by SiteName;", con);
                    cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    gvMembers.DataSource = ds;
                    gvMembers.DataBind();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "FillMembers: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }

    private void Update()
    {
        DateTime dtUpdateTime = DateTime.Now;
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"update table bands set Name=?Name, 
Description=?Description, Updated=?Updated, Updater=?Updater where Id=?Id;", con);
                cmd.Parameters.Add("?Id", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);
                cmd.Parameters.Add("?Name", MySqlDbType.VarChar, 45).Value = tbName.Text;
                cmd.Parameters.Add("?Description", MySqlDbType.VarChar, 255).Value = tbDescr.Text;
                cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = dtUpdateTime;
                cmd.Parameters.Add("?Updater", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "Update: " + ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void Insert()
    {
        DateTime dtUpdateTime = DateTime.Now;
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            MySqlTransaction trans = con.BeginTransaction();
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"insert into bands (Name, Description, Updated,
Updater, Deleted, Created, Creater, Leader) values(?Name, 
?Description, ?Updated, ?Updater, false, ?Created, ?Creater, ?Leader);
SELECT LAST_INSERT_ID();", con, trans);
                cmd.Parameters.Add("?Name", MySqlDbType.VarChar, 45).Value = tbName.Text;
                cmd.Parameters.Add("?Description", MySqlDbType.VarChar, 255).Value = tbDescr.Text;
                cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = dtUpdateTime;
                cmd.Parameters.Add("?Updater", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value = dtUpdateTime;
                cmd.Parameters.Add("?Creater", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?Leader", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                string sBandId = cmd.ExecuteScalar().ToString();

                cmd = new MySqlCommand(@"insert into usertoband (UserId, BandId, Deleted, Updater, Updated, Comment) 
values(?UserId, ?BandId, 0, ?Updater, ?Updated , ?Comment);", con, trans);
                cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(sBandId);
                cmd.Parameters.Add("?Updater", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = dtUpdateTime;
                cmd.Parameters.Add("?Comment", MySqlDbType.VarChar, 255).Value = "Leader";

                cmd.ExecuteNonQuery();
                trans.Commit();

                BandId = sBandId;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "Insert: " + ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(BandId)) //update
            {
                Update();
            }
            else //create
            {
                Insert();
            }
        }
        catch (Exception ex)
        {
            JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "btnSave_Click: " + ex.Message);
        }

        Response.Redirect("~/MyBands.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MyBands.aspx");
    }

    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        trMemberRecruit.Visible = true;
        trInviteBtns.Visible = false;
    }

    protected void btnInvite_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(BandId))
        {
            string sUserName = Utils.SQLEscape(tbMembName.Text.Trim());
            if (!String.IsNullOrEmpty(sUserName))
            {
                MySqlConnection con = Utils.GetSqlConnection();
                if (con != null)
                {
                    try
                    {
                        //check user in invites table
                        MySqlCommand cmd = new MySqlCommand(@"select invites.Id from invites, userinfo, commentsubjtables as cst 
where invites.SubjId=?BandId and invites.SubjTableId=cst.Id and cst.TableName='bands' and LOWER(userinfo.SiteName)=?UserName and (invites.UserId=userinfo.Id or invites.MainUserId=userinfo.Id);", con);
                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);
                        cmd.Parameters.Add("?UserName", MySqlDbType.VarChar, 45).Value = sUserName;
                        object ret = cmd.ExecuteScalar();
                        if (ret != null && ret != DBNull.Value)
                            return;

                        //check user in this band
                        cmd = new MySqlCommand(@"select usertoband.Id from usertoband, userinfo where usertoband.BandId=?BandId and usertoband.UserId=userinfo.Id and LOWER(userinfo.SiteName)=?UserName and userinfo.Deleted=0;", con);
                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);
                        cmd.Parameters.Add("?UserName", MySqlDbType.VarChar, 45).Value = sUserName;
                        ret = cmd.ExecuteScalar();
                        if (ret != null && ret != DBNull.Value)
                            return;

                        cmd = new MySqlCommand(@"insert into invites (SubjId, SubjTableId, MainUserId, UserId, Created, Msg) 
select ?BandId as SubjId, commentsubjtables.Id as SubjTableId, ?MainUserId as MainUserId, userinfo.Id as UserId, UTC_TIMESTAMP() as Created, ?Msg as Msg 
from userinfo, commentsubjtables where  LOWER(userinfo.SiteName)=?UserName and userinfo.Deleted=0 and commentsubjtables.TableName='bands';", con);
                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);
                        cmd.Parameters.Add("?UserName", MySqlDbType.VarChar, 45).Value = sUserName;
                        cmd.Parameters.Add("?MainUserId", MySqlDbType.UInt64).Value = UserInfo.UIntId;
                        string sMsg = Utils.SQLEscape(tbMsg.Text.Trim());
                        cmd.Parameters.Add("?Msg", MySqlDbType.VarChar, 256).Value = sMsg;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "btnInvite_Click: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    FillInvitedGrid();

                    trInviteBtns.Visible = true;
                    tbMembName.Text = "";
                    trMemberRecruit.Visible = false;
                }
            }
        }
    }
    protected void btnInvCancel_Click(object sender, EventArgs e)
    {
        trInviteBtns.Visible = true;
        tbMembName.Text = "";
        trMemberRecruit.Visible = false;
    }

    private void FillInvitedGrid()
    {
        lbInvLabel.Visible = false;

        if (!String.IsNullOrEmpty(BandId))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select invites.Id as InvId, userinfo.SiteName as Name, invites.Msg from userinfo, invites, commentsubjtables where userinfo.Id=invites.UserId and userinfo.Deleted=0 and invites.SubjTableId=commentsubjtables.Id and commentsubjtables.TableName='bands' and invites.SubjId=?BandId;", con);
                    cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = UInt64.Parse(BandId);

                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet("DS_INVGRID");
                    adp.Fill(ds);

                    gvInvited.DataSource = ds;
                    gvInvited.DataBind();

                    if (gvInvited.Rows != null && gvInvited.Rows.Count > 0)
                    {
                        lbInvLabel.Visible = true;
                        btnRemoveInvite.Visible = true;
                    }
                    else
                    {
                        lbInvLabel.Visible = false;
                        btnRemoveInvite.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "FillInvitedGrid: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
    protected void btnAddLang_Click(object sender, EventArgs e)
    {
        if (tbLang.Text.Length > 45)
            return;

        string sLang = Utils.SQLEscape(tbLang.Text);

        if (String.IsNullOrEmpty(sLang))
            return;

        bool res = false;

        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                ulong nBandId = UInt64.Parse(BandId);

                MySqlCommand cmd = new MySqlCommand("insert into bandlanguages (BandId, Language, Deleted) values (?BandId, ?Lang, 0)", con);
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nBandId;
                cmd.Parameters.Add("?Lang", MySqlDbType.VarChar, 45).Value = sLang;

                cmd.ExecuteNonQuery();

                res = true;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "btnAddLang_Click: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        if (res)
            FillLangs();
    }

    private void FillLangs()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                ulong nBandId = UInt64.Parse(BandId);

                MySqlCommand cmd = new MySqlCommand("select Id, Language from bandlanguages where BandId=?BandId", con);
                cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nBandId;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                gvLangs.DataSource = ds;
                gvLangs.DataBind();

                if (gvLangs.Rows != null && gvLangs.Rows.Count > 0)
                    trLangDelete.Visible = true;
                else
                    trLangDelete.Visible = false;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "FillLangs: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void btnRemoveInvite_Click(object sender, EventArgs e)
    {
        if (gvInvited.Rows != null && gvInvited.Rows.Count > 0)
        {
            string sIds = "";
            foreach (GridViewRow row in gvInvited.Rows)
            {
                CheckBox cb = row.Cells[0].FindControl("cbSelect") as CheckBox;
                if (cb != null && cb.Checked)
                {
                    ulong nId = (ulong)gvInvited.DataKeys[row.RowIndex].Value;
                    sIds += "'" + nId + "',";
                }
            }

            sIds = sIds.TrimEnd(',');
            if (!string.IsNullOrEmpty(sIds))
            {
                MySqlConnection con = Utils.GetSqlConnection();
                if (con != null)
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("", con);
                        cmd.CommandText = "delete from invites where Id in (" + sIds + ")";
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "btnRemoveInvite_Click: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        FillInvitedGrid();
    }

    protected void btnDeleteLang_Click(object sender, EventArgs e)
    {
        if (gvLangs.Rows != null && gvLangs.Rows.Count > 0)
        {
            string sIds = "";
            foreach (GridViewRow row in gvLangs.Rows)
            {
                CheckBox cb = row.Cells[0].FindControl("cbSelect") as CheckBox;
                if (cb != null && cb.Checked)
                {
                    ulong nId = (ulong)gvLangs.DataKeys[row.RowIndex].Value;
                    sIds += "'" + nId + "',";
                }
            }

            sIds = sIds.TrimEnd(',');
            if (!string.IsNullOrEmpty(sIds))
            {
                MySqlConnection con = Utils.GetSqlConnection();
                if (con != null)
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("", con);
                        cmd.CommandText = "delete from bandlanguages where Id in (" + sIds + ")";
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        JamLog.log(JamLog.enEntryType.error, "UIControls_MyBand", "btnDeleteLang_Click: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        FillLangs();
    }
}
