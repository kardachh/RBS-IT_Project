using RBS_IT_Project.Forms;
using System;
using System.Windows.Forms;

namespace RBS_IT_Project
{
    static class Program
    {
        public static Entities2 RBS_Project = new Entities2();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAuthorization());
        }
    }
}
