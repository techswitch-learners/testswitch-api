using System;
using Npgsql;

namespace TestSwitchApi.Services
{
    public class DatabaseService
    {
        public string BuildConnectionString()
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                TrustServerCertificate = true,
                SslMode = SslMode.Require,
            };

            return builder.ToString();
        }
    }
}