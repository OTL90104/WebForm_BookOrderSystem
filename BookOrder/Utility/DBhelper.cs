using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookOrder.Utility
{
    public class DBhelper
    {
        public static string connectionString = ConfigurationManager
            .ConnectionStrings["testdbConnectionString"]
            .ConnectionString;


        public int ExecuteNonQuery(SqlCommand cmd)
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(DBhelper.connectionString))
            {
                connection.Open();
                cmd.Connection = connection;
                try
                {
                    count = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    connection.Close();
                }
            }
            return count;
        }

        public int ExecuteNonQuery(List<SqlCommand> cmdList)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(DBhelper.connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (var cmd in cmdList)
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = transaction;
                        count += cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    connection.Close();
                }
            }
            return count;
        }
    }
}