using Application.EmployeeCrud.Interfaces;
using Application.EmployeeCrud.Queries.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<ProjectDbContext>(
                    dbContextOptions => dbContextOptions
                      .UseMySql(
                        builder.Configuration["ConnectionStrings:MySqlDatabase"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:MySqlDatabase"]
                      )
                    )
                  );

builder.Services.AddMediatR(typeof(GetQueryHandler).Assembly);


builder.Services.AddScoped<IEmployeeTableService, EmployeeTableService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
