using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TappitTechTest.Core.Interfaces.Repositories;
using TappitTechTest.Core.Interfaces.Services;
using TappitTechTest.Core.Models;

namespace TappitTechTest.Infrastructure.Services
{
    public class PeopleService : IPeopleService
    {
        public PeopleService(IPeopleRepository peopleRepository, IFavouriteSportsRepository favouriteSportsRepository)
        {
            this.PeopleRepository = peopleRepository;
            this.FavouriteSportsRepository = favouriteSportsRepository;
        }

        private IPeopleRepository PeopleRepository { get; }

        private IFavouriteSportsRepository FavouriteSportsRepository { get; }

        public async Task<Person> Get(int id)
        {
            var person = await this.PeopleRepository.Get(id);

            return person;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var people = await this.PeopleRepository.GetAll();

            return people;
        }

        public async Task Update(int id, PersonUpdate updatedPerson)
        {
            if (updatedPerson is null)
            {
                throw new ArgumentNullException(nameof(updatedPerson));
            }

            await this.PeopleRepository.Update(id, updatedPerson);

            await this.FavouriteSportsRepository.Delete(id);

            if (updatedPerson.FavouriteSports.Count > 0)
            {
                var insertTasks = updatedPerson.FavouriteSports.Select(x => this.FavouriteSportsRepository.Add(id, x));

                await Task.WhenAll(insertTasks);
            }
        }
    }
}
