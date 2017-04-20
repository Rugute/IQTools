using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;


namespace IQTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmLogin());
        }

        
        
    }
}