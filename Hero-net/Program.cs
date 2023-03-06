global using Hero_net.Models;
using Hero_net.Repository;
using Hero_net.Service;
using Hero_net.Service.Imp; //Everything using Models folder

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly); //Add AutoMapper
//Dependency Injection (báo cho hệ thống biết là có 1 cái ICharacterService, và nó sẽ tạo ra 1 cái CharacterService để dùng
builder.Services.AddScoped<ICharacterService, CharacterService>(); 


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

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ICourseService, CourseService>();
    services.AddTransient<ICourseRepository, CourseRepository>();
}