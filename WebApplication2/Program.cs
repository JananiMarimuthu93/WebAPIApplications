using CodeFirstApproach.Interface;
using CodeFirstApproach.Repository;
using CodeFirstApproach.Service;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt => { opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EfCodeFirstContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("NewConnection")));

builder.Services.AddScoped<IStudentRepository,StudentService>();
builder.Services.AddScoped<IStandardRepository,StandardService>();

//builder.Services.AddScoped<StudentService>();
//builder.Services.AddScoped<StandardService>();

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
