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
using Microsoft.Data.SqlClient;

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
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            if (clientForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string query = @"INSERT INTO Clients (FullName, Phone, Email, Company, Address, NextReminderDate, CreatedBy) 
                            VALUES (@name, @phone, @email, @company, @addr, @reminder, @uid)";

                    DatabaseHelper.ExecuteNonQuery(query, new SqlParameter[] {
                new SqlParameter("@name", clientForm.FullName),
                new SqlParameter("@phone", (object)clientForm.Phone ?? DBNull.Value),
                new SqlParameter("@email", (object)clientForm.Email ?? DBNull.Value),
                new SqlParameter("@company", (object)clientForm.Company ?? DBNull.Value),
                new SqlParameter("@addr", (object)clientForm.Address ?? DBNull.Value),
                new SqlParameter("@reminder", (object)clientForm.NextReminderDate ?? DBNull.Value),
                new SqlParameter("@uid", LoginForm.CurrentUserID)
            });

                    DatabaseHelper.LogAction(LoginForm.CurrentUserID, "Insert", "Clients", 0);
                    LoadClients();

                    MessageBox.Show("Клиент успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null) return;

            int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientID"].Value);
            ClientForm clientForm = new ClientForm(clientId);

            if (clientForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string query = @"UPDATE Clients SET FullName=@name, Phone=@phone, Email=@email, 
                            Company=@company, Address=@addr, NextReminderDate=@reminder 
                            WHERE ClientID=@id";

                    DatabaseHelper.ExecuteNonQuery(query, new SqlParameter[] {
                new SqlParameter("@name", clientForm.FullName),
                new SqlParameter("@phone", (object)clientForm.Phone ?? DBNull.Value),
                new SqlParameter("@email", (object)clientForm.Email ?? DBNull.Value),
                new SqlParameter("@company", (object)clientForm.Company ?? DBNull.Value),
                new SqlParameter("@addr", (object)clientForm.Address ?? DBNull.Value),
                new SqlParameter("@reminder", (object)clientForm.NextReminderDate ?? DBNull.Value),
                new SqlParameter("@id", clientId)
            });

                    DatabaseHelper.LogAction(LoginForm.CurrentUserID, "Update", "Clients", clientId);
                    LoadClients();

                    MessageBox.Show("Данные клиента обновлены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null) return;

            int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ClientID"].Value);
            string clientName = dgvClients.CurrentRow.Cells["FullName"].Value.ToString();

            DialogResult result = MessageBox.Show($"Удалить клиента \"{clientName}\"?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM Clients WHERE ClientID=@id",
                        new SqlParameter[] { new SqlParameter("@id", clientId) });

                    DatabaseHelper.LogAction(LoginForm.CurrentUserID, "Delete", "Clients", clientId);
                    LoadClients();

                    MessageBox.Show("Клиент удалён!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}