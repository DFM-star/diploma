using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helpers;
using Microsoft.Data.SqlClient;

namespace WindowsFormsApp1.Forms
{
    public partial class LoginForm : Form
    {
        public static int CurrentUserID { get; private set; }
        public static string CurrentUserRole { get; private set; }
        public static string CurrentUsername { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                string query = "SELECT UserID, Role, FullName FROM Users WHERE Username=@user AND PasswordHash=@pass";
                DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter[] {
                    new SqlParameter("@user", username),
                    new SqlParameter("@pass", password)
                });

                if (dt.Rows.Count > 0)
                {
                    CurrentUserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    CurrentUserRole = dt.Rows[0]["Role"].ToString();
                    CurrentUsername = dt.Rows[0]["FullName"].ToString();

                    DatabaseHelper.LogAction(CurrentUserID, "Login", "Users", CurrentUserID);

                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}\n\nПроверьте, что SQL Server запущен и БД создана.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
