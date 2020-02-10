using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Controllers
{
    [ApiController]
    public class BaseController: ControllerBase
    {
        private IMediator _mediator;

        // Para que funcione GetService, es necesario importar dependencyInjection ubicado en Persistance
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
