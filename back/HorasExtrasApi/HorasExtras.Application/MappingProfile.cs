using AutoMapper;
using HorasExtras.Application.HorasExtra.MisSolicitudes;
using HorasExtras.Application.Empleados;
using HorasExtras.Application.Empleados.Crear;
using HorasExtras.Application.Seguridad.ObtenerUsuarios;
using HorasExtras.Domain.Entities;
using HorasExtras.Application.HorasExtra.CrearSolicitud;
using HorasExtras.Domain.Dtos;
using HorasExtras.Domain.Enum;
using HorasExtras.Application.HorasExtra.AprobarSolicitud;

namespace HorasExtras.Application
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<CrearEmpleadoCommand, Colaborador>()
                .ForMember(dest=> dest.NumeroDocumento, opt=> opt.MapFrom(src=> src.NumeroDocumento))
                .ForMember(dest=> dest.Nombres, opt=> opt.MapFrom(src=> src.Nombres))
                .ForMember(dest=> dest.Apellido, opt=> opt.MapFrom(src=> src.Apellidos))
                .ForMember(dest=> dest.FechaIngreso, opt=> opt.MapFrom(src=> src.FechaIngreso))
                .ForMember(dest=> dest.AreaId, opt=> opt.MapFrom(src=> src.AreaId));
            CreateMap<Colaborador, EmpleadoDto>()
                .ForMember(dest=> dest.Nombre, opt=> opt.MapFrom(src=> src.Nombres))
                .ForMember(dest=> dest.Apellido, opt=> opt.MapFrom(src=> src.Apellido))
                .ForMember(dest=> dest.FechaIngreso, opt=> opt.MapFrom(src=> src.FechaIngreso));
            CreateMap<SolicitudHorasExtras, SolicitudesHorasExtraDto>()
                .ForMember(c => c.Tipo, opt => opt.MapFrom(src => src.Tipo.GetStringValue()))
                .ForMember(c => c.Estado, opt => opt.MapFrom(src => src.Estado.GetStringValue()))
                .ForMember(c => c.AprobacionLider, opt => opt.MapFrom(src => src.AprobacionHorasExtras.AprobacionLider.GetStringValue()))
                .ForMember(c => c.AprobacionRRHH, opt => opt.MapFrom(src => src.AprobacionHorasExtras.AprobacionRRHH.GetStringValue()))
                .ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(c => c.Dias, opt => opt.MapFrom(src => src.Dias))
                .ForMember(c => c.MotivoLider, opt => opt.MapFrom(src => src.AprobacionHorasExtras.MotivoLider))
                .ForMember(c => c.MotivoRRHH, opt => opt.MapFrom(src => src.AprobacionHorasExtras.MotivoRRHH))
                .ForMember(c => c.FechaSolicitud, opt => opt.MapFrom(src => src.FechaSolicitud));
            CreateMap<CrearSolicitudQuery, CrearSolicitudHorasExtras>();
            CreateMap<AprobarSolicitudQuery, AprobarSolicitudHorasExtras>();
        }
    }
}
