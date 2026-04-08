namespace WindowsFormsApp1.Forms
{
    partial class MessageHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMessages;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblCount;


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
            this.dgvMessages = new System.Windows.Forms.DataGridView();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.ClientSize = new System.Drawing.Size(700, 500);

            // dgvMessages
            this.dgvMessages.Location = new System.Drawing.Point(12, 12);
            this.dgvMessages.Size = new System.Drawing.Size(676, 350);
            this.dgvMessages.ReadOnly = true;
            this.dgvMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(12, 370);
            this.txtMessage.Size = new System.Drawing.Size(550, 22);
            this.txtMessage.Multiline = true;
            this.txtMessage.Height = 60;

            // btnSend
            this.btnSend.Location = new System.Drawing.Point(570, 370);
            this.btnSend.Size = new System.Drawing.Size(118, 60);
            this.btnSend.Text = "Отправить";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // lblCount
            this.lblCount.Location = new System.Drawing.Point(12, 440);
            this.lblCount.Text = "Всего сообщений: 0";

            // MessageHistoryForrm
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.dgvMessages);

        }

        #endregion
    }
}