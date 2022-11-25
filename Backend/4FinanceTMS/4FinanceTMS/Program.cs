using _4FinanceTMS.Data;
using _4FinanceTMS.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidation(options =>
options.RegisterValidatorsFromAssemblyContaining<Program>());

// configure the DBContext
builder.Services.AddDbContext<TMSDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TMS"));
});

// enabeling CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        //builder.AllowAnyOrigin();
        builder.WithOrigins("https://localhost:3000");
    });
});

// configure the interface
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
