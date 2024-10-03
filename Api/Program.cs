using Api.Extension;
using Api.Query;
using Application.Account;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Infrastructure_Extensions;
using Infrastructure.SeedData;
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
   .AddGraphExtension() ;

builder.Services.AddOptions(builder.Configuration);


builder.Services.AddMediatR(config =>
{
    
    config.RegisterServicesFromAssembly(typeof(CreateAccountRequest).Assembly);

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

app.MapGraphQL();

app.Run();

