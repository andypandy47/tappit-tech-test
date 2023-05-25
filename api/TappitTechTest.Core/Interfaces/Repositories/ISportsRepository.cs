using System.Collections.Generic;
using System.Threading.Tasks;
using TappitTechTest.Core.Models;

namespace TappitTechTest.Core.Interfaces.Repositories
{
    public interface ISportsRepository
    {
        Task<IEnumerable<Sport>> GetAll();
    }
}
