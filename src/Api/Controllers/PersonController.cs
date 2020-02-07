using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Api.Presenters.Interfaces;
using Application.Mediators.PersonOperations.Queries;

namespace Api.Controllers
{
    [Route("Persons")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IPersonPresenter personPresenter;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
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