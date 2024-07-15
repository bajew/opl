using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using Opl.Abstractions;
using Opl.Business;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Opl.Wpf
{
    public class Services
    {
        private ServiceCollection services = new ServiceCollection();

        public Services()
        {
            Configure();
        }
        public void Configure()
        {
            services.AddWpfBlazorWebView();
            services.AddRadzenComponents();
            services.AddTransient<HttpClient>();
            services.AddMemoryCache();

            services.AddSingleton<LiteDatabase>(sp
                 =>
            {
                return new LiteDatabase(new ConnectionString("opl.db")
                {
                    Connection = ConnectionType.Shared
                });
            });

            services.AddSingleton<IOplRepository, OplRepository>();
            services.AddSingleton<IProjectsRepository, ProjectsRepository>();
        }

        public ServiceProvider BuildServiceProvider()
        {
            return services.BuildServiceProvider();
        }
    }
}
