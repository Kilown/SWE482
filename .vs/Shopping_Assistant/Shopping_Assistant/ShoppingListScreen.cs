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

namespace Shopping_Assistant
{
    public partial class ShoppingListScreen : Form
    {
        Form previousForm;//variable used to store the previous form so that it can be returned to
        static DataTable dt_ProductData = new DataTable();//creates a new datatable to store the imported product information
        static DataTable dt_SelectedProductData = new DataTable();//creates a new datatable to hold the product info for only selected products

        //this is the constructor for the Shopping List Screen
        public ShoppingListScreen(Form parentForm)
        {
            //the following lines add new columns to the product datatable so that the info data can be imported

            if (dt_ProductData.Columns.Count == 0)
            {
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
            ImportData(dt_ProductData, Shopping_Assistant.Properties.Resources.Item_Pricelist_Data);//runs the Import Data method
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

        static void ImportData(DataTable dataTable, string fileData)//this method is used to import data from a csv file and place it into a datatable object
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
        
        //currently not utilized will be implemented when saving shopping lists module is created
        //public static void WriteDataToFile(System.Data.DataTable submittedDataTable, string submittedFilePath)
        //{
        //    int i = 0;//resets counter to zero
        //    StreamWriter sw = null;//resets stearmwriter to nothing

        //    sw = new StreamWriter(submittedFilePath, false);//creats a streamwriter utilizing the provided destination path

        //    foreach (DataRow row in submittedDataTable.Rows)//for each row within the provided datatable
        //    {

        //        object[] array = row.ItemArray;// creates a new object array to store row fields

        //        for (i = 0; i < array.Length - 1; i++)//for each field
        //        {
        //            sw.Write(array[i].ToString() + ",");//creates a new string with the field value and a comma delimmiter
        //        }
        //        sw.Write(array[i].ToString());//writes the row to the text file
        //        sw.WriteLine();//iterates to the next line

        //    }

        //    sw.Close();//closes the streamwriter object
        //}


        public void Product_Selected(object sender, EventArgs e)//when items are checked within the item list
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
                foreach(var item in selectedProductsList)//for each item in the seleced product list
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

                    foreach(var row in filteredData)//for each item/row within the newly sorted data
                    {
                        dt_SelectedProductData.Rows.Add(row.Name, row.Isle, row.Row, row.Section, row.Price, row.Quantity, row.CategoryName);//adds each filtered row into the selected products datatable
                    }
                }

                productListDataGridView.DataSource = dt_SelectedProductData;//sets the selected products datagrid objects datasource to the newly generated datatable to display

            }
        }
    }
}
