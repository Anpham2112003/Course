using Domain.Options;

namespace Api.Extensions
{
    public static class OptionExtension
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOption>(configuration.GetSection(JwtOption.Jwt));

            services.Configure<MailOption>(configuration.GetSection(MailOption.Mail));

            services.Configure<CloudinaryOption>(configuration.GetSection(CloudinaryOption.Cloudinary));

            return services;
        }
    }
}
