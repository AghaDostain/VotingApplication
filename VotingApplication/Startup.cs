using System.Linq;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetCore.AutoRegisterDi;
using VotingApplication.Data;
using VotingApplication.Repositories.Implementations;
using VotingApplication.Services.Interfaces;
using VotingApplication.Validations;
using VotingApplication.WebAPI.Attribute;
using VotingApplication.WebAPI.Middleware;

namespace VotingApplication
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
            services.AddCors();
            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Voting Application",
                    Description = "Voting Application",
                });
            });

            var ServiceAssemblyToScan = Assembly.GetAssembly(typeof(CandidateManager));
            services.RegisterAssemblyPublicNonGenericClasses(ServiceAssemblyToScan)
              .Where(c => c.Name.EndsWith("Manager"))
              .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            var repositoryAssemblyToScan = Assembly.GetAssembly(typeof(CandidateRepository));
            services.RegisterAssemblyPublicNonGenericClasses(repositoryAssemblyToScan)
              .Where(c => c.Name.EndsWith("Repository"))
              .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.AddScoped<DbContext, DataContext>();
            services.AddMvc(opt => opt.Filters.Add(typeof(ValidateModelAttribute)))
                .AddControllersAsServices()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CategoryVMValidator>());
                //.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Voting Application");
            });
            // Serialize all exceptions to JSON
            var jsonExceptionMiddleware = new ExceptionMiddleware(app.ApplicationServices.GetRequiredService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>());
            app.UseExceptionHandler(new ExceptionHandlerOptions { ExceptionHandler = jsonExceptionMiddleware.Invoke });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
