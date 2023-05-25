using System.Threading.Tasks;
using Dapper;
using TappitTechTest.Core.Interfaces;
using TappitTechTest.Core.Interfaces.Repositories;

namespace TappitTechTest.Infrastructure.Repositories
{
    public class FavouriteSportsRepository : IFavouriteSportsRepository
    {
        public FavouriteSportsRepository(IConnectionFactory connectionFactory)
        {
            this.ConnectionFactory = connectionFactory;
        }

        private IConnectionFactory ConnectionFactory { get; }

        public async Task Add(int personId, int sportId)
        {
            using var dbConnection = this.ConnectionFactory.GetConnection();

            const string sql = @"
                INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) 
                     VALUES (@PersonId, @SportId);";

            await dbConnection.ExecuteAsync(sql, new { PersonId = personId, SportId = sportId });
        }

        public async Task Delete(int personId)
        {
            using var dbConnection = this.ConnectionFactory.GetConnection();

            const string sql = @"
                DELETE FROM TappitTechnicalTest.FavouriteSports
                      WHERE PersonId = @PersonId;";

            await dbConnection.ExecuteAsync(sql, new { PersonId = personId });
        }
    }
}
