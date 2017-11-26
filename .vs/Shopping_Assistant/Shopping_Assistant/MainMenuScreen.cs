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
    public partial class MainMenuScreen : Form
    {
        Form previousForm;//create a variable to hold the previous form

        //this method is the constructor for the Main Menu Screen
        public MainMenuScreen(Form parentForm)
        {
            previousForm = parentForm;//sets previousForm variable to equal the form that called this one
            InitializeComponent();//renders the Main Menu form
        }

        private void signOutButton_Click(object sender, EventArgs e)//when the Sign Out button is clicked
        {
            previousForm.Show();//makes the previous form visible again
            this.Close();//closes this form
        }

        private void mainMenuScreen_Close(object sender, EventArgs e)//when the "X" buttion is used to close the form
        {
            previousForm.Show();//makes the previous form visible again
            //a close form call is not needed here as the form is already closing
        }

        private void LocationButton_Click(object sender, EventArgs e)//when the Location buttion is clicked
        {
            Form LocationsScreen = new LocationSelectionScreen(this);//creates a new instance of the Locations screen
            LocationsScreen.Show();//displays the new Locations screen
            this.Hide();//Hides this form from view
        }

        private void eventsButton_Click(object sender, EventArgs e)//when the Sales Events button is clicked
        {
            Form EventsScreen = new EventsScreen(this);//creates a new instance of the Events screen
            EventsScreen.Show();//displays the new Events screen
            this.Hide();//Hides this form from view
        }

        private void couponButton_Click(object sender, EventArgs e)//when the Coupons button is clicked
        {
            Form CouponScreen = new CouponScreen(this);//creates a new instance of the Coupons screen
            CouponScreen.Show();//displays the new Coupons screen
            this.Hide();//Hides this form from view
        }

        private void groceryListButton_Click(object sender, EventArgs e)//when the Shopping Lists button is clicked
        {
            Form ShoppingListScreen = new ShoppingListScreen(this);//creates a new instance of the Shopping List screen
            ShoppingListScreen.Show();//displays the new Shopping List screen
            this.Hide();//Hides this form from view
        }
    }
}
