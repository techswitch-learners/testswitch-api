using System;
using Npgsql;

namespace TestSwitchApi.Services
{
    public class DataBaseService
    {
        public string ConnectionStringBuilder()
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
            };

            return builder.ToString() + ";sslmode=Require;Trust Server Certificate=true;";
        }
    }
}