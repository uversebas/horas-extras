using HorasExtras.Domain.Entities;
using HorasExtras.Domain.Ports;

namespace HorasExtras.Infrastructure.Adapters
{
    public class ColaboradorRepository:  IColaboradorRepository
    {
        private readonly IGenericRepository<Colaborador> _repositorioColaborador;
        public ColaboradorRepository(IGenericRepository<Colaborador> repositorioEmpleado)
        {
            _repositorioColaborador= repositorioEmpleado;
        }

        public async Task<Area> ObtenerAreaColaborador(Colaborador colaborador)
        {
            var colaboradores = await _repositorioColaborador.GetAsync(registro => registro.AreaId.Equals(colaborador.AreaId), includeProperties:"Area");
            var area = colaboradores.First().Area;
            return area;
        }

        public async Task<Colaborador> ObtenerColaborador(Guid? id, string propiedades = null)
        {
            if (string.IsNullOrEmpty(propiedades))
            {
                return await _repositorioColaborador.GetByIdAsync(id);
            }

            var colaboradores = await _repositorioColaborador.GetAsync(c => c.Id == id, includeProperties: propiedades);

            return colaboradores.FirstOrDefault();
        }

        public async Task<Colaborador> AgregarColaborador(Colaborador empleado)
        {
            return await _repositorioColaborador.AddAsync(empleado);
        }

        public async Task<List<Colaborador>> ObtenerLideres()
        {
            var lideres = await _repositorioColaborador.GetAsync();
            return lideres.ToList();
        }

        public async Task<Colaborador> ObtenerColaboradorPorUsuario(Guid usuarioId)
        {
            var colaboradores = await _repositorioColaborador.GetAsync(c => c.UsuarioId == usuarioId);
            return colaboradores.FirstOrDefault();
        }
    }
}
