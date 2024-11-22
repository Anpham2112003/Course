using Domain.Interfaces.Mailer;
using Domain.Interfaces.Upload;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Services.MailService;
using Infrastructure.Services.Upload;
using MailKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Payment;
using Infrastructure.Services.PaymentService;
using Infrastructure.Unit0fWork;

namespace Infrastructure
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

            service.AddScoped<IMailerService, MailerService>();

            service.AddScoped<ICloudinaryUploadService, CloudinaryUploadService>();

            service.AddScoped<IStripService, StripeService>();

            return service;
        }
    }
}
