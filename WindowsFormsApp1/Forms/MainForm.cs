using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Helpers;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CheckAccessRights();
            LoadClients();

        }

        private void CheckAccessRights()
        {
            if (LoginForm.CurrentUserRole == "Client")
            {
                btnAddClient.Enabled = false;
                btnEditClient.Enabled = false;
                btnDeleteClient.Enabled = false;
            }
        }

        private void LoadClients()
        {
            try
            {
                string query = "SELECT ClientID, FullName, Phone, Email, Company FROM Clients";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvClients.DataSource = dt;

                lblStatus.Text = $"Загружено клиентов: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки клиентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DatabaseHelper.LogAction(LoginForm.CurrentUserID, "Logout", "Users", LoginForm.CurrentUserID);
            Application.Exit();
        }
    }
}