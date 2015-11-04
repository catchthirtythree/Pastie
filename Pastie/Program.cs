using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Pastie
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
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version
                                           .ToString());
            PastieForm pastie = new PastieForm();
            Application.Run();
        }
    }
}