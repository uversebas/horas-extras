using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Domain.Utils
{
    public class RespuestaPaginada<T>
    {
        public IEnumerable<T> Items { get; set; } = default!;
        public int Total { get; set; }
    }
}
