using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace Jam
{
    public enum enLang
    {
        en,
        ru
    }
    /// <summary>
    /// Summary description for Utils
    /// </summary>
    public class Utils
    {
        // Return true if strIn is in valid e-mail format.
        static public bool IsValidEmail(string sEmail)
        {
            return Regex.IsMatch(sEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        static public MySqlConnection GetSqlConnection()
        {
            MySqlConnection con = null;
            try
            {
                string sConStr = ConfigurationManager.ConnectionStrings["JamConnectionString"].ToString();
                con = new MySqlConnection(sConStr);
                con.Open();
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Utils", "GetSqlConnection: " + ex.Message);
                con = null;
            }

            return con;
        }

        //prepare text field value (editbox etc.) before pass it into sql query
        public static string SQLEscape(string field)
        {
            if (!String.IsNullOrEmpty(field))
            {
                string cleanSql = field.Trim();
                try
                {
                    string badSql = ";,--,create,drop,select,insert,delete,update,union,sp_,xp_,/";
                    string[] aBadSQL = badSql.Split(',');
                    foreach (string badPatern in aBadSQL)
                    {
                        cleanSql = Regex.Replace(cleanSql, badPatern, "", RegexOptions.IgnoreCase);
                    }
                    cleanSql = cleanSql.Replace("'", "''");
                    cleanSql = cleanSql.Replace("*", "%");
                    return cleanSql.Trim();
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Utils", "GetSqlConnection: " + ex.Message);
                }
            }
            return "";
        }

        //notice: can throw exceptions
        public static void DeleteBand(MySqlConnection con, MySqlTransaction trans, UInt64 nBandId)
        {
            MySqlCommand cmd = new MySqlCommand("delete from bandlanguages where BandId=?BandId;", con, trans);
            cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nBandId;

            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from bands where Id=?BandId;";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from comments using comments, commentsubjtables as cst where comments.SubjId=?BandId and comments.SubjTableId=cst.Id and cst.TableName='bands';";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "update images set BandId=NULL, Updated=UTC_TIMESTAMP() where BandId=?BandId;";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from invites using invites, commentsubjtables as cst where invites.SubjId=?BandId and invites.SubjTableId=cst.Id and cst.TableName='bands';";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "update lyrics set BandId=NULL, Updated=UTC_TIMESTAMP() where BandId=?BandId;";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "update music set BandId=NULL, Updated=UTC_TIMESTAMP() where BandId=?BandId;";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "update video set BandId=NULL, Updated=UTC_TIMESTAMP() where BandId=?BandId;";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from rates using rates, commentsubjtables as cst where rates.SubjId=?BandId and rates.SubjTableId=cst.Id and cst.TableName='bands';";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from usertoband where BandId=?BandId;";

            cmd.ExecuteNonQuery();
        }

        static private ulong GetDefaultLangId()
        {
            ulong val = 0;
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select Id from site_language where Text='English';", con);
                    object ret = cmd.ExecuteScalar();
                    if (ret != null && ret != DBNull.Value)
                    {
                        val = Convert.ToUInt64(ret);
                    }
                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Utils", "GetDefaultLangId: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return val;
        }

        static private enLang GetDefaultLangEnum()
        {
            return enLang.en;
        }

        static private void SetLangCookie(HttpResponse Response, ulong val)
        {
            HttpCookie co = new HttpCookie("JAM_LANG");
            co.Value = val.ToString();
            co.Expires = DateTime.Now + new TimeSpan(7, 0, 0, 0);
            co.HttpOnly = true;

            Response.Cookies.Add(co);
        }

        static private ulong GetLangCookie(HttpRequest Request)
        {
            ulong val = 0;
            HttpCookie lang = Request.Cookies.Get("JAM_LANG");
            if (lang != null)
            {
                try
                {
                    val = ulong.Parse(lang.Value);
                }
                catch
                {
                    val = 0;
                }
            }

            return val;
        }

        static private void SetLangEnumCookie(HttpResponse Response, enLang eVal)
        {
            HttpCookie co = new HttpCookie("JAM_LANG_ENUM");
            co.Value = ((int)eVal).ToString();
            co.Expires = DateTime.Now + new TimeSpan(7, 0, 0, 0);
            co.HttpOnly = true;

            Response.Cookies.Add(co);
        }

        static private enLang GetLangEnumCookie(HttpRequest Request)
        {
            enLang val = GetDefaultLangEnum();
            HttpCookie lang = Request.Cookies.Get("JAM_LANG_ENUM");
            if (lang != null)
            {
                try
                {
                    val = (enLang)int.Parse(lang.Value);
                }
                catch
                {
                    val = GetDefaultLangEnum();
                }
            }

            return val;
        }

        //Lang Cookie notice!
        //Lang id is ulong type
        //Stored in session["LANG_ID"]
        //Stored in Cookie "JAM_LANG" for 7 days
        //Get & Set by GetLangId & SetLangId

        static public void SetLangId(HttpResponse Response, HttpSessionState Session, ulong val)
        {
            Session["LANG_ID"] = val;
            SetLangCookie(Response, val);
        }


        static public ulong GetLangId(HttpResponse Response, HttpRequest Request, HttpSessionState Session)
        {
            try
            {
                //session
                if (Session["LANG_ID"] != null)
                    return Convert.ToUInt64(Session["LANG_ID"]);

                //cookie
                ulong val = GetLangCookie(Request);

                if (val > 0)
                {
                    Session["LANG_ID"] = val;
                    return val;
                }

                //default
                val = GetDefaultLangId();
                SetLangId(Response, Session, val);
                return val;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Utils", "GetLangId: " + ex.Message);
            }

            return GetDefaultLangId();
        }

        static public void SetLangEnum(HttpResponse Response, HttpSessionState Session, enLang eVal)
        {
            Session["LANG_ENUM"] = eVal;
            SetLangEnumCookie(Response, eVal);
        }

        static public enLang GetLangEnum(HttpResponse Response, HttpRequest Request, HttpSessionState Session)
        {
            try
            {
                //session
                if (Session["LANG_ENUM"] != null)
                    return (enLang)Convert.ToInt32(Session["LANG_ENUM"]);

                //cookie
                enLang val = GetLangEnumCookie(Request);

                Session["LANG_ENUM"] = val;
                return val;
            }
            catch (Exception ex)
            {
                JamLog.log(JamLog.enEntryType.error, "Utils", "GetLangEnum: " + ex.Message);
            }

            return GetDefaultLangEnum();
        }

        static public void CommonLocalize(ulong nCode, ulong nLangID, ControlCollection controls)
        {
            MySqlConnection con = Utils.GetSqlConnection();
            if (con != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select si.Text, si.Control_Id, MultipleCont, ColumnIdx,SubControlId, IsMenu, Url, IsForAdmin from site_interface as si where Code=?Code and LangId=?LangId order by MenuOrder;", con);
                    cmd.Parameters.Add("?LangId", MySqlDbType.UInt64).Value = nLangID;
                    cmd.Parameters.Add("?Code", MySqlDbType.UInt64).Value = nCode;

                    Dictionary<string, string> dctControls = new Dictionary<string, string>();
                    Dictionary<string, Dictionary<uint, string>> dctGridColumns = new Dictionary<string, Dictionary<uint, string>>();
                    Dictionary<string, List<VerticalMenu.MenuItem>> dctVertMenu = new Dictionary<string, List<VerticalMenu.MenuItem>>();
                    Dictionary<string, Dictionary<string, string>> dctRepeaterControls = new Dictionary<string, Dictionary<string, string>>();

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        while (rdr.Read())
                        {
                            string sControlId = rdr.GetString("Control_Id");
                            string sText = rdr.GetString("Text");

                            if (!rdr.IsDBNull(rdr.GetOrdinal("SubControlId"))) //control from repeater
                            {
                                string sSubControlId = rdr.GetString("SubControlId");

                                Dictionary<string, string> dctRCtr = null;
                                if (!dctRepeaterControls.TryGetValue(sControlId, out dctRCtr))
                                {
                                    dctRCtr = new Dictionary<string, string>();
                                }

                                dctControls[sSubControlId] = sText;
                                dctRepeaterControls[sControlId] = dctRCtr;
                            }
                            else if (!rdr.IsDBNull(rdr.GetOrdinal("MultipleCont")) && rdr.GetBoolean("MultipleCont"))
                            {
                                Dictionary<uint, string> dctColumns = null;
                                if (!dctGridColumns.TryGetValue(sControlId, out dctColumns))
                                {
                                    dctColumns = new Dictionary<uint, string>();
                                }

                                uint nIdx = rdr.GetUInt32("ColumnIdx");
                                dctColumns[nIdx] = sText;
                                dctGridColumns[sControlId] = dctColumns;
                            }
                            else if (!rdr.IsDBNull(rdr.GetOrdinal("IsMenu")) && rdr.GetBoolean("IsMenu"))
                            {
                                List<VerticalMenu.MenuItem> lstMenu = null;
                                if (!dctVertMenu.TryGetValue(sControlId, out lstMenu))
                                {
                                    lstMenu = new List<VerticalMenu.MenuItem>();
                                }

                                string sUrl = rdr.GetString("Url");
                                bool bIsForAdmin = rdr.IsDBNull(rdr.GetOrdinal("IsForAdmin")) ? false : rdr.GetBoolean("IsForAdmin");
                                VerticalMenu.MenuItem item = new VerticalMenu.MenuItem(sUrl, sText, bIsForAdmin);
                                lstMenu.Add(item);
                                dctVertMenu[sControlId] = lstMenu;
                            }
                            else
                            {
                                dctControls[sControlId] = sText;
                            }
                        }
                        rdr.Close();
                    }

                    if (dctControls.Count > 0 || dctGridColumns.Count > 0 || dctVertMenu.Count > 0)
                    {
                        Utils.SetControlValues(controls, dctControls, dctGridColumns, dctVertMenu, dctRepeaterControls);
                    }

                }
                catch (Exception ex)
                {
                    JamLog.log(JamLog.enEntryType.error, "Utils", "CommonLocalize: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        static private void SetControlValues(ControlCollection controls, Dictionary<string, string> dctValues, Dictionary<string, Dictionary<uint, string>> dctGridColumns, Dictionary<string, List<VerticalMenu.MenuItem>> dctVertMenu, Dictionary<string, Dictionary<string, string>> dctRepeaterControls)
        {
            if (controls != null)
            {
                foreach (Control ctr in controls)
                {
                    if (ctr is VerticalMenu)
                        SetVerticalMenu((VerticalMenu)ctr, dctVertMenu);

                    if (ctr is JamUIControl)
                        continue;

                    if (ctr.Controls != null)
                    {
                        SetControlValues(ctr.Controls, dctValues, dctGridColumns, dctVertMenu, dctRepeaterControls);
                    }

                    if (!String.IsNullOrEmpty(ctr.ID))
                    {
                        if (ctr is HyperLink)
                        {
                            HyperLink hp = (HyperLink)ctr;
                            string sValue = null;
                            if (dctValues.TryGetValue(hp.ID, out sValue))
                            {
                                hp.Text = sValue;
                            }
                        }
                        else if (ctr is Label)
                        {
                            Label lb = (Label)ctr;
                            string sValue = null;
                            if (dctValues.TryGetValue(lb.ID, out sValue))
                            {
                                lb.Text = sValue;
                            }
                        }
                        else if (ctr is Button)
                        {
                            Button bt = (Button)ctr;
                            string sValue = null;
                            if (dctValues.TryGetValue(bt.ID, out sValue))
                            {
                                bt.Text = sValue;
                            }
                        }
                        else if (ctr is LinkButton)
                        {
                            LinkButton lbt = (LinkButton)ctr;
                            string sValue = null;
                            if (dctValues.TryGetValue(lbt.ID, out sValue))
                            {
                                lbt.Text = sValue;
                            }
                        }
                        else if (ctr is GridView)
                        {
                            GridView gv = (GridView)ctr;
                            Dictionary<uint, string> dctColumns = null;
                            if (dctGridColumns.TryGetValue(gv.ID, out dctColumns))
                            {
                                foreach (KeyValuePair<uint, string> kv in dctColumns)
                                {
                                    gv.Columns[(int)kv.Key].HeaderText = kv.Value;
                                }
                            }
                        }
                        else if (ctr is CheckBox)
                        {
                            CheckBox cb = (CheckBox)ctr;
                            string sValue = null;
                            if (dctValues.TryGetValue(cb.ID, out sValue))
                            {
                                cb.Text = sValue;
                            }
                        }
                        else if (ctr is TextBox)
                        {
                            TextBox tb = (TextBox)ctr;
                            string sValue = null;
                            if (dctValues.TryGetValue(tb.ID, out sValue))
                            {
                                tb.Text = sValue;
                            }
                        }
                        else if (ctr is Repeater)
                        {
                            Repeater rp = (Repeater)ctr;
                            if (rp.Controls != null && rp.Controls.Count > 0 && rp.Controls[0] != null)
                            {
                                Dictionary<string, string> dctCtr = null;
                                if (dctRepeaterControls.TryGetValue(rp.ID, out dctCtr))
                                {
                                    SetControlValues(rp.Controls[0].Controls, dctCtr, null, null, null);
                                }
                            }
                        }
                        else if (ctr is HtmlGenericControl)
                        {
                            HtmlGenericControl hg = (HtmlGenericControl)ctr;
                            string sValue = null;
                            if (dctValues.TryGetValue(hg.ID, out sValue))
                            {
                                hg.InnerText = sValue;
                            }
                        }
                    }
                }
            }
        }

        private static void SetVerticalMenu(VerticalMenu ctr, Dictionary<string, List<VerticalMenu.MenuItem>> dctVertMenu)
        {
            List<VerticalMenu.MenuItem> lstMenu = null;
            if (dctVertMenu.TryGetValue(ctr.ID, out lstMenu))
            {
                ctr.ItemsSchema = lstMenu;
            }
        }

        public static string CreateSalt(int size)
        {
            // Generate a cryptographic random number using the cryptographic
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        public static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd =
                  FormsAuthentication.HashPasswordForStoringInConfigFile(
                                                       saltAndPwd, "SHA1");
            hashedPwd = String.Concat(hashedPwd, salt);
            return hashedPwd;
        }

        public static string CreatePasswordHash(string pwd)
        {
            string sPsw = pwd;
            int saltSize = 6;
            string salt = Utils.CreateSalt(saltSize);//i used array of 6 bytes to generate salt, but get salt string with length 8; need some reseach TODO
            return Utils.CreatePasswordHash(sPsw, salt);
        }
    }
}
