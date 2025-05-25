using System;
using System.Windows.Forms;

namespace SimpleWindowsForm
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
            
            // Önce login formunu göster
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login başarılı ise ana formu aç
                    var mainForm = new Form1(loginForm.LoggedInUser);
                    Application.Run(mainForm);
                }
                // Login başarısız ise uygulama kapanır
            }
        }
    }
} 