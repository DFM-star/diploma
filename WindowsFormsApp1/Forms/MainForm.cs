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

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateWelcomeMessage();
        }

        private void UpdateWelcomeMessage()
        {
            lblWelcome.Text = $"Добро пожаловать, {LoginForm.CurrentUsername} (роль: {LoginForm.CurrentUserRole})";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}