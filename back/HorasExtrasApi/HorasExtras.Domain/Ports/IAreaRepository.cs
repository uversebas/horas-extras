using HorasExtras.Domain.Entities;

namespace HorasExtras.Domain.Ports
{
    public interface IAreaRepository
    {
        Task<Area> ObtenerAreaPorLider(Guid liderId);
    }
}
