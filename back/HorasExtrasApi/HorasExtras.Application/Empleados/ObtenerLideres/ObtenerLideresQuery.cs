using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Application.Empleados.ObtenerLideres
{
    public class ObtenerLideresQuery: IRequest<List<LiderDto>>
    {
    }
}
