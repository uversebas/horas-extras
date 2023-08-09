using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Infrastructure.Config
{
    public class JwtConfig
    {
        public string KeyJwt { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public string Subject { get; set; } = default!;
        public int DuracionEnMinutos { get; set; } = default!;
    }
}
