using System.Threading.Tasks;

namespace TappitTechTest.Core.Interfaces.Repositories
{
    public interface IFavouriteSportsRepository
    {
        Task Delete(int personId);

        Task Add(int personId, int sportId);
    }
}
