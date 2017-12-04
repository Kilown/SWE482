using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Shopping_Assistant.Properties;
using Microsoft.VisualBasic;

namespace Shopping_Assistant
{
    public partial class ShoppingListScreen : Form
    {
        Form previousForm;//variable used to store the previous form so that it can be returned to
        static DataTable dt_ProductData = new DataTable();//creates a new datatable to store the imported product information
        static DataTable dt_SelectedProductData = new DataTable();//creates a new datatable to hold the product info for only selected products
        string userID = "";//creates a variable that will be used to store the user's ID

        //this is the constructor for the Shopping List Screen
        public ShoppingListScreen(Form parentForm, string usersID)
        {
            userID = usersID.ToString();//populeates the userID variable with the user's ID

            if (dt_ProductData.Columns.Count == 0)
            {
                //the following lines add new columns to the product datatable so that the info data can be imported
                dt_ProductData.Columns.Add("ProductSKU", typeof(string));
                dt_ProductData.Columns.Add("Isle", typeof(int));
                dt_ProductData.Columns.Add("Row", typeof(int));
                dt_ProductData.Columns.Add("Section", typeof(int));
                dt_ProductData.Columns.Add("Name", typeof(string));
                dt_ProductData.Columns.Add("Price", typeof(decimal));
                dt_ProductData.Columns.Add("Quantity", typeof(int));
                dt_ProductData.Columns.Add("IDInCategory", typeof(int));
                dt_ProductData.Columns.Add("CategoryName", typeof(string));
            }

            if (dt_SelectedProductData.Columns.Count == 0)
            {
                dt_SelectedProductData = dt_ProductData.Clone();//makes the selected product data table a clone of the product datatable so that it has the same available columns
                dt_SelectedProductData.Columns.Remove("ProductSKU");//removes the column from the datatable
                dt_SelectedProductData.Columns.Remove("IDInCategory");//removes the column from the datatable
                dt_SelectedProductData.Columns["Name"].SetOrdinal(0);//changes the order of the column
            }


            previousForm = parentForm;//sets the previousForm variable to the form that caused this form to open
            InitializeComponent();//renders the form

            foreach (var file in System.IO.Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Saved Shopping Lists\\" + userID.ToString()))//this loops through each file in the user's saved shopping list directory
            { 
                loadListComboBox.Items.Add(file.Replace(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Saved Shopping Lists\\" + userID.ToString() + "\\", "").Replace(".csv", ""));//this adds the file name to the load shopping list combo box while also removing filepathing and file type designator
            }

            if (dt_ProductData.Rows.Count == 0)
            {
                ImportProductData(dt_ProductData, Shopping_Assistant.Properties.Resources.Item_Pricelist_Data);//runs the Import Data method
            }
            dt_ProductData.DefaultView.Sort = ("Name ASC");
            productSelectionCheckedList.DataSource = dt_ProductData;
            productSelectionCheckedList.ValueMember = "ProductSKU";
            productSelectionCheckedList.DisplayMember = "Name";
        }

        private void backButton_Click(object sender, EventArgs e)//when the Back button is clicked
        {
            previousForm.Show();//makes previous form visible
            this.Close();//closes this form
            this.Dispose();
            GC.Collect();
        }

        private void ShoppingListScreen_Close(object sender, EventArgs e)
        {
            previousForm.Show();//makes previous form visible
            this.Dispose();
            GC.Collect();
            //a close form call is not needed here as the form is alread closing
        }

        static void ImportProductData(DataTable dataTable, string fileData)//this method is used to import data from a csv file and place it into a datatable object
        {
            //Load File into DatatTable
            //reads entire txt file
            string wholeFile = fileData;

            //breaks file into each distinct row (This will add a blank row for each row since it is looking at returns and new lines)
            string[] fileRows = wholeFile.Split("\r\n".ToArray());

            //This loop add the data to the datatable while ignoring any empty or blank lines.
            foreach (string r in fileRows)
            {
                if (r != "")
                {
                    string[] fileRowFields = r.Split(",".ToCharArray());//splits the string into multiple fields
                    dataTable.Rows.Add(fileRowFields);//adds the new fields to a datatable
                }
            }
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


        public void Product_Selected(object sender, EventArgs e)//when items are checked within the item list
        {
            //this new action waits untill after the check status has changed rather than prior to the change if this was not used
            this.BeginInvoke(new Action(() =>
            {
                List<string> selectedProductsList = new List<string>();//creats a list of all checked items
                foreach (object checkedItem in productSelectionCheckedList.CheckedItems)//for each checked item
                {
                    DataRowView castedItem = checkedItem as DataRowView;//retrieves value of checked item
                    selectedProductsList.Add(castedItem["ProductSKU"].ToString());//adds the value into the list of checked items
                }

                dt_SelectedProductData.Clear();//empties the datatable so it is ready for new data

                if (selectedProductsList.Count > 0)//if the selected list count is greater than zero
                {
                    foreach (var item in selectedProductsList)//for each item in the seleced product list
                    {
                        string itemSKU = item.ToString();//sets the items ID or SKU to a variable object to be utilized

                        //this searches through the main product data datatable to return only rows that match the selecte list items
                        var filteredData = from datatable in dt_ProductData.AsEnumerable()
                                           where datatable.Field<string>("ProductSKU") == itemSKU.ToString()
                                           select new
                                           {
                                               Name = datatable.Field<string>("Name"),
                                               Isle = datatable.Field<int>("Isle"),
                                               Row = datatable.Field<int>("Row"),
                                               Section = datatable.Field<int>("Section"),
                                               Price = datatable.Field<decimal>("Price"),
                                               Quantity = datatable.Field<int>("Quantity"),
                                               CategoryName = datatable.Field<string>("CategoryName")
                                           };

                        foreach (var row in filteredData)//for each item/row within the newly sorted data
                        {
                            dt_SelectedProductData.Rows.Add(row.Name, row.Isle, row.Row, row.Section, row.Price, row.Quantity, row.CategoryName);//adds each filtered row into the selected products datatable
                        }
                    }

                    productListDataGridView.DataSource = dt_SelectedProductData;//sets the selected products datagrid objects datasource to the newly generated datatable to display

                }
            }));
        }

        private void saveButton_Click(object sender, EventArgs e)//when the "Save" button is clicked
        {
            DataTable dt_shoppingListItems = new DataTable();//creates a datatable to store each selected product
            dt_shoppingListItems.Columns.Add("ProductSKU");//adds a column to the new datatable
            foreach (object checkedItem in productSelectionCheckedList.CheckedItems)//for each checked item
            {
                DataRowView castedItem = checkedItem as DataRowView;//retrieves value of checked item
                dt_shoppingListItems.Rows.Add(castedItem["ProductSKU"].ToString());//adds the value into the Datatable of checked items
            }

            string listName =  Microsoft.VisualBasic.Interaction.InputBox("Input a Shopping List Name:","Save List").Replace("/","").ToString();// prompts the user to enter a name for the saved shopping list
            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Saved Shopping Lists\\" + userID.ToString() + "\\" + listName.ToString() + ".csv";//generates a filepath/file name that the shopping list will be saved to

            if (dt_shoppingListItems.Rows.Count > 0)//checks to see if there are any selected items
            {
                Directory.CreateDirectory(filePath.Replace("\\" + listName.ToString() + ".csv",""));//creates the directory if it does not exist
                WriteDataToFile(dt_shoppingListItems,filePath.ToString());//saves the generated shopping list to a new text file for retrieval

                //re-populates the load lists combo box to include the new file
                foreach (var file in System.IO.Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Saved Shopping Lists\\" + userID.ToString()))//this loops through each file in the user's saved shopping list directory
                {
                    loadListComboBox.Items.Add(file.Replace(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Saved Shopping Lists\\" + userID.ToString() + "\\", "").Replace(".csv", ""));//this adds the file name to the load shopping list combo box while also removing filepathing and file type designator
                }
            }
            else
            {
                MessageBox.Show("No items are selected","No Checked Items", MessageBoxButtons.OK, MessageBoxIcon.Error);//displays message to user indicating that no items are selected
            }
        }

        private void loadButton_Click(object sender, EventArgs e)//when the "Load" button is clicked
        {
            DataTable dt_savedListItems = new DataTable();//creates a datatable to hold the saved list item ID's

            dt_savedListItems.Columns.Add("ProductSKU");//adds a column to the newly created datatable

            if (loadListComboBox.Text != null || loadListComboBox.Text != "")//if the combobox has a value selected
            {
                string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Saved Shopping Lists\\" + userID.ToString() + "\\" + loadListComboBox.Text.ToString() + ".csv";//sets the filepath for the selected shopping list

                ImportData(dt_savedListItems,filePath);//populates a datatable from a designated file

                foreach (int item in productSelectionCheckedList.CheckedIndices)//loops through any checked items in the product list box
                {
                    productSelectionCheckedList.SetItemCheckState(item, CheckState.Unchecked);//unchecks each checked/selected product
                }
                
                foreach (DataRow row in dt_savedListItems.Rows)//loops through the item ids from the saved list
                {
                    for (int i = 0; i < productSelectionCheckedList.Items.Count; i++)//loops throught the items in the product selection list
                    {
                        DataRowView listItem = productSelectionCheckedList.Items[i] as DataRowView;//lets the values from each list item be visible to the program as a datarow
                        string itemSKU = listItem["ProductSKU"].ToString();//populates a string variable to hold the list item ID
                        if (row["ProductSKU"].ToString() == itemSKU.ToString())//checks to see if the saved item ID matches the list item ID
                        {
                            productSelectionCheckedList.SetItemCheckState(i,CheckState.Checked);//checks the matching item within the product selection list box
                            break;//breaks the loop to prevent unneccisary iterations
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Shopping List is Selected", "Select Shopping List", MessageBoxButtons.OK, MessageBoxIcon.Error);//displays an error message to the user if no list has been selected
            }
        }
    }
}
