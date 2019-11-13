using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SF.IoC;
using SF.Services.Interfaces.CustomExceptions;
using SF.Services.Models;
using SF.WebAPI.Filters;

namespace SF.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ExceptionFilter>();

            services.AddMvc(
                options =>
                {
                    options.Filters.Add<ExceptionFilter>();
                    options.EnableEndpointRouting = false;
                }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        throw new BadArgumentException(string.Join(" ", context.ModelState.Values.SelectMany(value => value.Errors.Select(error => error.ErrorMessage)).ToList()));
                    };
                });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddCors();

            services.AddAppSettingsConfiguration(Configuration);
            var appSettings = services.BuildServiceProvider().GetService<IOptions<AppSettings>>().Value;

            #region Swagger

            var swaggerInfoSettings = appSettings.SwaggerSettings.SwaggerInfoSettings;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerInfoSettings.Version, new OpenApiInfo
                {
                    Title = swaggerInfoSettings.Title,
                    Version = swaggerInfoSettings.Version,
                    Description = swaggerInfoSettings.Description,
                });
            });

            #endregion

            services.AddDatabaseContext(appSettings.ConnectionString);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<AppSettings> appSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #region Swagger

            var swaggerInfoSettings = appSettings.Value.SwaggerSettings.SwaggerInfoSettings;

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: $"/swagger/{ swaggerInfoSettings.Version }/swagger.json",
                            name: $"Versioned API { swaggerInfoSettings.Version }");
            });

            #endregion

            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{id?}");
            });
        }
    }
}
