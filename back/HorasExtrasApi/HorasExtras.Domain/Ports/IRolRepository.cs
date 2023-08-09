using HorasExtras.Domain.Entities;

namespace HorasExtras.Domain.Ports
{
    public interface IRolRepository
    {
        Task<Rol> ObtenerRol(Guid id);
    }
}
