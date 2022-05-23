using System.Windows.Forms;
using System;

namespace RightTriangles
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ApplicationConfiguration.Initialize();
            Application.Run(new InputForm());
        }
    }
}