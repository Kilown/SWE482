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
    public partial class SignUpScreen : Form
    {
        //This is a variable declaration used to store the previous screen to reopen it upon the closeing of the current screen
        Form previousForm;

        static string userDataFilePath = "";// creates a variable to hold dynamic file path for the user data file

        //The following Method is the contructor for the Sign up screen
        public SignUpScreen(Form parentForm)
        {
            string userDataFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\non-embedded text files\\Test_User_List";
            //sets a variable to equil the LogonForm
            previousForm = parentForm;

            //Initializes the Sign up screen
            InitializeComponent();
        }

        //The Next 14 Methods are utilized to create the grayed out watermark text for the screen textbox objects as well as enabling the password textbox to hide passwords  from view
        private void newFNameTextBox_Leave(object sender, EventArgs e)//when a the texbox is exited
        {
            if (newFNameTextBox.Text.Length == 0)
            {
                newFNameTextBox.Text = "First Name"; //sets textbox text
                newFNameTextBox.ForeColor = SystemColors.GrayText;//sets font color
            }
        }

        private void newFNameTextBox_Enter(object sender, EventArgs e)//when the user enters the textbox
        {
            if (newFNameTextBox.Text == "First Name")
            {
                newFNameTextBox.Text = "";//sets textbox's displayed text
                newFNameTextBox.ForeColor = SystemColors.WindowText;//changes font color
            }
        }

        private void newFNameTextBox_TextChanged(object sender, EventArgs e)//when the text is changed in the textbox
        {
            newFNameTextBox.ForeColor = SystemColors.WindowText;//changes font color
        }

        private void newLNameTextBox_Leave(object sender, EventArgs e)//when a the texbox is exited
        {
            if (newLNameTextBox.Text.Length == 0)
            {
                newLNameTextBox.Text = "Last Name";//changes textbox's displayed text
                newLNameTextBox.ForeColor = SystemColors.GrayText;//changes font color
            }
        }

        private void newLNameTextBox_Enter(object sender, EventArgs e)//when the user enters the textbox
        {
            if (newLNameTextBox.Text == "Last Name")
            {
                newLNameTextBox.Text = "";//changes textbox's displayed text
                newLNameTextBox.ForeColor = SystemColors.WindowText;//changes font color
            }
        }

        private void newLNameTextBox_TextChanged(object sender, EventArgs e)//when text is changed in the textbox
        {
            newLNameTextBox.ForeColor = SystemColors.WindowText;//changes font color
        }
        private void newEAddressTextBox_Leave(object sender, EventArgs e)//when the user exits the textbox
        {
            if (newEAddressTextBox.Text.Length == 0)
            {
                newEAddressTextBox.Text = "Email Address";//changes displayed text
                newEAddressTextBox.ForeColor = SystemColors.GrayText;//changes font color
            }
        }

        private void newEAddressTextBox_Enter(object sender, EventArgs e)//when the user enters the textbox
        {
            if (newEAddressTextBox.Text == "Email Address")
            {
                newEAddressTextBox.Text = "";//changes displayed text
                newEAddressTextBox.ForeColor = SystemColors.WindowText;//changes font color
            }
        }

        private void newEAddressTextBox_TextChanged(object sender, EventArgs e)//when text is changed in the textbox
        {
            newEAddressTextBox.ForeColor = SystemColors.WindowText;//changes font color
        }
        private void newPasswordTextBox_Leave(object sender, EventArgs e)//when the user exits the textbox
        {
            if (newPasswordTextBox.Text.Length == 0)
            {
                newPasswordTextBox.Text = "Password";//changes displayed text
                newPasswordTextBox.ForeColor = SystemColors.GrayText;//changes font color
                newPasswordTextBox.PasswordChar = '\0';//resets the password character to nothing
            }
        }

        private void newPasswordTextBox_Enter(object sender, EventArgs e)//when the user enters the textbox
        {
            if (newPasswordTextBox.Text == "Password")
            {
                newPasswordTextBox.Text = "";//changes displayed text
                newPasswordTextBox.ForeColor = SystemColors.WindowText;//changes font color
                newPasswordTextBox.PasswordChar = '\0';//resets password character to nothing
            }
        }

        private void newPasswordTextBox_TextChanged(object sender, EventArgs e)//when text is changed in the textbox
        {
            newPasswordTextBox.ForeColor = SystemColors.WindowText;//changes font color
            newPasswordTextBox.PasswordChar = '*';//changes password charecter to a star so that the actual password text is not displayed
        }
        private void confirmPasswordTextBox_Leave(object sender, EventArgs e)//when the user exits the textbox
        {
            if (confirmPasswordTextBox.Text.Length == 0)
            {
                confirmPasswordTextBox.Text = "Confirm Password";//changes displayed text
                confirmPasswordTextBox.ForeColor = SystemColors.GrayText;//changes font color
                confirmPasswordTextBox.PasswordChar = '\0';//resets the password character to nothing
            }
        }

        private void confirmPasswordTextBox_Enter(object sender, EventArgs e)//when user enters the textbox
        {
            if (confirmPasswordTextBox.Text == "Confirm Password")
            {
                confirmPasswordTextBox.Text = "";//changes displayed text
                confirmPasswordTextBox.ForeColor = SystemColors.WindowText;//changes font color
                confirmPasswordTextBox.PasswordChar = '\0';//resets the password character to nothing
            }
        }

        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e)//when text in textbox is changed
        {
            confirmPasswordTextBox.ForeColor = SystemColors.WindowText;//changes font color
            confirmPasswordTextBox.PasswordChar = '*';//changes password charecter to a star so that the actual password text is not displayed
        }


        //This method runs when the user clicks the cancel button and will close the current form and return to the previous form.
        private void newUserCancelButton_Click(object sender, EventArgs e)
        {
            previousForm.Show();//makes the previous screen visible again
            this.Close();//closes current screen
        }

        //This method runs when the user clicks on the "X" to close the form and returns the user to the prevous form
        private void signUpFormClose_Closing(object sender, EventArgs e)
        {
            previousForm.Show();//makes the previous screen visible again
            //a form close call is not required as the form is already in the process of closing
        }

        //This method is activated when the user clicks the submit button for user creation
        private void newUserSubmitButton_Click(object sender, EventArgs e)
        {
            //if any field is blank then an error message is thrown to tell the user to fill in all fields
            //if the fields ar filled in, the user will be saved and a message will display verifying user creation
            if (newFNameTextBox.Text != "First Name" && newLNameTextBox.Text != "Last Name" && newEAddressTextBox.Text != "Email Address" && newPasswordTextBox.Text != "Password" && confirmPasswordTextBox.Text != "Confirm Password" && confirmPasswordTextBox.Text == newPasswordTextBox.Text)
            {
                MessageBox.Show("Account Creation Successful");//displays confirmation message to user
                previousForm.Show();//makes the previous screen visible again
                this.Close();//closes current screen
            }
            else
            {
                if(newPasswordTextBox.Text != confirmPasswordTextBox.Text && newPasswordTextBox.Text != "Password" && confirmPasswordTextBox.Text != "Confirm Password")
                {
                    MessageBox.Show("Passwords do not match");//shows message if populated passwords do not match
                }
                else
                {
                    MessageBox.Show("Please fill out all fields");//informs user to fill all fields
                }
            }
        }

        //static void FilePathImport(DataTable)
        //{
        //    dt_RepFirmFilePath.Columns.Add("ID", typeof(string));
        //    dt_RepFirmFilePath.Columns.Add("Name", typeof(string));
        //    dt_RepFirmFilePath.Columns.Add("FilePath", typeof(string));


        //    //Load File into DatatTable
        //    using (StreamReader inFile = new StreamReader(@"\\\\stl-sql\\CustomC#\\Sales Reports\\custPriceSheet-Mass\\File Path Lookup.csv"))
        //    {
        //        //reads entire txt file
        //        string wholeFile = inFile.ReadToEnd();

        //        //breaks file into each distinct row (This will add a blank row for each row since it is looking at returns and new lines)
        //        string[] fileRows = wholeFile.Split("\r\n".ToArray());

        //        //This loop add the data to the datatable while ignoring any empty or blank lines.
        //        foreach (string r in fileRows)
        //        {
        //            if (r != "")
        //            {
        //                string[] fileRowFields = r.Split("|".ToCharArray());
        //                dt_RepFirmFilePath.Rows.Add(fileRowFields);
        //            }
        //        }
        //    }
        //}
    }
}
