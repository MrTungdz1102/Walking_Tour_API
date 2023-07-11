using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Walking_Tour_API.SwaggerConfig
{
	public class SwaggerConfiguration : IConfigureNamedOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider _api;

		public SwaggerConfiguration(IApiVersionDescriptionProvider api)
		{
			this._api = api;
		}
		public void Configure(string? name, SwaggerGenOptions options)
		{
			Configure(options);
		}

		public void Configure(SwaggerGenOptions options)
		{
			foreach (var item in _api.ApiVersionDescriptions)
			{
				options.SwaggerDoc(item.GroupName, CreateVersionInfo(item));
			}
		}

		private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
		{
			var info = new OpenApiInfo
			{
				Title = "Your Version API",
				Version = description.ApiVersion.ToString()
			};
			return info;
		}
	}
}
