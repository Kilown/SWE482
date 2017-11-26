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
    public partial class LocationSelectionScreen : Form
    {
        Form previousForm;//variable used to store the previous for so that it can be returned to

        //this method is the constructor for the Locations screen
        public LocationSelectionScreen(Form parentForm)
        {
            previousForm = parentForm;//sets the previousForm variable to equal the last screen
            InitializeComponent();//renders the Locations screen
        }

        private void backButton_Click(object sender, EventArgs e)//when the Back button is clicked
        {
            previousForm.Show();//makes the previous screen visible again
            this.Close();//closes this form
        }

        private void LocationScreen_Close(object sender, EventArgs e)//when the screen is closing via the "X" button
        {
            previousForm.Show();//makes the previous screen visible again
            //a close form call is not needed here as the form is already closing
        }
    }
}
