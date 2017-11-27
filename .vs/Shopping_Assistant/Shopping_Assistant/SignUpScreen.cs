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

        static DataTable dt_UserData = new DataTable();//creates a new datatable to hold the imported user data

        static string userDataFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\non-embedded text files\\Test_User_List.csv";//sets reletive filepath for the user data file

        //The following Method is the contructor for the Sign up screen
        public SignUpScreen(Form parentForm)
        {
            if (dt_UserData.Columns.Count == 0)//when there are no columns in the datatable
            {
                dt_UserData.Columns.Add("UserID", typeof(string));//adds a new column
                dt_UserData.Columns.Add("FirstName", typeof(string));//adds a new column
                dt_UserData.Columns.Add("LastName", typeof(string));//adds a new column
                dt_UserData.Columns.Add("EmailAddress", typeof(string));//adds a new column
                dt_UserData.Columns.Add("Password", typeof(string));//adds a new column
            }

            //sets a variable to equil the LogonForm
            previousForm = parentForm;

            if (dt_UserData.Rows.Count == 0)
            {
                ImportData(dt_UserData, userDataFilePath);//runs the import data method to populate the user data into a datatable object
            }

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
                if (checkEmail(newEAddressTextBox.Text) == false)
                {
                    dt_UserData.Rows.Add((dt_UserData.Rows.Count + 1).ToString(), newFNameTextBox.Text.ToString(), newLNameTextBox.Text.ToString(), newEAddressTextBox.Text.ToString(), newPasswordTextBox.Text.ToString());// This line adds a new row to the user datatable so that login processes can take place
                    WriteDataToFile(dt_UserData, userDataFilePath);//this calls the write data method to overwrite the text file containing the user data
                    MessageBox.Show("Account Creation Successful");//displays confirmation message to user
                    previousForm.Show();//makes the previous screen visible again
                    this.Close();//closes current screen
                }
                else
                {
                    MessageBox.Show("Email address is already in use","Email Address Field",MessageBoxButtons.OK, MessageBoxIcon.Error);//notifies the user that the email address is already utilized
                }
            }
            else
            {
                if(newPasswordTextBox.Text != confirmPasswordTextBox.Text && newPasswordTextBox.Text != "Password" && confirmPasswordTextBox.Text != "Confirm Password")
                {
                    MessageBox.Show("Passwords do not match", "Mismatched Passwords", MessageBoxButtons.OK, MessageBoxIcon.Error);//shows message if populated passwords do not match
                }
                else
                {
                    MessageBox.Show("Please fill out all fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);//informs user to fill all fields
                }
            }
        }

        //This method is utilized to check to see it the email address is already in use
        private bool checkEmail(string emailAddress)
        {
            bool doesMatch = false;//boolean variable to determine email match

            for(var r = 0; r < dt_UserData.Rows.Count; r++)//loops through each row in the user data
            {
                if(dt_UserData.Rows[r]["EmailAddress"].ToString() == emailAddress)//checks to find a matching email address
                {
                    doesMatch = true;// changes match varible to true
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

        //This method writes a datatable to a text file
        public static void WriteDataToFile(System.Data.DataTable submittedDataTable, string submittedFilePath)
        {
            int i = 0;//resets counter to zero
            StreamWriter sw = null;//resets stearmwriter to nothing

            sw = new StreamWriter(submittedFilePath, false);//creats a streamwriter utilizing the provided destination path

            foreach (DataRow row in submittedDataTable.Rows)//for each row within the provided datatable
            {

                object[] array = row.ItemArray;// creates a new object array to store row fields

                for (i = 0; i < array.Length - 1; i++)//for each field
                {
                    sw.Write(array[i].ToString() + ",");//creates a new string with the field value and a comma delimmiter
                }
                sw.Write(array[i].ToString());//writes the row to the text file
                sw.WriteLine();//iterates to the next line

            }

            sw.Close();//closes the streamwriter object
        }
    }
}
