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
            
            services.Configure<GoogleOption>(configuration.GetSection(GoogleOption.Google));
            
            services.Configure<TiktokOption>(configuration.GetSection(TiktokOption.Tiktok));

            services.Configure<StripeOption>(configuration.GetSection(StripeOption.Stripe));

            return services;
        }
    }
}
