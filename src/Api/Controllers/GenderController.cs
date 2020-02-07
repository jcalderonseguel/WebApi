
using Application.Mediators.PersonOperations.Insert;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("genders")]

    public class GenderController : ControllerBase
    {

        private readonly IMediator mediator;
      //  private readonly IGenderPresenter personPresenter;


        public GenderController(IMediator mediator)
        {
            this.mediator = mediator;


        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody]InsertGender gender)
        {
            return Ok(await this.mediator.Send(gender));
        }


        

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Get(int Id)
        //{

        //}
        

    }
}
