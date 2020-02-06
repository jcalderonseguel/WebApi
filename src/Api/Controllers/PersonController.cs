using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mediators.Insert;
using Application.Mediators.PersonOperations.PersonExistById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Mediators.PersonOperations.GetPersonByDocumentNumber;
using Api.Presenters.Interfaces;

namespace Api.Controllers
{
    [Route("persons")]
    [ApiController]
    public class PersonController : ControllerBase
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
            return Ok(await this.mediator.Send(person));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string name,string lastName,string rut,int genderId)
        {
            return personPresenter.GetPersonByDocumentNumber(await this.mediator.Send(
                new GetPersonByDocumentNumberQuery(name, lastName, rut, genderId)));
        }

        [HttpGet("exist/{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PersonExistVm>> ExsitPersonById(int Id)
        {
            return Ok(await this.mediator.Send(new PersonExistByIdQuery { Id = Id }));
        }
    }

}