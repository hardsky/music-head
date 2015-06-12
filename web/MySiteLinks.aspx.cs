using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jam;
using MySql.Data.MySqlClient;
using System.Data;

public partial class MySiteLinks : JamPage
{
	protected void Page_Load ( object sender, EventArgs e )
	{
		if ( !IsPostBack )
		{
			FillGrid ( );
		}
	}

	private void FillGrid ( )
	{
		MySqlConnection con = Utils.GetSqlConnection ( );
		if ( con != null )
		{
			try
			{
				MySqlCommand cmd = new MySqlCommand ( "select Id, url, descr, created, is_link_on_me, IsPublished from links_change where LangId=?langid;", con );
                cmd.Parameters.Add("?langid", MySqlDbType.UInt64).Value = this.LangUId;
				MySqlDataAdapter adp = new MySqlDataAdapter ( cmd );
				DataSet ds = new DataSet ( );
				adp.Fill ( ds );
				gwLinks.DataSource = ds;
				gwLinks.DataBind ( );
			}
			catch ( Exception ex )
			{
				JamLog.log ( JamLog.enEntryType.error, "MySiteLinks: FillGrid", ex.Message );
			}
			finally
			{
				con.Close ( );
			}
		}
	}

	protected void btnAdd_Click ( object sender, EventArgs e )
	{
		tblLink.Visible = true;
		btnAdd.Visible = false;
	}
	protected void btnCancel_Click ( object sender, EventArgs e )
	{
		tblLink.Visible = false;
		btnAdd.Visible = true;
	}
	protected void btnSave_Click ( object sender, EventArgs e )
	{
        int iRows = 0;
        MySqlConnection con = Utils.GetSqlConnection();
        if (con != null)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(@"insert into links_change (url, descr, created, updated, is_link_on_me, LangId, IsPublished) 
                values(?url, ?descr, NOW(), NOW(), ?islink, ?langid, ?ispub)", con);

                cmd.Parameters.Add("?url", MySqlDbType.VarChar, 45).Value = tbUrl.Text.Trim();
                cmd.Parameters.Add("?descr", MySqlDbType.VarChar, 512).Value = Utils.SQLEscape(tbDescr.Text);
                cmd.Parameters.Add("?islink", MySqlDbType.Bit).Value = cbIsLink.Checked;
                cmd.Parameters.Add("?langid", MySqlDbType.UInt64).Value = this.LangUId;
                cmd.Parameters.Add("?ispub", MySqlDbType.Bit).Value = cbPublish.Checked;

                iRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "MySiteLinks: btnSave_Click", ex.Message);
            }
            finally
            {
                con.Close();
            }

            if (iRows > 0)
                Response.Redirect("~/MySiteLinks.aspx");
        }
	}

    protected void gwLinks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sId = (string)e.Keys["Id"];
        if (!String.IsNullOrEmpty(sId))
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("delete from links_change where Id=?id", con);
                    cmd.Parameters.Add("?id", MySqlDbType.UInt64).Value = UInt64.Parse(sId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "MySiteLinks: gwLinks_RowDeleting", ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
    protected void gwLinks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
}
