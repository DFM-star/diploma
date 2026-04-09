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
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            // валидация ввода
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Введите логин!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {   // проверка учетных данных из бд
                string query = "SELECT UserID, Role, FullName FROM Users WHERE Username=@user AND PasswordHash=@pass";
                DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter[] {
                    new SqlParameter("@user", username),
                    new SqlParameter("@pass", password)
                });

                if (dt.Rows.Count > 0)
                {   // сохранение данных о пользователе
                    CurrentUserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    CurrentUserRole = dt.Rows[0]["Role"].ToString();
                    CurrentUsername = dt.Rows[0]["FullName"].ToString();
                    // логгирование входа
                    DatabaseHelper.LogAction(CurrentUserID, "Login", "Users", CurrentUserID);

                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}\n\n" +
                    "Проверьте:\n" +
                    "1. Запущен ли SQL Server\n" +
                    "2. Правильно ли указана строка подключения в DatabaseHelper.cs\n" +
                    "3. Существует ли база данных CRMDatabase",
                    "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
