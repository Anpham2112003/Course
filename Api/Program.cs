using Api.Extension;
using Application.Account;
using Domain.Errors;
using HotChocolate;
using HotChocolate.Execution;
using Infrastructure;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.SeedData;
using MediatR.NotificationPublishers;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InfrastructureInjectServices(builder.Configuration);

builder.Services
   .AddGraphQLServer()
   .AddGraphExtension();

builder.Services.AddSingleton(cg => new RequestExecutorProxy(cg.GetRequiredService<IRequestExecutorResolver>(), Schema.DefaultName));
  

builder.Services.AddOptions(builder.Configuration);


builder.Services.AddMediatR(config =>
{
    
    config.RegisterServicesFromAssembly(typeof(CreateAccountRequest).Assembly);

    config.NotificationPublisher = new TaskWhenAllPublisher();

    config.NotificationPublisherType=typeof(TaskWhenAllPublisher);
});

builder.Services.AddAuthentication()
    .AddJwtBearer(config =>
    {
        config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuser"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Accesskey"]))
        };
    });



builder.Services.AddHttpContextAccessor();

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

app.MapGraphQL().WithOptions(new HotChocolate.AspNetCore.GraphQLServerOptions
{
    EnableBatching = true,
});

app.Run();

public partial class Program { }
