using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Mediators.PersonsOperations.InsertPerson;

namespace Api.Controllers
{

    [ApiController]
    [Route("persons")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody]InsertPerson person)
        {
            //long response = await this.mediator.Send(person);
            //return this.Ok(response);

            return Ok(await this.mediator.Send(person));
        }
    }
}