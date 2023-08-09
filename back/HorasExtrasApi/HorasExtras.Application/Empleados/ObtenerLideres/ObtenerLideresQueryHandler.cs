using AutoMapper;
using HorasExtras.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Application.Empleados.ObtenerLideres
{


    public class ObtenerLideresQueryHandler : IRequestHandler<ObtenerLideresQuery, List<LiderDto>>
    {
        private readonly IEmpleadoService _servicioEmpleado;
        private readonly IMapper _mapper;
        public ObtenerLideresQueryHandler(IEmpleadoService servicioEmpleado, IMapper mapper)
        {
            _servicioEmpleado = servicioEmpleado;
            _mapper = mapper;
        }
        public async Task<List<LiderDto>> Handle(ObtenerLideresQuery request, CancellationToken cancellationToken)
        {
            var lideres = await _servicioEmpleado.ObtenerLideres();
            return _mapper.Map<List<LiderDto>>(lideres);
        }
    }
}
