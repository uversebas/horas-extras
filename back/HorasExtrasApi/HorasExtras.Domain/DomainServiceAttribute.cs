using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Domain
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DomainServiceAttribute: Attribute
    {
    }
}
