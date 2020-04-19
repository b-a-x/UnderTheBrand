using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UnderTheBrand.Domain.Model.Utils;
using UnderTheBrand.Domain.Model.Values;
using UnderTheBrand.Presentation.Web.Server.Extensions;
using UnderTheBrand.Presentation.Web.Server.Middleware;

namespace UnderTheBrand.Presentation.Web.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = ModelStateValidator.ValidateModelState;
                });

            services.AddInjection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<LogRequestMiddleware>();
            app.UseMiddleware<LogErrorMiddleware>();
            app.UseMiddleware<LogResponseMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToFile("index.html");
            });
        }
        public static class ModelStateValidator
        {
            //TODO: Тест
            public static IActionResult ValidateModelState(ActionContext context)
            {
                (string fieldName, ModelStateEntry entry) = context.ModelState
                    .First(x => x.Value.Errors.Count > 0);

                string errorSerialized = entry.Errors.First().ErrorMessage;
                Error error = Error.Deserialize(errorSerialized);
                EnvelopeError envelope = EnvelopeError.Error(error, fieldName);
                var result = new BadRequestObjectResult(envelope);
                return result;
            }
        }
    }
}
