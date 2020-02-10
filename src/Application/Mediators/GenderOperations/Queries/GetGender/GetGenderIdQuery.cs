using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.GenderOperations.Queries
{
    public class GetGenderIdQuery : IRequest<IdentificationGenderVm>
    {
        //Recepcion de Id gender ingresado para la busqueda de los datos en tabla
        public int GenderId { get; set; }
        public GetGenderIdQuery(int GenderId)
        {
            this.GenderId = GenderId;
        }

    }
    public class GetGenderIdQueryHandler : IRequestHandler<GetGenderIdQuery, IdentificationGenderVm>
    {
        //Interfaz de DbContext
        private readonly IPersonDbContext _context;

        public GetGenderIdQueryHandler(IPersonDbContext context)
        {
            _context = context;
        }
        public async Task<IdentificationGenderVm> Handle(GetGenderIdQuery request, CancellationToken cancellationToken)
        {

            //Se colocara (donde esta country), la tabla deseada para definir los parametros a mostrar.
            var list = await _context.Gender.Where(x => x.Id == request.GenderId).Select(x => new IdentificationGenderDto
            {
                Id = x.Id,
                Description = x.Description,
            }).ToListAsync();

            IdentificationGenderVm vm = new IdentificationGenderVm { idGenderList = list };
            return vm;
        }
    }
}
