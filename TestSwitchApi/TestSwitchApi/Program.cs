using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Repositories;

namespace TestSwitchApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
           CreateAdminUsersIfNotExist(host);
           host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        private static void CreateAdminUsersIfNotExist(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<TestSwitchDbContext>();
            context.Database.EnsureCreated();
            IAdminRepo adminRepo = new AdminRepo(context);
            if (!context.AdminUsers.Any())
            {
                string newAdminEmail = Environment.GetEnvironmentVariable("DEFAULT_ADMIN_EMAIL")?.ToLower();
                string newAdminPassword = Environment.GetEnvironmentVariable("DEFAULT_ADMIN_PASSWORD");
                adminRepo.CreateNewAdminUser(newAdminEmail, newAdminPassword);
            }
        }
    }
}