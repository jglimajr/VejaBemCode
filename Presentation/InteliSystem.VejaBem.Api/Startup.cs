using InteliSystem.VejaBem.Api.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace InteliSystem.VejaBem.Api
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
            // services.AddControllers()
            //     .ConfigureApiBehaviorOptions(options => {
            //         options.SuppressConsumesConstraintForFormFileParameters = true;
            //         options.SuppressModelStateInvalidFilter = true;
            //         options.SuppressMapClientErrors = true;
            //         options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
            //     });

            // services.Configure<CookiePolicyOptions>(options => {
            //     options.CheckConsentNeeded = context => true;
            //     options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            // });
            // services.AddMvcCore().AddMvcOptions(options =>
            //     options.EnableEndpointRouting = false);
            services.AddMvc().AddMvcOptions(options => 
                options.EnableEndpointRouting = false
            ).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddResponseCompression();
            //services.AddAuthorization();
            //services.AddTransients();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VejaBem - API",
                    Version = "v1",
                    Description = "Api para consumir o servido do Sistema Veja Bem"
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Veja Bem API Info");
                s.RoutePrefix = string.Empty;
            });
            
            // app.UseHttpsRedirection();
            //app.UseRouting();
            // app.UseAuthorization();

        }
    }
}
