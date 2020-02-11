using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http;
using Api.Presenters.Interfaces;
using Application.Mediators.CountryOperations;
using Application.Mediators.CountryOperations.InsertCountry;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.CountryController
{
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CountryController(IMediator mediator)
        {
            this.mediator = mediator;
           
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int countryId)
        {

            //return documentTypePresenter.GetIdDocumentTypeByCountry(await this.mediator.Send(new GetIdDocumentTypeByCountryQuery(countryId)));
            var response = await this.mediator.Send(new GetCountryByIdQuery(countryId));

            return this.Ok(response);
        }



    }
}