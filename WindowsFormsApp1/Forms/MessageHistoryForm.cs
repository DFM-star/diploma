using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using WindowsFormsApp1.Helpers;

namespace WindowsFormsApp1.Forms
{
    public partial class MessageHistoryForm : Form
    {
        private int clientId;
        private string clientName;

        public MessageHistoryForm(int clientId, string clientName)
        {
            InitializeComponent();
            this.clientId = clientId;
            this.clientName = clientName;
            this.Text = $"История общения: {clientName}";
            LoadMessages();
        }
        private void LoadMessages()
        {
            try
            {
                string query = @"SELECT m.MessageText, m.MessageDate, m.Direction, u.FullName as UserName 
                                FROM Messages m 
                                LEFT JOIN Users u ON m.SenderID = u.UserID 
                                WHERE m.ClientID = @cid 
                                ORDER BY m.MessageDate DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new SqlParameter[] { new SqlParameter("@cid", clientId) });

                dgvMessages.DataSource = dt;

                // Настройка отображения
                if (dgvMessages.Columns.Contains("MessageDate"))
                    dgvMessages.Columns["MessageDate"].HeaderText = "Дата";
                if (dgvMessages.Columns.Contains("Direction"))
                    dgvMessages.Columns["Direction"].HeaderText = "Направление";
                if (dgvMessages.Columns.Contains("MessageText"))
                    dgvMessages.Columns["MessageText"].HeaderText = "Сообщение";
                if (dgvMessages.Columns.Contains("UserName"))
                    dgvMessages.Columns["UserName"].HeaderText = "Пользователь";

                lblCount.Text = $"Всего сообщений: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сообщений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Введите текст сообщения!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO Messages (ClientID, SenderID, MessageText, Direction) 
                                VALUES (@cid, @sid, @msg, 'Outgoing')";

                DatabaseHelper.ExecuteNonQuery(query, new SqlParameter[] {
                    new SqlParameter("@cid", clientId),
                    new SqlParameter("@sid", LoginForm.CurrentUserID),
                    new SqlParameter("@msg", txtMessage.Text)
                });

                DatabaseHelper.LogAction(LoginForm.CurrentUserID, "AddMessage", "Messages", clientId);

                LoadMessages();
                txtMessage.Clear();

                MessageBox.Show("Сообщение отправлено!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
