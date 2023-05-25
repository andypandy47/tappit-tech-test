using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TappitTechTest.Core.Interfaces.Repositories;

namespace TappitTechTest.Api.Controllers
{
    [Route("sports")]
    public class SportsController : ControllerBase
    {
        public SportsController(ISportsRepository sportRepoistory)
        {
            this.SportsRepository = sportRepoistory;
        }

        private ISportsRepository SportsRepository { get; set; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sports = await this.SportsRepository.GetAll();

            return this.Ok(sports);
        }
    }
}
