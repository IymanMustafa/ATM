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
            var connectionString = @"Server=.\localhost;Database=myDataBase;Trusted_Connection=True;";
            var dbConn = new SqlConnection(connectionString);
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
