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
    public partial class ClientForm : Form
    {
        private int? editClientId = null;

        //Свойства
        public string FullName => txtFullName.Text;
        public string Phone => txtPhone.Text;
        public string Email => txtEmail.Text;
        public string Company => txtCompany.Text;
        public string Address => txtAddress.Text;
        public DateTime? NextReminderDate => chkReminder.Checked ? (DateTime?)dtpReminder.Value : null;

        public ClientForm(int? clientId = null)
        {
            InitializeComponent();
            editClientId = clientId;

            if (clientId.HasValue)
            {
                this.Text = "Редактирование клиента";
                LoadClientData(clientId.Value);
            }
            else
            {
                this.Text = "Добавление клиента";
                dtpReminder.Value = DateTime.Now.AddHours(1);
            }
        }

        private void LoadClientData(int clientId)
        {
            string query = "SELECT * FROM Clients WHERE ClientID = @id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new SqlParameter[] { new SqlParameter("@id", clientId) });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtFullName.Text = row["FullName"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtCompany.Text = row["Company"].ToString();
                txtAddress.Text = row["Address"].ToString();

                if (row["NextReminderDate"] != DBNull.Value)
                {
                    chkReminder.Checked = true;
                    dtpReminder.Value = Convert.ToDateTime(row["NextReminderDate"]);
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО клиента!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Введите корректный email!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (chkReminder.Checked && dtpReminder.Value <= DateTime.Now)
            {
                MessageBox.Show("Дата напоминания должна быть в будущем!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void chkReminder_CheckedChanged(object sender, EventArgs e)
        {
            dtpReminder.Enabled = chkReminder.Checked;
        }
    }
}

    

