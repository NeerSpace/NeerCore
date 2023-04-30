using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NeerCore.Api.Extensions;

namespace NeerCore.Api.Swagger.Extensions;

public static class SwaggerExtensions
{
    private const string SwaggerConfigurationSectionName = "Swagger";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configureInfo"></param>
    public static IServiceCollection AddNeerSwagger(
        this IServiceCollection services, Func<ApiVersionDescription, OpenApiInfo>? configureInfo = null)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        services.AddEndpointsApiExplorer();
        services.Configure<SwaggerConfigurationOptions>(options => configuration.Bind(SwaggerConfigurationSectionName, options));
        services.Configure<OpenApiInfoProviderOptions>(options => options.ConfigureDelegate = configureInfo);
        services.ConfigureOptions<SwaggerConfiguration>();
        services.AddSwaggerGen();

        return services;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    public static IApplicationBuilder UseNeerSwagger(this IApplicationBuilder app)
    {
        var swaggerOptions = app.ApplicationServices.GetRequiredService<IOptions<SwaggerConfigurationOptions>>().Value;
        swaggerOptions.OpenapiFormats ??= new[] { "json" };
        var apiProvider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

        if (swaggerOptions.Enabled)
        {
            app.UseSwagger();
            app.UseNeerSwaggerUI(options =>
            {
                foreach (var description in apiProvider.ApiVersionDescriptions)
                {
                    var showFormat = swaggerOptions.OpenapiFormats.Length >= 2;
                    var name = $"{swaggerOptions.Title} {description.GroupName.ToUpper()}";
                    var url = $"/swagger/{description.GroupName}/swagger";

                    if (swaggerOptions.OpenapiFormats.Contains("json", StringComparer.OrdinalIgnoreCase))
                        options.SwaggerEndpoint(url + ".json", showFormat
                            ? $"{name} (json)"
                            : name);
                    if (swaggerOptions.OpenapiFormats.Contains("yaml", StringComparer.OrdinalIgnoreCase))
                        options.SwaggerEndpoint(url + ".yaml", showFormat
                            ? $"{name} (yaml)"
                            : name);
                }

                options.RoutePrefix = swaggerOptions.SwaggerUrl;
                options.DocumentTitle = swaggerOptions.Title;
                options.EnableFilter();

                if (swaggerOptions.ExtendedDocs)
                {
                    options.InjectStylesheet("/neercore/swagger-extensions.css");
                    options.InjectJavascript("/neercore/swagger-extensions.js");
                }
            });
        }

        if (swaggerOptions.ApiDocs)
        {
            var format = swaggerOptions.OpenapiFormats.Contains("json")
                ? "json"
                : swaggerOptions.OpenapiFormats.First();
            foreach (var description in apiProvider.ApiVersionDescriptions)
            {
                app.UseReDoc(options =>
                {
                    options.DocumentTitle = $"{swaggerOptions.Title} {description.GroupName.ToUpper()}";
                    options.SpecUrl = $"../swagger/{description.GroupName}/swagger.{format}";
                    options.RoutePrefix = swaggerOptions.ApiDocsUrl.Replace("{version}", description.GroupName.ToLower());
                    options.HeadContent = swaggerOptions.ApiDocsHeadContent;
                });
            }
        }

        return app;
    }

    public static SwaggerConfigurationOptions GetSwaggerSettings(this IConfiguration configuration)
    {
        var settings = new SwaggerConfigurationOptions();
        configuration.Bind(SwaggerConfigurationSectionName, settings);
        return settings;
    }
}