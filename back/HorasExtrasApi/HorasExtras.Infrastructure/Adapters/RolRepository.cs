using HorasExtras.Domain.Entities;
using HorasExtras.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Infrastructure.Adapters
{
    public class RolRepository : IRolRepository
    {
        private readonly IGenericRepository<Rol> _rolRepository;

        public RolRepository(IGenericRepository<Rol> rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public Task<Rol> ObtenerRol(Guid id)
        {
            return _rolRepository.GetByIdAsync(id);
        }
    }
}
