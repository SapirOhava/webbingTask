using ActivityLogger.Data;
using ActivityLogger.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddDbContext<ActivityLoggerContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ActivityLoggerConnection")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            //avichai you can alter this and add other domains
            builder.WithOrigins("http://webbing.com", "https://www.webbing.com")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
