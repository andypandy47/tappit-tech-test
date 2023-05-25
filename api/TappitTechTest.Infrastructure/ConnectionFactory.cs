using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using TappitTechTest.Core.Interfaces;

namespace TappitTechTest.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        public ConnectionFactory(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("Postgres");
        }

        private string ConnectionString { get; }

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(this.ConnectionString);
        }
    }
}
