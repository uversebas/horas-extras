using HorasExtras.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace HorasExtras.Infrastructure.Extensions
{
    public static class ServiciosExtensions
    {
        public static IServiceCollection InyectarServicios(this IServiceCollection svc)
        {
            var servicios = AppDomain.CurrentDomain.GetAssemblies()
       .Where(assembly => !assembly.FullName.StartsWith("Microsoft.VisualStudio.TraceDataCollector"));

           var serviciosDominio = servicios
              .SelectMany(s => s.GetTypes())
              .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(DomainServiceAttribute)));

            foreach (var _service in serviciosDominio)
            {
                var sInterf = _service.GetInterfaces().FirstOrDefault(i => i.FullName.Contains("Domain", StringComparison.InvariantCulture));
                if (sInterf != null)
                {
                    svc.AddTransient(sInterf, _service);
                }
                else
                {
                    svc.AddTransient(_service);
                }
            }
            return svc;
        }
    }
}
