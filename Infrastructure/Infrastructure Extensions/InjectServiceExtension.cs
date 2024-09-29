using Infrastructure.DB.SQLDbContext;
using Infrastructure.Services.UnitOfWorkService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Infrastructure_Extensions
{
    public static class InjectServiceExtension
    {
        public static IServiceCollection InfrastructureInjectServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDBContext>(optionsAction =>
            {
                var connection = configuration.GetConnectionString("SQL");

                optionsAction.UseSqlServer(connection!, op =>
                {
                    op.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName);
                });

            });


            service.AddScoped<IUnitOfWork, UnitOfWork>();



            return service;
        }
    }
}
