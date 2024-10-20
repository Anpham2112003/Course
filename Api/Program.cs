using Api.Extensions;
using Api.Middleware;
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


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InfrastructureInjectServices(builder.Configuration);



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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(config =>
    {
        config.IncludeErrorDetails=true;
       
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

builder.Services.AddAuthorization();


builder.Services
   .AddGraphQLServer()
   .AddAuthorization()
   .AddGraphExtension();
   





var app = builder.Build();


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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapGraphQL();





app.Run();

public partial class Program { }
