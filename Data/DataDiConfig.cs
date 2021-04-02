using Data.Context;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public static class DataDiConfig
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            // new config
            // add dbContext
            services.AddDbContext<ProductContext>(op =>op.UseSqlServer(configuration.GetConnectionString("Default")));
            // add DI
            services.AddScoped<IDataContextAsync, ProductContext>();
        }
    }
}
