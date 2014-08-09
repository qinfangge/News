using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
/*
 * 示例： SqlConnection conn = DBManager.GetConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
 * conn = DBManager.GetConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
 * 
 */
namespace tk.tingyuxuan.utils
{
    public class DBManager
    {

        private static SqlConnection conn;
        public static SqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);
            }
            return conn;
        }

        public static void CloseConnection()
        {
            if (conn.State==System.Data.ConnectionState.Open)
                conn.Close();
        }
    }
}