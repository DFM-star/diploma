namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblStatus;


        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Size = new System.Drawing.Size(150, 20);
            this.lblWelcome.Text = "Добро пожаловать!";

            // dgvClients
            this.dgvClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClients.Location = new System.Drawing.Point(12, 50);
            this.dgvClients.Size = new System.Drawing.Size(860, 350);
            this.dgvClients.ReadOnly = true;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.MultiSelect = false;

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(12, 410);
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnAddClient
            this.btnAddClient.Location = new System.Drawing.Point(120, 410);
            this.btnAddClient.Size = new System.Drawing.Size(100, 35);
            this.btnAddClient.Text = "Добавить";
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);

            // btnEditClient
            this.btnEditClient.Location = new System.Drawing.Point(228, 410);
            this.btnEditClient.Size = new System.Drawing.Size(100, 35);
            this.btnEditClient.Text = "Изменить";
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);

            // btnDeleteClient
            this.btnDeleteClient.Location = new System.Drawing.Point(336, 410);
            this.btnDeleteClient.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteClient.Text = "Удалить";
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(772, 410);
            this.btnExit.Size = new System.Drawing.Size(100, 35);
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 455);
            this.lblStatus.Text = "Готово";

            // MainForm
            this.ClientSize = new System.Drawing.Size(884, 490);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDeleteClient);
            this.Controls.Add(this.btnEditClient);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.lblWelcome);
            this.Text = "CRM Система - Управление клиентами";

            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();


        }

        #endregion
    }
}

