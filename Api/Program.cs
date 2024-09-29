using Api.Extension;
using Api.Query;
using Infrastructure.Infrastructure_Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InfrastructureInjectServices(builder.Configuration);

builder.Services.AddGraphQLServer()
   .AddGraphQLServer()
   .AddGraphExtension()
   ;
   



builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
    
}

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();

