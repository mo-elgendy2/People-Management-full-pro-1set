using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_Management__full_pro__1set
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new manage_User());
            //using (LoginForm login = new LoginForm())
            //{
            //    if (login.ShowDialog() == DialogResult.OK) 
            //    {

            //        Application.Run(new Form1 ());
            //    }
            //    else
            //    {

            //        Application.Exit();
            //    }
            //}
        }
    }
    }

