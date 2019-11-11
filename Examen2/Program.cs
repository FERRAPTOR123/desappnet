using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Examen2.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Examen2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            
            var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var contex = services.GetService<Examen2CollectionContext>();

            DbInitializer.Initializate(contex);
            
            host.Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
