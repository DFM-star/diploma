namespace WindowsFormsApp1.Forms
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DateTimePicker dtpReminder;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblReminder;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.dtpReminder = new System.Windows.Forms.DateTimePicker();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblReminder = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(20, 25);
            this.lblFullName.Size = new System.Drawing.Size(55, 17);
            this.lblFullName.Text = "ФИО: *";

            // txtFullName
            this.txtFullName.Location = new System.Drawing.Point(120, 22);
            this.txtFullName.Size = new System.Drawing.Size(300, 22);

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 60);
            this.lblPhone.Text = "Телефон:";

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(120, 57);
            this.txtPhone.Size = new System.Drawing.Size(300, 22);

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 95);
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(120, 92);
            this.txtEmail.Size = new System.Drawing.Size(300, 22);

            // lblCompany
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(20, 130);
            this.lblCompany.Text = "Компания:";

            // txtCompany
            this.txtCompany.Location = new System.Drawing.Point(120, 127);
            this.txtCompany.Size = new System.Drawing.Size(300, 22);

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 165);
            this.lblAddress.Text = "Адрес:";

            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(120, 162);
            this.txtAddress.Size = new System.Drawing.Size(300, 22);

            // lblReminder
            this.lblReminder.AutoSize = true;
            this.lblReminder.Location = new System.Drawing.Point(20, 200);
            this.lblReminder.Text = "Напоминание:";

            // chkReminder
            this.chkReminder.AutoSize = true;
            this.chkReminder.Location = new System.Drawing.Point(120, 199);
            this.chkReminder.Text = "Активировать напоминание";

            // dtpReminder
            this.dtpReminder.Location = new System.Drawing.Point(120, 230);
            this.dtpReminder.Size = new System.Drawing.Size(200, 22);
            this.dtpReminder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReminder.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpReminder.ShowUpDown = true;
            this.dtpReminder.Enabled = false;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(120, 280);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Сохранить";
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(230, 280);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // ClientForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 340);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpReminder);
            this.Controls.Add(this.chkReminder);
            this.Controls.Add(this.lblReminder);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Клиент";

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}