using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TappitTechTest.Core.Interfaces;
using TappitTechTest.Core.Interfaces.Repositories;
using TappitTechTest.Core.Models;

namespace TappitTechTest.Infrastructure.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        public PeopleRepository(IConnectionFactory connectionFactory)
        {
            this.ConnectionFactory = connectionFactory;
        }

        private IConnectionFactory ConnectionFactory { get; }

        public async Task<Person> Get(int id)
        {
            using var dbConnection = this.ConnectionFactory.GetConnection();

            const string sql = @"
                         SELECT p.PersonId as Id, p.FirstName, p.LastName, p.IsAuthorised as Authorised, p.IsValid as Valid, p.IsEnabled as Enabled, s.SportId, s.Name
                           FROM tappittechnicaltest.people p
                LEFT OUTER JOIN tappittechnicaltest.favouritesports fs ON fs.PersonId = p.PersonId
                LEFT OUTER JOIN tappittechnicaltest.sports s ON fs.SportId = s.SportId
                     WHERE p.personid = @PersonId";

            var favouriteSports = new List<SportDto>();

            var result = await dbConnection.QueryAsync<Person, SportDto, Person>(sql, (person, sport) =>
            {
                if (sport is null)
                {
                    return person;
                }

                favouriteSports.Add(sport);

                return person;
            }, 
            param: new { PersonId = id },
            splitOn: "SportId");

            var person = result.FirstOrDefault();
            person.FavouriteSports = favouriteSports;

            return person;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            using var dbConnection = this.ConnectionFactory.GetConnection();

            const string sql = @"
                    SELECT p.PersonId as Id, p.FirstName, p.LastName, p.IsAuthorised as Authorised, p.IsValid as Valid, p.IsEnabled as Enabled, s.SportId, s.Name
                      FROM tappittechnicaltest.people p
                LEFT OUTER JOIN tappittechnicaltest.favouritesports fs ON fs.PersonId = p.PersonId
                LEFT OUTER JOIN tappittechnicaltest.sports s ON fs.SportId = s.SportId
                       ORDER BY p.PersonId";

            var people = new Dictionary<int, Person>();

            var result = await dbConnection.QueryAsync<Person, SportDto, Person>(sql, (person, sport) =>
            {
                if (!people.ContainsKey(person.Id))
                {
                    person.FavouriteSports = new List<SportDto>();
                    people.Add(person.Id, person);
                }

                if (sport is null)
                {
                    return person;
                }

                people[person.Id].FavouriteSports.Add(sport);

                return person;
            },
            splitOn: "SportId");

            return people.Values;
        }

        public async Task Update(int id, PersonUpdate updatedPerson)
        {
            using var dbConnection = this.ConnectionFactory.GetConnection();

            const string sql = @"
                UPDATE tappittechnicaltest.people p 
                   SET FirstName = @FirstName, LastName = @LastName, IsAuthorised = @Authorised, IsValid = @Valid, IsEnabled = @Enabled
                 WHERE PersonId = @Id";

            await dbConnection.ExecuteAsync(sql, 
                new 
                { 
                    Id = id, 
                    FirstName = updatedPerson.FirstName,
                    LastName = updatedPerson.LastName,
                    Authorised = updatedPerson.Authorised,
                    Valid = updatedPerson.Valid,
                    Enabled = updatedPerson.Enabled
                });
        }
    }
}
