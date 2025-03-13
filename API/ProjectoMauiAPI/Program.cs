//using API.Data;
using Microsoft.EntityFrameworkCore;
using ProjectoMauiAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DemoDbContext>(x =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConexion");
    x.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();
