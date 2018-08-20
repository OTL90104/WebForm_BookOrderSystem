using BookOrder.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookOrder.Model
{
    public class ParametersDetail
    {
        public int PDID { get; private set; }
        public int PID { get; private set; }
        public string KeyName { get; set; }
        public string Value { get; set; }
        public DateTime CreateDateTime { get; private set; }

        public ParametersDetail()
        {

        }

        public ParametersDetail(int PID)
        {
            this.PID = PID;
        }

        private string SelectByPidCommand()
        {
            return @"SELECT [KeyName]
                            ,[Value]
                            FROM [ParametersDetail] AS PD
                            WHERE PD.[PID] = @PID";
        }

        public IEnumerable<ParametersDetail> SelectByPid()
        {
            List<ParametersDetail> list = new List<ParametersDetail>();
            using (SqlConnection connection = new SqlConnection(DBhelper.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SelectByPidCommand(), connection))
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@PID", this.PID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ParametersDetail details = new ParametersDetail();
                            details.KeyName = reader.GetString(0);
                            details.Value = reader.GetString(1);
                            list.Add(details);
                        }
                    }
                }
            }
            return list;
        }
    }
}