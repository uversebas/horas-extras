using HorasExtras.Domain.Ports;
using HorasExtras.Infrastructure.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace HorasExtras.Infrastructure.Extensions
{
    public static class RepositorioExtension
    {
        public static IServiceCollection InyectarRepositorio(this IServiceCollection svc)
        {
            svc.AddTransient<IUsuarioRepository, UsuarioRepository>();
            svc.AddTransient<IColaboradorRepository, ColaboradorRepository>();
            svc.AddTransient<ISolicitudHorasExtrasRepository, SolicitudHorasExtrasRepository>();
            svc.AddTransient<IRolRepository, RolRepository>();
            svc.AddTransient<IAreaRepository, AreaRepository>();
            svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return svc;
        }
    }
}
