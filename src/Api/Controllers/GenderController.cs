using Api.Presenters.Interfaces.GenderPresenters;
using Application.Mediators.GenderOperations.Queries;
using Application.Mediators.GenderOperations.Queries.InsertGender;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("genderType")]
    public class GenderController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IGenderTypePresenter genderTypePresenter;

        public GenderController(IMediator mediator, IGenderTypePresenter genderTypePresenter)
        {
            this.mediator = mediator;
            this.genderTypePresenter = genderTypePresenter;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Get(int GenderId)
        {
            var response = await this.mediator.Send(new GetGenderIdQuery(GenderId));
            return this.Ok(response);
        }
    }
}
