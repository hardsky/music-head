using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Jam;

public partial class UIControls_Rating : JamUIControl
{
    public UIControls_Rating()
    {
        m_Code = 36;
    }

    public string SubjectID
    {
        get
        {
            return (string)ViewState["SubjectID"];
        }
        set
        {
            ViewState["SubjectID"] = value;
        }
    }

    public string SubjKind
    {
        get
        {
            return (string)ViewState["SubjKind"];
        }
        set
        {
            ViewState["SubjKind"] = value;
        }
    }

    private short Vote
    {
        get
        {
            return ViewState["Vote"] != null ? Convert.ToInt16(ViewState["Vote"]) : (short)0;
        }
        set
        {
            ViewState["Vote"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillForm();
            CheckUserVote();
            btnMinus.Visible = btnPlus.Visible = JamTypes.User.GetUserFromSession(Session) != null && 
                (!String.IsNullOrEmpty(SubjectID) && !String.IsNullOrEmpty(SubjKind));
        }
    }

    private void CheckUserVote()
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                if (JamTypes.User.GetUserFromSession(Session) != null)
                {
                    MySqlCommand cmd = new MySqlCommand(@"select rates.Vote from rates, commentsubjtables 
where rates.SubjId=?SubjId and rates.SubjTableId=commentsubjtables.Id and commentsubjtables.TableName=?SubjKind and rates.UserId=?UserId;", con);
                    cmd.Parameters.Add("SubjId", MySqlDbType.UInt64).Value = UInt64.Parse(SubjectID);
                    cmd.Parameters.Add("?SubjKind", MySqlDbType.VarChar, 30).Value = SubjKind;
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = JamTypes.User.GetUserFromSession(Session).UIntId;

                    object oR = cmd.ExecuteScalar();
                    Vote = (oR != null && oR != DBNull.Value) ? Convert.ToInt16(oR) : (short)0;
                }
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_Rating", "CheckUserVote: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }

    private void FillForm()
    {
        if (!String.IsNullOrEmpty(SubjectID) && !String.IsNullOrEmpty(SubjKind))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(@"select SUM(rates.Vote) from rates, commentsubjtables 
where rates.SubjId=?SubjId and rates.SubjTableId=commentsubjtables.Id and commentsubjtables.TableName=?SubjKind;", con);
                    cmd.Parameters.Add("SubjId", MySqlDbType.UInt64).Value = UInt64.Parse(SubjectID);
                    cmd.Parameters.Add("?SubjKind", MySqlDbType.VarChar, 30).Value = SubjKind;
                    object oR = cmd.ExecuteScalar();
                    lbRateNum.Text = (oR != null && oR != DBNull.Value) ? oR.ToString() : "0";
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "UI_Controls_Rating", "FillForm: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }

    protected void btnPlus_Click(object sender, EventArgs e)
    {
        AddVote(SubjectID, SubjKind, 1);
        FillForm();
    }

    protected void btnMinus_Click(object sender, EventArgs e)
    {
        AddVote(SubjectID, SubjKind, -1);
        FillForm();
    }

    private void AddVote(string SubjectID, string SubjKind, short nVote)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                if (Vote == 0) //insert
                {
                    MySqlCommand cmd = new MySqlCommand(@"insert into rates (SubjId, Vote, UserId, SubjTableId, Created, Updated) 
(select ?SubjId as SubjId, ?Vote as Vote, ?UserId as UserId, commentsubjtables.Id as SubjTableId, ?Created as Created, ?Updated as Updated from commentsubjtables where commentsubjtables.TableName=?SubjKind);", con);
                    cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = UInt64.Parse(SubjectID);
                    cmd.Parameters.Add("?SubjKind", MySqlDbType.VarChar, 30).Value = SubjKind;
                    cmd.Parameters.Add("?Vote", MySqlDbType.Int16).Value = nVote;
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = JamTypes.User.GetUserFromSession(Session).UIntId;
                    DateTime dtNow = DateTime.UtcNow;
                    cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value = dtNow;
                    cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = dtNow;

                    cmd.ExecuteNonQuery();
                }
                else if(Vote != nVote)//update
                {
                    MySqlCommand cmd = new MySqlCommand(@"update rates, commentsubjtables set rates.Vote=?Vote, rates.Updated=?Updated 
where rates.UserId=?UserId and rates.SubjId=?SubjId and rates.SubjTableId=commentsubjtables.Id and 
commentsubjtables.TableName=?SubjKind;", con);
                    cmd.Parameters.Add("?SubjId", MySqlDbType.UInt64).Value = UInt64.Parse(SubjectID);
                    cmd.Parameters.Add("?Vote", MySqlDbType.Int16).Value = nVote;
                    cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = JamTypes.User.GetUserFromSession(Session).UIntId;
                    cmd.Parameters.Add("?Updated", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                    cmd.Parameters.Add("?SubjKind", MySqlDbType.VarChar, 30).Value = SubjKind;

                    cmd.ExecuteNonQuery();
                }

                Vote = nVote;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "UIControls_Rating", "AddVote: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
