using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HorasExtras.Application.HorasExtra.MisSolicitudes
{
    public class MisSolicitudesQuery: IRequest<IEnumerable<SolicitudesHorasExtraDto>>
    {
        [Required]
        public string ColaboradorId { get; set; }
    }
}
