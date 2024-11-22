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
                .WithOrigins("https://studio.apollographql.com","http://studio.apollographql.com")
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



builder.Services.AddAutoMapper(typeof(MapData).Assembly);


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
    });
    



builder.Services
    
    .AddGraphQLServer()
    .AddApolloFederation()
    .AddSorting()
    .AddFiltering()
    .AddType<User>()
    .AddType<Course>()
    .AddType<FeedBack>()
    .AddType<Cart>()
    .AddType<Purchase>()
    .AddType<Tag>()
    .AddType<Topic>()
    .AddDataLoader<GetUserDataLoader>()
    .AddDataLoader<GetCourseDataLoader>()
    .AddDataLoader<GetFeedBackDataLoader>()
    .AddDataLoader<GetPurchaseDataLoader>()
    .AddDataLoader<GetTagDataLoader>()
    .AddDataLoader<GetTopicDataLoader>()
    .AddGraphExtension()
    .AddAuthorization();







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
    }

  

}


app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapGraphQL();





app.RunWithGraphQLCommands(args);

public partial class Program { }
