using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Data.Common;
using System.Data.SqlClient;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
