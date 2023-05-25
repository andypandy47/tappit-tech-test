using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using TappitTechTest.Core.Interfaces;
using TappitTechTest.Core.Interfaces.Repositories;
using TappitTechTest.Core.Models;

namespace TappitTechTest.Infrastructure.Repositories
{
    public class SportsRepository : ISportsRepository
    {
        public SportsRepository(IConnectionFactory connectionFactory)
        {
            this.ConnectionFactory = connectionFactory;
        }

        private IConnectionFactory ConnectionFactory { get; }

        public async Task<IEnumerable<Sport>> GetAll()
        {
            using var dbConnection = this.ConnectionFactory.GetConnection();

            const string sql = @"
                    SELECT s.SportId, s.Name, s.IsEnabled as Enabled, fs.PersonId
                      FROM TappitTechnicalTest.Sports s
                INNER JOIN TappitTechnicalTest.FavouriteSports fs ON fs.SportId = s.SportId
                  ORDER BY s.SportId;";

            var sports = new Dictionary<int, Sport>();

            await dbConnection.QueryAsync<Sport, int, Sport>(sql, (sport, personId) =>
            { 
                if (!sports.ContainsKey(sport.SportId))
                {
                    sports.Add(sport.SportId, sport);
                }

                sports[sport.SportId].FavouritedCount++;

                return sport;
            }, splitOn: "PersonId");

            return sports.Values;
        }
    }
}
