using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_ltwin
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
            //Application.Run(new Form1());
            //Form1 flogin = new Form1();
            //MenuForm menu = new MenuForm();
            //if (flogin.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new MenuForm());
            //}
            //else
            //{
            //    Application.Exit();//thoat khoi chuong trinh
            //}
            Application.Run(new Form1());
        }
    }
}
