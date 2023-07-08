using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Interface.Services;
using Walking_Tour_API.Core.Mapping;
using Walking_Tour_API.Core.Services.Regions;
using Walking_Tour_API.Infrastructure.Context;
using Walking_Tour_API.Infrastructure.Middleware;
using Walking_Tour_API.Infrastructure.Repository;
using Walking_Tour_API.Core.Services;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Core.Models.DTO.Region;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TourAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// builder.Services.AddScoped(IGenericService<>, typeof(GenericService<Region, GetRegionDTO, AddRegionDTO, UpdateRegionDTO>));
// builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MapperConfig)); // need automapper dependency injection

builder.Services.AddControllers().AddOData(options => // OData
{
	options.Select().Filter().OrderBy();
});

builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("TourAPI").AddEntityFrameworkStores<TourAPIDbContext>().AddDefaultTokenProviders();
	//AddDefaultTokenProviders() dung de tao token reset password,change email,...

builder.Services.Configure<IdentityOptions>(options =>
{
	// config user, password,...
	options.Password.RequireDigit = false;
	options.Password.RequireUppercase= false;
});

builder.Services.AddAuthentication(options => {
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ClockSkew = TimeSpan.Zero,
		ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
		ValidAudience = builder.Configuration["JwtSettings:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
	};
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
