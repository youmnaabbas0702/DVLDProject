using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp
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

            clsLogger.CreateEventLogSource();
            clsLogger.LogInfo("Test");

            while (true)
            {
                using (frmLogin login = new frmLogin())
                {
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new frmMainScreen());
                    }
                    else
                    {
                        break; // user closed login or canceled
                    }
                }
            }

        }
    }
}
