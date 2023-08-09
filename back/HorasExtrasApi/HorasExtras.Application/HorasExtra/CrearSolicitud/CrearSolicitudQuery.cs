using HorasExtras.Domain.Enum;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HorasExtras.Application.HorasExtra.CrearSolicitud
{
    public class CrearSolicitudQuery: IRequest
    {
        [Required]
        public string ColaboradorId { get; set; }

        [Required]
        public EnumTipoSolicitudHorasExtra TipoSolicitud { get; set; }

        [Required]
        public int CantidadDias { get; set; }

        
        [Required]
        public string Motivo { get; set; }
    }
}
