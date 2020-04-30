using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Repositories;
using TestSwitchApi.Services;

namespace TestSwitchApi
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
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            services.AddControllers();
            services.AddTransient<ICandidatesRepo, CandidatesRepo>();
            services.AddTransient<ICandidateTestsRepo, CandidateTestsRepo>();
            services.AddTransient<IAdminRepo, AdminRepo>();
            services.AddCors(options =>
                {
                    options.AddPolicy(
                        "AllowOrigin",
                        builder => builder.WithOrigins(
                            "http://localhost:3001", "http://localhost:3000", "https://testswitch-candidate-staging.herokuapp.com", "https://testswitch-candidate.herokuapp.com", "https://testswitch-admin-staging.herokuapp.com", "https://testswitch-admin.herokuapp.com"));
                });
            if (env == "Development")
            {
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<TestSwitchDbContext>(opt =>
                        opt.UseNpgsql(Configuration.GetConnectionString("testSwitchConnection")));
            }
            else
            {
                var dbservice = new DatabaseService();
                var dbConnectionString = dbservice.BuildConnectionString();
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<TestSwitchDbContext>(opt =>
                        opt.UseNpgsql(dbConnectionString));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowOrigin");
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}