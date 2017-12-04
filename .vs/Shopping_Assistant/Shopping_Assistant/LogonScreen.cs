using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Assistant
{
    public partial class LogonScreen : Form
    {
        DataTable dt_UserData = new DataTable();//creates a new datatable to store the user data
        string userID = "";//stores the User ID so that it can be passed into the Main Menu screen

    static string userDataFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\non-embedded text files\\Test_User_List.csv";//sets reletive filepath for the user data file

        //This method is the constructor for the Logon screen
        public LogonScreen()
        {
            if (dt_UserData.Columns.Count == 0)//when there are no columns in the datatable
            {
                dt_UserData.Columns.Add("UserID", typeof(string));//adds a new column
                dt_UserData.Columns.Add("FirstName", typeof(string));//adds a new column
                dt_UserData.Columns.Add("LastName", typeof(string));//adds a new column
                dt_UserData.Columns.Add("EmailAddress", typeof(string));//adds a new column
                dt_UserData.Columns.Add("Password", typeof(string));//adds a new column
            }

            
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
            ImportData(dt_UserData, userDataFilePath);//this is a call to the import data method to populate the datatable with user data

            if (checkCredentials(userNameTextBox.Text.ToString(),passwordTextBox.Text.ToString()) == true)
            {
                Form MainMenuScreen = new MainMenuScreen(this,userID.ToString());//creates a new instance of the Main Menu screen
                MainMenuScreen.Show();//displays the Main Menu screen
                this.Hide();//hides this screen from view
                dt_UserData.Clear();//empties datatable
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Logon Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);//displays a message to the user indicationg and incorrect email or password has been used
                dt_UserData.Clear();//empties datatable
            }
        }

        //This method is utilized to check to see it the email address is already in use
        private bool checkCredentials(string emailAddress,string password)
        {
            bool doesMatch = false;//varible used store the result of the match check

            for (var r = 0; r < dt_UserData.Rows.Count; r++)//loops through each row in the user data
            {
                if (dt_UserData.Rows[r]["EmailAddress"].ToString() == emailAddress && dt_UserData.Rows[r]["Password"].ToString() == password)//checks to find matching credentials
                {
                    doesMatch = true;// changes match varible to true
                    userID = dt_UserData.Rows[r]["UserID"].ToString();//takes the matching records UserID value and stores it within a variable
                    break;//breaks out of the loop since no more iterations will be neccisary
                }
            }
            return doesMatch;
        }

        static void ImportData(DataTable datatable, string filePath)// this method imports a text/csv file and pushes it into a datatable object
        {
            //Load File into DatatTable
            using (StreamReader inFile = new StreamReader(filePath))//this creates a streamreader to read the contents of the text file
            {
                //reads entire txt file
                string wholeFile = inFile.ReadToEnd();

                //breaks file into each distinct row (This will add a blank row for each row since it is looking at returns and new lines)
                string[] fileRows = wholeFile.Split("\r\n".ToArray());

                //This loop add the data to the datatable while ignoring any empty or blank lines.
                foreach (string r in fileRows)
                {
                    if (r != "")
                    {
                        string[] fileRowFields = r.Split(",".ToCharArray());//this splits each line from the text file into individual fields
                        datatable.Rows.Add(fileRowFields);//this will add each newly created row of data to the datatable
                    }
                }
            }
        }
    }
}
