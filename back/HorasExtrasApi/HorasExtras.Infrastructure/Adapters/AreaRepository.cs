using HorasExtras.Domain.Entities;
using HorasExtras.Domain.Ports;

namespace HorasExtras.Infrastructure.Adapters
{
    public class AreaRepository : IAreaRepository
    {
        private readonly IGenericRepository<Area> _repository;

        public AreaRepository(IGenericRepository<Area> repository)
        {
            _repository = repository;
        }
        
        public async Task<Area> ObtenerAreaPorLider(Guid liderId)
        {
            var areas = await _repository.GetAsync(a => a.LiderId == liderId);
            return areas.FirstOrDefault();
        }
    }
}
