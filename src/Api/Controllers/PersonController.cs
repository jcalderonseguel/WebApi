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
}