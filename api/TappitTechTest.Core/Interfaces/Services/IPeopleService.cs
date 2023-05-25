using System.Collections.Generic;
using System.Threading.Tasks;
using TappitTechTest.Core.Models;

namespace TappitTechTest.Core.Interfaces.Services
{
    public interface IPeopleService
    {
        Task<Person> Get(int id);

        Task<IEnumerable<Person>> GetAll();

        Task Update(int id, PersonUpdate updatedPerson);
    }
}
