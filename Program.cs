using System;
using System.IO;
using Unity;

namespace BEIS
{
    class Program
    {
        static void Main(string[] args)
        {
            AppConfiguration();

            var app = UnityConfig.Container.Resolve<IApplication>();

            app.FileExist("product.csv");
            app.Load();
            app.ValidateProducts();
            app.DisplayProduct();

            ExitConsole();
        }

        private static void AppConfiguration()
        {
           AppDomain.CurrentDomain.UnhandledException += UnhandledException;
           UnityConfig.RegisterTypes();
        }

        #region Generic exception handler
        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
           
            ExitConsole();
        }

        static void ExitConsole()
        {
            Console.WriteLine("\n Press Enter to continue");
            Console.ReadLine();

            Environment.Exit(1);
        }
        #endregion
    }
}
