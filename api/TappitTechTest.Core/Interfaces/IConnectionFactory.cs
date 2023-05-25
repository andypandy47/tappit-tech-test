using System.Data;

namespace TappitTechTest.Core.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
