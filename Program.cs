using emanuel.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace emanuel
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

            var services = new ServiceCollection();

            var serviceProvider = services
                .ConfigureTextrServices()
                .BuildServiceProvider();

            var form = serviceProvider.GetRequiredService<Form>();

            Application.Run(form);
        }
    }
}
