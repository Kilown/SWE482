using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Assistant
{
    public partial class LogonScreen : Form
    {
        public LogonScreen()
        {
            InitializeComponent();
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Length == 0)
            {
                passwordTextBox.Text = "Password";
                passwordTextBox.ForeColor = SystemColors.GrayText;
                passwordTextBox.PasswordChar = '\0';
            }
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password")
            {
                passwordTextBox.Text = "";
                passwordTextBox.ForeColor = SystemColors.WindowText;
                passwordTextBox.PasswordChar = '\0';
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.ForeColor = SystemColors.WindowText;
            passwordTextBox.PasswordChar = '*';
        }

        private void userNameTextBox_Leave(object sender, EventArgs e)
        {
            if (userNameTextBox.Text.Length == 0)
            {
                userNameTextBox.Text = "Email Address";
                userNameTextBox.ForeColor = SystemColors.GrayText;
                userNameTextBox.PasswordChar = '\0';
            }
        }

        private void userNameTextBox_Enter(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == "Email Address")
            {
                userNameTextBox.Text = "";
                userNameTextBox.ForeColor = SystemColors.WindowText;
                userNameTextBox.PasswordChar = '\0';
            }
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
          userNameTextBox.ForeColor = SystemColors.WindowText;
        }

    }
}
