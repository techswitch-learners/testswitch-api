using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Services;

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
            if (!context.AdminUsers.Any())
            {
                var passwordService = new PasswordService();
                string newAdminEmail = Environment.GetEnvironmentVariable("DEFAULTADMINEMAIL");
                string newAdminPassword = Environment.GetEnvironmentVariable("DEFAULTADMINPASSWORD");
                byte[] newAdminPasswordSalt = passwordService.GenerateSalt();
                string hashedPassword =
                    passwordService.HashPassword(
                        newAdminPassword,
                        newAdminPasswordSalt);
                var newAdminUser = new AdminUserDataModel()
                {
                    Email = newAdminEmail,
                    PasswordSalt = newAdminPasswordSalt,
                    HashedPassword = hashedPassword,
                };
                context.AdminUsers.Add(newAdminUser);
                context.SaveChanges();
            }
        }
    }
}