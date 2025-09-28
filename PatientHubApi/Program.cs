using Microsoft.EntityFrameworkCore;
using PatientHubApi.API.Middleware;
using PatientHubApi.Application;
using PatientHubApi.Infrastructure;


// Data Context
using PatientHubApi.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Configure CORS policy to allow requests from any origin
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll", policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientHub API v1");
        c.RoutePrefix = "swagger";  // Swagger disponible en /swagger
    });
}

// Redirección de la ruta raíz a Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseCors("AllowAll");
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
