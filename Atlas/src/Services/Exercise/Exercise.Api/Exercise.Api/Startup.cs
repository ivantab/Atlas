using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exercises.Services.Querys;
using Exercise.DataAccess.DataBase;
using Exercises.Services.Querys.Querys.MuscleQuery;
using Exercises.Services.Querys.Querys.LocationQuery;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

namespace Exercise.Api
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
            services.AddDbContext<AtlasExerciseContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddControllers();
            //Injeccion de dependencias
            services.AddTransient<IMuscleQueryService, MuscleQueryService>();
            services.AddTransient<ILocationQueryService, LocationQueryService>();

            //HealtChecks
            services.AddHealthChecks().AddCheck("Self", () => HealthCheckResult.Healthy()).
                AddDbContextCheck<AtlasExerciseContext>();

            //MediatR
            services.AddMediatR(Assembly.Load("Exercise.Services.EventHandler"));
            //AplicationInsigth
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapHealthChecks("/Exercise/healthcheack",
                new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapControllers();
            });
        }
    }
}
