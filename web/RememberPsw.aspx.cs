using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Net.Mail;

public partial class RememberPsw : JamPage
{
	public RememberPsw ( )
	{
		m_Code = 58;
	}

    protected void Page_Load(object sender, EventArgs e)
    {
    }

	protected void btnSend_Click ( object sender, EventArgs e )
	{
		lblErrNotice.Visible = false;
		lblEmailErr.Visible = false;
		if ( tbPsw.Text != tbPswRepeat.Text )
		{
			lblErrNotice.Visible = true;
			return;
		}

		string sEmail = tbEmail.Text.Trim ( ).ToLower ( );

		if ( !IsEmailInDB ( sEmail ) )
		{
			lblEmailErr.Visible = true;
			return;
		}

		UpdatePswDb ( tbPsw.Text, sEmail );
		SendPsw ( sEmail, tbPsw.Text );

		Response.Redirect ( "~" );
	}

    private bool IsEmailInDB(string sEmail)
    {
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select Id from userinfo where Email=?email", con);
                cmd.Parameters.Add("?email", MySqlDbType.VarChar, 30).Value = tbEmail.Text.ToLower();
                object oRet = cmd.ExecuteScalar();

                return oRet != null;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "RememberPsw", "IsEmailInDB: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        return false;
    }

    private void SendPsw(string sEmail, string sPsw)
    {
        SmtpClient smtp = new SmtpClient("smtp-9.1gb.ru", 465);
        smtp.Credentials = new System.Net.NetworkCredential("u169996", "bc1ac28b");
        MailAddress to = new MailAddress(sEmail);
        MailMessage message = new MailMessage();
        message.To.Add(to);
        message.From = new MailAddress("nobody@music-head.net");
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        message.Subject = "Новый пароль к music-head.net";
        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.Body = String.Format("Пароль: {0}", sPsw);

        smtp.Send(message);
        message.Dispose();
    }

    private void UpdatePswDb(string sPsw, string sEmail)
    {
        string sHash = Utils.CreatePasswordHash(sPsw);
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
				MySqlCommand cmd = new MySqlCommand ( "update userinfo set PswHash=?hash, Updated=?Updated where Email=?Email", con );
				cmd.Parameters.Add ( "?hash", MySqlDbType.VarChar, 48 ).Value = sHash;
				cmd.Parameters.Add ( "?Updated", MySqlDbType.DateTime ).Value = DateTime.UtcNow;
				cmd.Parameters.Add ( "?Email", MySqlDbType.VarChar, 30 ).Value = sEmail;
				cmd.ExecuteScalar ( );
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "RememberPsw", "UpdatePswDb: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
