using emanuel.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace emanuel
{
    static class Program
    {
        private const int AttachParentProcess = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TryAttachToParentConsole();

            Application.ThreadException += (s, e) =>
            {
                LogStartup("Unhandled Thread Exception", e.Exception);
                MessageBox.Show(e.Exception.ToString(), "Unhandled Thread Exception");
            };
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                LogStartup("Unhandled Exception", e.ExceptionObject);
                MessageBox.Show(e.ExceptionObject?.ToString(), "Unhandled Exception");
            };

            try
            {
                LogStartup("Starting textr application");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var services = new ServiceCollection();

                LogStartup("Building service provider");
                var serviceProvider = services
                    .ConfigureTextrServices()
                    .BuildServiceProvider();

                LogStartup("Resolving main form");
                var form = serviceProvider.GetRequiredService<Form>();

                LogStartup("Running main form");
                Application.Run(form);
            }
            catch (Exception ex)
            {
                LogStartup("Startup Exception", ex);
                MessageBox.Show(ex.ToString(), "Startup Exception");
            }
        }

        private static void TryAttachToParentConsole()
        {
            try
            {
                AttachConsole(AttachParentProcess);
            }
            catch
            {
            }
        }

        private static void LogStartup(string message, object payload = null)
        {
            var text = $"[{DateTimeOffset.Now:O}] {message}";

            if (payload != null)
            {
                text += Environment.NewLine + payload;
            }

            try
            {
                Console.Error.WriteLine(text);
            }
            catch
            {
            }

            try
            {
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startup-error.log"), text + Environment.NewLine);
            }
            catch
            {
            }
        }
    }
}
