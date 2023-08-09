using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Domain.Entities
{
    public class Area: EntityBase<Guid>
    {
        public string Nombre { get; set; } = default!;
        public Guid? LiderId { get; set; }
        public Colaborador Lider { get; set; }
        public ICollection<Colaborador> Empleados { get; set; }
    }
}
