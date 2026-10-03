using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace eShopping_NguyenPhiLong.DAL
{
    public static class DatabaseHelper
    {
        private static string strConn = ConfigurationManager.ConnectionStrings["eShoppingConnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(strConn);
        }

        public static DataTable ExecuteQuery(string sql, SqlParameter[] pars = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (pars != null) cmd.Parameters.AddRange(pars);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}