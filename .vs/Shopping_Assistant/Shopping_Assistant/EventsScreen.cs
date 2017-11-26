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
    public partial class EventsScreen : Form
    {
        Form previousForm;//variable used to store the previous screen

        //this method is the constructor for the SalesEvents screen
        public EventsScreen(Form parentForm)
        {
            previousForm = parentForm;//sets the previousForm variable to equal the last screen
            InitializeComponent();//renders the Events screen
        }

        private void backButton_Click(object sender, EventArgs e)//when the Back button is clicked
        {
            previousForm.Show();//makes the previous screen visible again
            this.Close();//closes this screen
        }
        
        private void EventScreen_Close(object sender, EventArgs e)//when the screen is closing via the "X" button
        {
            previousForm.Show();//makes the previous screen visible again
            //a close form call is not needed here as the screen is already closing
        }
    }
}
