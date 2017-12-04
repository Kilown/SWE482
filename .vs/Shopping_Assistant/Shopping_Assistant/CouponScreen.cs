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
    public partial class CouponScreen : Form
    {
        Form previousForm;//variable used to store the previous form
        string userID = "";//creates a string variable to store the user's ID
        DataTable dt_savedCoupons = new DataTable();//creates a new datatable to store the saved coupon data
        string filePath = "";//creates a variable that will be used to store the filepath to the user's saved coupon data
        //this method is the consructor for the Coupons screen
        public CouponScreen(Form parentForm,string usersID)
        {
            if (dt_savedCoupons.Columns.Count == 0)//if there are not columns aleady in the datatable
            {
                dt_savedCoupons.Columns.Add("Coupon Code",typeof(string));//adds a new column to the datatable
                dt_savedCoupons.Columns.Add("Product",typeof(string));//adds a new column to the datatable
                dt_savedCoupons.Columns.Add("Discount",typeof(string));//adds a new column to the datatable
                dt_savedCoupons.Columns.Add("Expiration Date",typeof(string));//adds a new column to the datatable
            }

            dt_savedCoupons.Clear();//clears datable to ensure that it is empty

            userID = usersID.ToString();//populates the userID variable with the user's ID

            filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\non-embedded text files\\Saved Coupons\\" + userID.ToString() + "\\usersSavedCoupons.csv";//sets the filepath for the selected shopping list

            if (File.Exists(filePath))//checks to see if the saved coupons file exists
            {
                if(dt_savedCoupons.Rows.Count == 0)
                {
                    ImportData(dt_savedCoupons, filePath);//imports the data from the file into a datatable
                }
            }
            else
            {
                Directory.CreateDirectory(filePath.Replace("\\usersSavedCoupons.csv", "").ToString());//creates a directory to store any saved coupons
            }

            previousForm = parentForm;//sets the previousForm variable to equal the last screen

            InitializeComponent();//renders the Events screen

            savedCouponsDataGridView.DataSource = dt_savedCoupons;
            savedCouponsDataGridView.Refresh();

        }

        private void backButton_Click(object sender, EventArgs e)//when the Back button is clicked
        {
            previousForm.Show();//makes the previous form visible again
            this.Close();//closes this form
        }

        private void CouponScreen_Close(object sender, EventArgs e)//when the form is closing via the "X" button
        {
            previousForm.Show();//makes the previous form visible again
            //a close form call is not needed here as the form is already closing
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

        public static void WriteDataToFile(System.Data.DataTable submittedDataTable, string submittedFilePath)//this method is utilized to create text files for saving data
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

        private void saveButton_Click(object sender, EventArgs e)//when the "Save" button is clicked
        {
            if (couponCodeTextBox.Text != "" && productNameTextBox.Text != "" && discountTextBox.Text != "" && experationDateTimePicker.Value != null)
            {
                dt_savedCoupons.Rows.Add(couponCodeTextBox.Text.ToString(),productNameTextBox.Text.ToString(),discountTextBox.Text.ToString(),experationDateTimePicker.Value.ToShortDateString());//checks to ensure all fields are filled in
                dt_savedCoupons.DefaultView.Sort = "Product ASC";// sorts the datatable in acending order by the product's name
                WriteDataToFile(dt_savedCoupons,filePath);//overwrites the saved coupons file to include the new coupon
                savedCouponsDataGridView.Refresh();//refreshes the datagrid to show the added coupon
            }
            else
            {
                MessageBox.Show("One or more fields are not populated.\nPlease fill in all fields.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);//displays a message to the user stating that one or more fields are missing
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)// when the "Delete Selected Coupons" is clicked
        {
            DataTable tempSavedCoupons = dt_savedCoupons.Copy();//clones the datatable

            if(savedCouponsDataGridView.SelectedRows.Count > 0)//checkes to see if rows are selected
            {
                for (int row = 0; row < savedCouponsDataGridView.Rows.Count; row++)// for each item in the saved coupons view
                {
                    if (savedCouponsDataGridView.Rows[row].Selected && savedCouponsDataGridView.Rows[row].Cells["Coupon Code"].Value != null)// if the row is selected andif the coupon code is not null
                    {                   
                        for (int row1 = 0; row1 < tempSavedCoupons.Rows.Count; row1++)//for each item within the savedCoupons datatable
                        {
                            if (tempSavedCoupons.Rows[row1]["Coupon Code"].ToString() == savedCouponsDataGridView.Rows[row].Cells["Coupon Code"].Value.ToString() && savedCouponsDataGridView.Rows[row].Cells["Coupon Code"].Value != null)// if the selected code equals an item in the datatable
                            {
                                tempSavedCoupons.Rows[row1].Delete();//deletes the row within the datatable
                                break;//breaks the loop to prevent extra interations
                            }
                        }
                    }
                }
                dt_savedCoupons.Clear();//empties the datatable of all data
                dt_savedCoupons = tempSavedCoupons.Copy();//copies temp data table into the saved coupons datatable
                tempSavedCoupons.Clear();//clears the temp datatable
                WriteDataToFile(dt_savedCoupons, filePath);//writes the updateddata to the text file
                dt_savedCoupons.Clear();//clears out the saved coupons datatable to be repopulated
                ImportData(dt_savedCoupons, filePath);//imports the data from the file into a datatable
                savedCouponsDataGridView.DataSource = dt_savedCoupons;//re-assigns the datagrids datasource so that the fresh data populates
            }
            else
            {
                MessageBox.Show("No Rows have been selected.", "No Rows Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);//displays a message to the user sating that no rows are selected
            }
        }
    }
}
