using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Mapping;
using Walking_Tour_API.Infrastructure.Context;
using Walking_Tour_API.Infrastructure.Middleware;
using Walking_Tour_API.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TourAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MapperConfig)); // need automapper dependency injection

builder.Services.AddControllers().AddOData(options => // OData
{
	options.Select().Filter().OrderBy();
});
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

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
