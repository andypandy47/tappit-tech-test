using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TappitTechTest.Core.Interfaces.Services;
using TappitTechTest.Core.Models;

namespace TappitTechTest.Api.Controllers
{
    [Route("people")]
    public class PeopleController : ControllerBase
    {
        public PeopleController(IPeopleService peopleService)
        {
            this.PeopleService = peopleService;
        }

        private IPeopleService PeopleService { get; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var person = await this.PeopleService.GetAll();

            return this.Ok(person);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await this.PeopleService.Get(id);

            if (person is null)
            {
                return this.NotFound();
            }

            return this.Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonUpdate updatedPerson)
        {
            if (updatedPerson is null)
            {
                return this.BadRequest();
            }

            var result = await this.Get(id);

            if (result is NotFoundResult)
            {
                return result;
            }

            await this.PeopleService.Update(id, updatedPerson);

            return this.Ok();
        }
    }
}
