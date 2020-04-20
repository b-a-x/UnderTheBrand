using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UnderTheBrand.Domain.ValueObject.Utils;
using UnderTheBrand.Domain.ValueObject.Values;
using UnderTheBrand.Infrastructure.Dal.Context;
using UnderTheBrand.Presentation.Web.Server.Extensions;
using UnderTheBrand.Presentation.Web.Server.Middleware;

namespace UnderTheBrand.Presentation.Web.Server
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(o => 
                o.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = ModelStateValidator.ValidateModelState;
                }); 
            //services.AddMvc();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            services.AddInjection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<LogRequestMiddleware>();
            app.UseMiddleware<LogErrorMiddleware>();
            app.UseMiddleware<LogResponseMiddleware>();

            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Program>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Program>("index.html");
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
