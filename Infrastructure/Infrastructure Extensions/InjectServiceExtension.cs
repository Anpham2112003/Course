﻿using Infrastructure.DB.SQLDbContext;
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
                optionsAction.UseSqlServer("");
            });


            return service;
        }
    }
}
