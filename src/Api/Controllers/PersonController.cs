using System.Threading.Tasks;
using Api.Presenters.Interfaces.PersonPresenters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Mediators.PersonOperations.Queries;
using Application.Mediators.PersonOperations.Queries.InsertPerson;

namespace Api.Controllers
{
    [Route("persons")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IPersonTypePresenter personTypePresenter;

        public PersonController(IMediator mediator, IPersonTypePresenter personTypePresenter)
        {
            this.mediator = mediator;
            this.personTypePresenter = personTypePresenter;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Get(int PersonId)
        {
            var response = await this.mediator.Send(new GetPersonIdQuery(PersonId));
            return this.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Post([FromBody]InsertPerson Person)
        {
            return Ok(await this.mediator.Send(Person));
        }
    }
}