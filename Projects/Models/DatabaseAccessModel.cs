using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projects.Models
{
    public static class DatabaseAccessModel
    {
        public static DataTable GetTable(string table)
        {
            try
            {
                string entity;
                if(table[0] == 'w' || table[0] == 'e')
                {
                    entity = "PortfolioEntities";
                    if (table.Contains("work") || table == "w")
                    {
                        cmdText = "SELECT C.Id AS Company_Id, C.Name, C.City, C.State, J.Id AS Job_Id, J.Title, JD.Id, JD.StartDate, JD.EndDate, JDESC.Description " +
                                                "FROM COMPANY C, JOB J, JOB_DATES JD, JOB_DESC JDESC WHERE C.Id = J.CompanyId AND J.Id = JD.JobId AND JDESC.JobId = J.Id " +
                                                "ORDER BY ISNULL(EndDate, GETDATE()) DESC";
                    } else if(table.Contains("edu") || table == "e")
                    {
                        cmdText = "SELECT M.Id, S.Name, S.City, S.State, M.Major, M.GPA, M.Graduated, M.Graduation_Date, M.Degree FROM MAJOR M, SCHOOL S WHERE S.Id = M.SchoolId";
                    } else
                    {
                        throw new Exception("no_table");
                    }//end nested if-else if-else
                } else
                {
                    throw new Exception("no_table");
                }

                GetConnectionString(entity);

                dt = new DataTable();
                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                }//end using
                return dt;
            }
            catch (Exception ex)
            {
                connStr = ex.Message;
                return null;
            }
        }//end 

        /// <summary>
        /// Sets the connection string depending on the information that is trying to be accessed.  If the ADO.Net entity does not exist, throws an error.
        /// </summary>
        /// <param name="entity">The entity connection string to get</param>
        private static void GetConnectionString(string entity)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[entity];
            if (settings == null || string.IsNullOrEmpty(settings.ConnectionString))
            {
                throw new Exception("no_connection_string");
            }

            var efConnectionString = settings.ConnectionString;
            var builder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(efConnectionString);
            connStr = builder.ProviderConnectionString;
        }//end GetConnectionString

        private static DataTable dt;
        private static string cmdText;
        private static string connStr;
    }//end class
}//end namespace