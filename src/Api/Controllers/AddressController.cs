using Api.Presenters.Interfaces.AddressPresenters;
using Application.Mediators.AddressOperations.Queries;
using Application.Mediators.AddressOperations.Queries.InsertAddress;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("addressType")]
    public class AddressController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IAddressTypePresenter addressTypePresenter;

        public AddressController(IMediator mediator, IAddressTypePresenter addressTypePresenter)
        {
            this.mediator = mediator;
            this.addressTypePresenter = addressTypePresenter;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Get(int AddressId)
        {
            var response = await this.mediator.Send(new GetAddressIdQuery(AddressId));
            return this.Ok(response);
        }
    }
}
