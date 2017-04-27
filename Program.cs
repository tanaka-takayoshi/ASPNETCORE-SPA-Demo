using System;
using System.IO;
using ASPNETCore.SPADemo.Models;
using Microsoft.AspNetCore.Hosting;

namespace ASPNETCore.SPADemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
