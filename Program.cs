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
                    // Login başarılı ise ana menü formunu aç
                    var mainMenuForm = new MainMenuForm(loginForm.LoggedInUser);
                    Application.Run(mainMenuForm);
                }
                // Login başarısız ise uygulama kapanır
            }
        }
    }
} 