using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnderTheBrand.Domain.ValueObject.Helpers;
using UnderTheBrand.Domain.ValueObject.Values;
using UnderTheBrand.Infrastructure.DAL.Context;
using UnderTheBrand.Presentation.Server.Extensions;
using UnderTheBrand.Presentation.Server.Middlewares;

namespace UnderTheBrand.Presentation.Server
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UnderTheBrandContext>(options =>
                options.UseSqlite("Filename=Database_UnderTheBrand.db"));

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = ModelStateValidator.ValidateModelState;
                });

            services.AddMvc();

            services.AddMemoryCache();
            services.AddInjection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class ModelStateValidator
    {
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
