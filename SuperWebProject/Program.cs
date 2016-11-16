using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using netcoretalk.Startup;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var host = new WebHostBuilder()
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseKestrel()
                            .UseStartup<Startup>()
                            .UseUrls("http://127.0.0.1:6969")
                            .Build())
            {
                Console.WriteLine("Starting application on url : http://127.0.0.1:6969");

                host.Start();

                var appLifeTime = host.Services.GetRequiredService<IApplicationLifetime>();

                appLifeTime.ApplicationStopping.Register(() =>
                {
                    Console.WriteLine("Stopping application...");
                });

                Console.CancelKeyPress += (sender, e) =>
                {
                    appLifeTime.StopApplication();
                    e.Cancel = true;
                };

                appLifeTime.ApplicationStopping.WaitHandle.WaitOne();
            }
        }
    }
}
