using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WorkUtiliteRmastered
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Properties.Settings.Default.Reset();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.firstRun)
            {
                firstRun f = new firstRun();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    settingsForm s = new settingsForm();
                    if (s.ShowDialog() == DialogResult.OK)
                    {
                        Properties.Settings.Default.firstRun = false;
                        Properties.Settings.Default.Save();
                        Application.Run(new generalForm());
                    }
                    else {
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Run(new generalForm());
            }
        }
    }
}
