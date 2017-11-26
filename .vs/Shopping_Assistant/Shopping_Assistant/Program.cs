using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Assistant
{
    static class Program
    {
        /// The main entry point for the application. This is the first method that will run.
        [STAThread]
        static void Main()
        {
            //The following two lines enable the renderer to display the Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //The following Line starts the application and generates a LogonScreen instance
            Application.Run(new LogonScreen());
        }
    }
}
