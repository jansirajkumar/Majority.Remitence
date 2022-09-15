using System.Reflection;
using Majority.RemittanceProvider.Api.Middlewares;
using Majority.RemittanceProvider.Api.PipelineBehaviours;
using Majority.RemittanceProvider.Application.Extensions;
using Majority.RemittanceProvider.Infrastructure.Extensions;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console());
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add mediatR services
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Add validator behaviour pipeline to validate the query/command
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Injecting application services
builder.Services.AddApplicationServices();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<AuthorizationHandlerMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
