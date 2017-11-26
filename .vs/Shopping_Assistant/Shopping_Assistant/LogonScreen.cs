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
        //This method is the constructor for the Logon screen
        public LogonScreen()
        {
            InitializeComponent();//displays the Logon screen
        }

        //the folowing 6 methods are used to create the greyed out text watermarks for the textbox objects
        private void passwordTextBox_Leave(object sender, EventArgs e)//when the user leaves the textbox
        {
            if (passwordTextBox.Text.Length == 0)
            {
                passwordTextBox.Text = "Password";//changes displayed text
                passwordTextBox.ForeColor = SystemColors.GrayText;//changes font color
                passwordTextBox.PasswordChar = '\0';//resets password character to nothing
            }
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)//when the user enters the textbox
        {
            if (passwordTextBox.Text == "Password")
            {
                passwordTextBox.Text = "";//changes displayed text
                passwordTextBox.ForeColor = SystemColors.WindowText;//changes font color
                passwordTextBox.PasswordChar = '\0';//resets password character to nothing
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)//when the text is changed in the textbox
        {
            passwordTextBox.ForeColor = SystemColors.WindowText;//changes font color
            passwordTextBox.PasswordChar = '*';//sets the password character to a star so that the password text is not visible
        }

        private void userNameTextBox_Leave(object sender, EventArgs e)//when the user leaves the textbox
        {
            if (userNameTextBox.Text.Length == 0)
            {
                userNameTextBox.Text = "Email Address";//changes displayed text
                userNameTextBox.ForeColor = SystemColors.GrayText;//changes font color
            }
        }

        private void userNameTextBox_Enter(object sender, EventArgs e)//when the user enters the textbox
        {
            if (userNameTextBox.Text == "Email Address")
            {
                userNameTextBox.Text = "";//changes displayed text
                userNameTextBox.ForeColor = SystemColors.WindowText;//changes font color
            }
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)//when the text is changed in the textbox
        {
          userNameTextBox.ForeColor = SystemColors.WindowText;//changes font color
        }


        //the following methods are for form navigation
        private void signUpButton_Click(object sender, EventArgs e)//when the Sign Up button is clicked
        {
            Form signUpScreen = new SignUpScreen(this);//creates a new instance of the Sign Up screen
            signUpScreen.Show();//displays the new Sign Up screen
            this.Hide();//hides this screen from view
        }

        private void exitButton_Click(object sender, EventArgs e)//when the Exit button is clicked
        {
            Application.Exit();//Closes the application and ends the program
        }

        private void logOnButton_Click(object sender, EventArgs e)//when the Log On button is clicked
        {
            Form MainMenuScreen = new MainMenuScreen(this);//creates a new instance of the Main Menu screen
            MainMenuScreen.Show();//displays the Main Menu screen
            this.Hide();//hides this screen from view
        }
    }
}
