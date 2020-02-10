using Application.Mediators.AddressOperations.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters.Interfaces.AddressPresenters
{
    public interface IAddressTypePresenter
    {
        IActionResult GetAddressIdQuery(IdentificationAddressVm identificationAddressVm);
    }
}
