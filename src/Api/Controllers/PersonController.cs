using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Api.Presenters.Interfaces;
using Api.Presenters;

namespace Api.Controllers
{
    [Route("Persons")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IPersonPresenter personPresenter;

        public PersonController(IMediator mediator, IPersonPresenter personPresenter)
        {
            this.mediator = mediator;
            this.personPresenter = personPresenter;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody]InsertPerson person)
        {
            return Ok(await this.mediator.Send(person));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int Id)
        {
            return personPresenter.GetPersonByDocumentNumber(await this.mediator.Send(
                new GetPersonByDocumentNumberQuery(Id)));


        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Post([FromBody]InsertPerson person)
        {
            return personPresenter.InsertResult(await this.mediator.Send(person));
        }
    }
}