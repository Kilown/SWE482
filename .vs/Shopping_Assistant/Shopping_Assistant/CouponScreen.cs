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
    public partial class CouponScreen : Form
    {
        Form previousForm;//variable used to store the previous form

        //this method is the consructor for the Coupons screen
        public CouponScreen(Form parentForm)
        {
            previousForm = parentForm;//sets the previousForm variable to equal the last screen
            InitializeComponent();//renders the Events screen
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
    }
}
