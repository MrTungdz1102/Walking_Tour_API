using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Interface.Repositories;
using Walking_Tour_API.Core.Mapping;
using Walking_Tour_API.Infrastructure.Context;
using Walking_Tour_API.Infrastructure.Middleware;
using Walking_Tour_API.Infrastructure.Repository;
using Walking_Tour_API.SwaggerConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TourAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var logger = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File("Logs/TourAPI_Log.txt", rollingInterval: RollingInterval.Day)
	.MinimumLevel.Warning()
	.CreateLogger(); // nen cau hinh trong appsetting.json, k can package serilog.file

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


// builder.Services.AddScoped(IGenericService<>, typeof(GenericService<Region, GetRegionDTO, AddRegionDTO, UpdateRegionDTO>));
// builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

builder.Services.AddAutoMapper(typeof(MapperConfig)); // need automapper dependency injection

builder.Services.AddControllers().AddOData(options => // OData
{
	options.Select().Filter().OrderBy();
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("TourAPI").AddEntityFrameworkStores<TourAPIDbContext>().AddDefaultTokenProviders();
//AddDefaultTokenProviders() dung de tao token reset password,change email,...

builder.Services.Configure<IdentityOptions>(options =>
{
	// config user, password,...
	options.Password.RequireDigit = false;
	options.Password.RequireUppercase = false;
});

builder.Services.AddAuthentication(options =>
{
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
builder.Services.AddSwaggerGen(options =>
{
	// comment de config version cho swagger
//	options.SwaggerDoc("v1", new OpenApiInfo { Title = "Walking Tour API", Version = "v1" });
	options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
	{
		Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = JwtBearerDefaults.AuthenticationScheme
	});

	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference {
								Type = ReferenceType.SecurityScheme,
								Id = JwtBearerDefaults.AuthenticationScheme
							},
				Scheme = "0auth2",
				Name = JwtBearerDefaults.AuthenticationScheme,
				In = ParameterLocation.Header
			},
			new List<string>()
		}
	});
});

builder.Services.ConfigureOptions<SwaggerConfiguration>();

builder.Services.AddApiVersioning(options =>
{
	options.ReportApiVersions = true;
	// for swagger
	//options.ApiVersionReader = ApiVersionReader.Combine(
	//	new HeaderApiVersionReader("X-Version"),
	//	new QueryStringApiVersionReader("api-version"),
	//	new MediaTypeApiVersionReader("ver"));
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new ApiVersion(1, 0);
}); // version 

builder.Services.AddVersionedApiExplorer(options =>
{
	options.GroupNameFormat = "'v'VVV";
	options.SubstituteApiVersionInUrl = true;
}); // for swagger 



var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		foreach (var description in provider.ApiVersionDescriptions) { 
			options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant()); }
	});
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
	RequestPath = "/Images"
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
