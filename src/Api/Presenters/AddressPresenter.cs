using Api.Presenters.Interfaces.AddressPresenters;
using Application.Mediators.AddressOperations.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters
{
    public class AddressPresenter : IAddressTypePresenter
    {
        public IActionResult GetAddressIdQuery(IdentificationAddressVm identificationAddressVm)
        {
            CustomResult result = new CustomResult();
            if (identificationAddressVm != null && identificationAddressVm.idAddressList.Any())
            {
                result.Content = identificationAddressVm.idAddressList;
            }
            else
            {
                result.StatusCode = 404;
                result.Message = "No Content";
            }
            return new JsonResult(result);
        }
    }
}
