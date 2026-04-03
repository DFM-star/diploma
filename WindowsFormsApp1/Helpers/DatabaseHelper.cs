using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WindowsFormsApp1.Helpers
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=CLASS14-49\\MSSQLSERVER11;Database=CRMDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static void LogAction(int userId, string action, string tableName, int recordId)
        {
            string query = "INSERT INTO Logs (UserID, Action, TableName, RecordID) VALUES (@uid, @act, @tbl, @rid)";
            ExecuteNonQuery(query, new SqlParameter[] {
                new SqlParameter("@uid", userId),
                new SqlParameter("@act", action),
                new SqlParameter("@tbl", tableName),
                new SqlParameter("@rid", recordId)
            });
        }
    }
}

    


