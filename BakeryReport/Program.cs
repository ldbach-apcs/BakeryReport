using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BakeryReport
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

            Form formMaster = new FormMaster();
            formMaster.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(formMaster);
        }
    }
}
