using Api.Presenters.Interfaces;
using Application.Mediators.IdCountryOperations.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters
{
    public class CountryPresenter: ICountryTypePresenter
    {
        public IActionResult GetCountryIdQuery(IdentificationCountryVm identificationCountryVm)
        {
            CustomResult result = new CustomResult();
            if (identificationCountryVm != null && identificationCountryVm.idCountryList.Any())
            {
                result.Content = identificationCountryVm.idCountryList;
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
