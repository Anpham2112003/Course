using Domain.Options;

namespace Api.Extension
{
    public static class  OptionExtension
    {
        public static IServiceCollection AddOptions(this IServiceCollection services,IConfiguration configuration )
        {
            services.Configure<JwtOption>(configuration.GetSection(JwtOption.Jwt));

            services.Configure<MailOption>(configuration.GetSection(MailOption.Mail));

            return services;
        }
    }
}
