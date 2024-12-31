using System.Configuration;
using Api.Extensions;
using Api.RestApi;
using Application.Maper;
using Application.MediaR.Comands.Account;
using Application.MediaR.Pipeline;
using Application.ValidationRules;
using CloudinaryDotNet;
using Domain.Options;
using dotenv.net;
using FluentValidation;
using HotChocolate;
using HotChocolate.Execution;
using Infrastructure;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.SeedData;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using Api.Schemas.Query;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Stripe;
using Api.DataLoader;
using Api.Graphql.Query;
using Domain.Schemas;
using Api.Projection;
using Autofac;
using Hangfire;
using Hangfire.SqlServer;
using Infrastructure.Services.MailService;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Domain.Interfaces.Mailer;
using Hangfire.Common;
using Infrastructure.Services.BackgroundService;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InfrastructureInjectServices(builder.Configuration);

builder
    .Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder
                .WithOrigins("https://studio.apollographql.com","http://studio.apollographql.com", "http://localhost:4200", "https://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

//builder.Services.AddSingleton(cg => new RequestExecutorProxy(cg.GetRequiredService<IRequestExecutorResolver>(), Schema.DefaultName));


builder.Services.AddOptions(builder.Configuration);


builder.Services.AddMediatR(config =>
{
    
    config.RegisterServicesFromAssembly(typeof(CreateAccountRequest).Assembly);

    config.AddOpenBehavior(typeof(ValidationPipeline<,>));

    config.NotificationPublisher = new TaskWhenAllPublisher();

    config.NotificationPublisherType=typeof(TaskWhenAllPublisher);
});



builder.Services.AddAutoMapper(typeof(MapData).Assembly,typeof(MapperProjection).Assembly);


builder.Services.AddValidatorsFromAssembly(typeof(LoginAccountValidation).Assembly);


builder.Services.AddHttpContextAccessor();

var jwt = builder.Configuration.GetSection(Domain.Options.JwtOption.Jwt).Get<JwtOption>();

var google = builder.Configuration.GetSection(GoogleOption.Google).Get<GoogleOption>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(op =>
    {
        op.Cookie.SameSite = SameSiteMode.None;
    })
    .AddGoogle(config =>
    {
        config.ClientId = google.Client_id!;
        config.ClientSecret = google.Client_secret!;
        config.CallbackPath = PathString.FromUriComponent(new Uri(google.Callback_path!));
        config.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(config =>
    {
        config.IncludeErrorDetails = true;

        config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateLifetime = false,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Accesskey!))

        };

        config.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    (path.StartsWithSegments("/Chat")))
                {
                    // Read the token out of the query string
                    context.Token = accessToken;
                }

                return Task.CompletedTask;
            }
        };
    });


builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("Hangfire"),new SqlServerStorageOptions()
    {
        TryAutoDetectSchemaDependentOptions = false,
        SqlClientFactory = Microsoft.Data.SqlClient.SqlClientFactory.Instance,
        
    });
    x.UseRecommendedSerializerSettings();
    
});

builder.Services.AddHangfireServer(op =>
{
    op.WorkerThreadConfigurationAction = (worker) =>
    {
        worker.IsBackground = true;
        worker.Name = "Background Thread!";
        Console.WriteLine("Background Thread running...!"+worker.ManagedThreadId);
    };
    
    op.WorkerCount = 4;

  
});





builder.Services

    .AddGraphQLServer()
    .AddSorting()
    .AddFiltering()
    .AddType<PublicUser>()
    .AddType<PrivateUser>()
    .AddType<Course>()
    .AddType<FeedBack>()
    .AddType<Cart>()
    .AddType<Purchase>()
    .AddType<Tag>()
    .AddType<Topic>()
    .AddType<CategoryLesson>()
    .AddType<PrivateLesson>()
    .AddType<PublicLesson>()
    .AddDataLoader<GetPublicUserDataLoader>()
    .AddDataLoader<GetCourseDataLoader>()
    .AddDataLoader<GetFeedBackDataLoader>()
    .AddDataLoader<GetPurchaseDataLoader>()
    .AddDataLoader<GetTagDataLoader>()
    .AddDataLoader<GetTopicDataLoader>()
    .AddDataLoader<GetCategoryLessonDataLoader>()
    .AddDataLoader<GetLessonDataLoader>()

    .AddGraphExtension()
    .AddAuthorization()
    .AddErrorFilter(error =>
    {
    if (error.Exception is ValidationException ex)
    {
        var jsonError = JsonSerializer.Serialize(ex.Errors);

            var errorBuilder = ErrorBuilder.New()
            .SetCode("BAD_REQUEST")
            .SetMessage(jsonError)
            .Build();

            return errorBuilder;
        }

        return error;
    });

builder.Services.AddSignalR();





var app = builder.Build();

app.AddRestApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    using (var scopeService = app.Services.CreateScope())
    {
        var service = scopeService.ServiceProvider.GetRequiredService<ApplicationDBContext>();

        var seed = new Seed(service);

        seed.RunSeed();

        seed.SeedPermission();

        seed.SeedTag();

        var recurringJob = scopeService.ServiceProvider.GetRequiredService<IRecurringJobManager>();

        //recurringJob.AddOrUpdate("addTagNew", Job.FromExpression<IBackgroundJob>(x=>x.AddTagNewToCourse()), Cron.Minutely());

        //recurringJob.AddOrUpdate("addTagBestSell", Job.FromExpression<IBackgroundJob>(x => x.AddTagBestSellToCourse()), Cron.Minutely());

    }


}






app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapGraphQL();




app.UseHangfireDashboard("/hangfire");


app.RunWithGraphQLCommands(args);

public partial class Program { }
