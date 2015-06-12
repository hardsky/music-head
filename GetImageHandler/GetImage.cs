using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.SessionState;

namespace GetImageHandler
{
    /// <summary>
    /// Summary description for GetMusic
    /// </summary>
    public class GetImage : IHttpHandler, IReadOnlySessionState
    {
        public GetImage()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string sId = context.Request["id"];
            if (!String.IsNullOrEmpty(sId))
            {
                bool bAccess = false;
                string sFileName = null;

                MySqlConnection con = new MySqlConnection(Properties.Settings.Default["JamConnectionString"].ToString());
                if (con != null)
                {
                    try
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("select BandId, Visibility, Author, FileName from images where Deleted=0 and Id=?imageId", con);
                        cmd.Parameters.Add("?imageId", MySqlDbType.UInt64).Value = UInt64.Parse(sId);
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr != null)
                        {
                            if (rdr.Read())
                            {
                                short nVisib = rdr.GetInt16("Visibility");
                                ulong nCreater = rdr.GetUInt64("Author");
                                ulong nBandId = 0;
                                bool IsBandIdExist = false;
                                IsBandIdExist = !rdr.IsDBNull(rdr.GetOrdinal("BandId"));
                                if (IsBandIdExist)
                                {
                                    nBandId = rdr.GetUInt64("BandId");
                                }

                                sFileName = context.Server.MapPath(rdr.GetString("FileName"));

                                do
                                {
                                    bAccess = (nVisib == 0); //all

                                    if (bAccess)
                                        break;

                                    JamTypes.User user_info = JamTypes.User.GetUserFromSession(context.Session);
                                    if (user_info == null) //something wrong
                                        break; 

                                    bAccess = (nVisib == 1); //registered

                                    if (bAccess)
                                        break;

                                    bAccess = (user_info.UIntId == nCreater) && (nVisib == 2); //self
                                    if (bAccess)
                                        break;

                                    if (IsBandIdExist)
                                        rdr.Close();

                                    if (nVisib == 3) //group
                                    {
                                        cmd = new MySqlCommand("select Id from usertoband where UserId=?UserId and BandId=?BandId and Deleted=0", con);
                                        cmd.Parameters.Add("?UserId", MySqlDbType.UInt64).Value = user_info.UIntId;
                                        cmd.Parameters.Add("?BandId", MySqlDbType.UInt64).Value = nBandId;

                                        object oId = cmd.ExecuteScalar();
                                        bAccess = (oId != null && oId != DBNull.Value);
                                    }

                                } while (false);
                            }
                            rdr.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        bAccess = false;
                        //JamLog.log(JamLog.enEntryType.error, "GetMusic", "ProcessRequest: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                if (bAccess && !String.IsNullOrEmpty(sFileName))
                {
                    context.Response.WriteFile(sFileName);
                }
            }
        }

        #endregion
    }
}
