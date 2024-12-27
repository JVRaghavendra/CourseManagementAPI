
using CourseManagementAPI.DBContext;
using CourseManagementAPI.Interfaces;
using CourseManagementAPI.Repository;
using CourseManagementAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .LogTo(Console.WriteLine, LogLevel.Information));


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISubscriberCourseService, SubscriberCourseService>();
builder.Services.AddScoped<ISubscriberCourseRepository, SubscriberCourseRepository>();

builder.Services.AddScoped<ICourseInfoService, CourseInfoService>();
builder.Services.AddScoped<ICourseInfoRepository, CourseInfoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
