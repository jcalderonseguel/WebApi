using System.Threading.Tasks;
using Api.Presenters;
using Api.Presenters.Interfaces.PersonPresenters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Mediators.PersonOperations.Queries;
using Application.Mediators.PersonOperations.Queries.InsertPerson;

namespace Api.Controllers
{
    [Route("personType")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IPersonTypePresenter personTypePresenter;
        private readonly IPersonPresenter personPresenter;

        public PersonController(IMediator mediator, IPersonTypePresenter personTypePresenter, IPersonPresenter personPresenter)
        {
            this.mediator = mediator;
            this.personTypePresenter = personTypePresenter;
            this.personPresenter = personPresenter;
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

        public async Task<ActionResult> Post([FromBody]InsertPerson person)
        {
            return PersonPresenter.InsertResult(await this.mediator.Send(person));
        }
    }
}