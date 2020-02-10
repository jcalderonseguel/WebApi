using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Presenters.Interfaces.EmailPresenters;
using Application.Mediators.EmailOperations.Queries;

namespace Api.Controllers
{
    [ApiController]
    [Route("mailType")]
    public class EmailController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IEmailTypePresenter emailTypePresenter;

        public EmailController(IMediator mediator, IEmailTypePresenter emailTypePresenter)
        {
            this.mediator = mediator;
            this.emailTypePresenter = emailTypePresenter;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Get(int EmailId)
        {
            var response = await this.mediator.Send(new GetEmailIdQuery(EmailId));
            return this.Ok(response);
        }


    }
}
