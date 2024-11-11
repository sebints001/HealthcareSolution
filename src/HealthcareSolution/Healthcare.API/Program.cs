using Healthcare.Application;
using Healthcare.DataAccess;
using Healthcare.API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Healthcare.API;
using Healthcare.Application.Interfaces;
using Healthcare.Application.Services;
using Healthcare.DataAccess.Repositories;
using Healthcare.DataAccess.UnitOfWork;
using Healthcare.DataAccess.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionHandlingFilter()); // Global exception filter
})
.AddJsonOptions(options =>
{
    // Customize JSON serializer settings if needed
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

//// Add DbContext with connection string (example for SQL Server)
builder.Services.AddDbContext<HealthcareDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Register the application services
builder.Services.AddScoped<IPatientRepository, PatientRepository>(); // Register repository implementation
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Register UnitOfWork implementation
builder.Services.AddScoped<IPatientService, PatientService>(); // Register service implementation


// Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Map controller routes

app.Run();