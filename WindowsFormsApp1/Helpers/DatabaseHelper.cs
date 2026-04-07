using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace WindowsFormsApp1.Helpers
{
    public static class DatabaseHelper
    {
        private static string connectionString;

        static DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["CRMConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Строка подключения не найдена в app.config. Убедитесь, что добавлен элемент <connectionStrings> с именем 'CRMConnection'");
            }
        }

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

    


