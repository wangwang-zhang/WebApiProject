
using AutoWrapper;
using StudentWebAPI.Dao;
using StudentWebAPI.Filters;
using StudentWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StudentService>();
builder.Services.AddSingleton<IStudentDao,StudentDaoImpl>();
builder.Services.AddTransient<ILogger>(s => s.GetRequiredService<ILogger<Program>>());
builder.Services.AddControllers(options => options.Filters.Add<ResponseFilter>());
builder.Services.AddControllers(options => options.Filters.Add<ActionFilter>());
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
app.UseAutoWrapper();

app.Run();