using HorasExtras.Application.HorasExtra.MisSolicitudes;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HorasExtras.Application.HorasExtra.SolicitudesGestionar
{
    public class SolicitudesGestionarQuery: IRequest<IEnumerable<SolicitudesHorasExtraDto>>
    {
        [Required]
        public string ColaboradorId { get; set; }
    }
}
