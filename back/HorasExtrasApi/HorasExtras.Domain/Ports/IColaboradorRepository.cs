using HorasExtras.Domain.Entities;

namespace HorasExtras.Domain.Ports
{
    public interface IColaboradorRepository
    {
        Task<Colaborador> ObtenerColaborador(Guid? id, string propiedades = null);
        Task<Colaborador> AgregarColaborador(Colaborador empleado);
        Task<List<Colaborador>> ObtenerLideres();
        Task<Area> ObtenerAreaColaborador(Colaborador colaborador);
        Task<Colaborador> ObtenerColaboradorPorUsuario(Guid usuarioId);
    }
}
