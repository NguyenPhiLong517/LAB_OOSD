using System;
using System.Windows.Forms;

namespace eShoppingApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi chạy frmMain từ namespace Forms
            Application.Run(new eShopping.Forms.frmMain());
        }
    }
}