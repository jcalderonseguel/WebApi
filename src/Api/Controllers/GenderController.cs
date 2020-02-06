using MediatR;
using Api.Presenters.Interfaces;
using Application.Mediators.GenderOperations.Queries;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Genders")]
    [ApiController]
    public class GenderController : BaseController
    {
        private readonly IMediator mediator;
        //private readonly IGenderPresenter genderPresenter;
        //  IGenderPresenter genderPresenter
        public GenderController(IMediator mediator)
        {
            this.mediator = mediator;
            //this.genderPresenter = genderPresenter;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await this.mediator.Send(new GetGenderByIdQuery(Id));
            return this.Ok(response);
        }
    }
}