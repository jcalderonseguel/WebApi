using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Api.Presenters.Interfaces;
using Microsoft.AspNetCore.Http;
using Application.Mediators.IdCountryOperations.Queries;
using Domain.Entities;

namespace Api.Controllers
{
    [ApiController]
    [Route("countryType")]
    public class CountryController : BaseController
    {
        private readonly IMediator mediator;
        private readonly ICountryTypePresenter documentTypePresenter;

        public CountryController(IMediator mediator, ICountryTypePresenter documentTypePresenter)
        {
            this.mediator = mediator;
            this.documentTypePresenter = documentTypePresenter;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Get(int CountryId)
        {
            var response = await this.mediator.Send(new GetCountryIdQuery(CountryId));
            return this.Ok(response);
        }

    }
}
