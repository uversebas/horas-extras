using HorasExtras.Domain.Ports;
using HorasExtras.Domain.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HorasExtras.Domain.Test.Colaborador
{
    public class ColaboradorServiceTest
    {
        private readonly IColaboradorRepository _repositorioColaborador;
        private readonly IRolRepository _rolRepository;
        private readonly EmpleadoServices _empleadoServices;

        public ColaboradorServiceTest()
        {
            _repositorioColaborador = Substitute.For<IColaboradorRepository>();
            _rolRepository = Substitute.For<IRolRepository>();
            _empleadoServices = new EmpleadoServices(_repositorioColaborador, _rolRepository);
        }

        [Fact]
        public async Task RegistrarNuevoColaboradorRolGerente()
        {
            var colaborador = DataBuilder.DataBuilder.ObtenerColaboradores().First();
            var rol = DataBuilder.DataBuilder.ObtenerRoles().First(r => r.Nombre == "Administrador");

            _rolRepository.ObtenerRol(Arg.Any<Guid>()).Returns(rol);
            _repositorioColaborador.ObtenerAreaColaborador(Arg.Any<Entities.Colaborador>()).Returns(new Entities.Area { });

            var nuevoColaborador = await _empleadoServices.RegistrarNuevoColaborador(colaborador, rol.Id);

            await _repositorioColaborador.DidNotReceive().ObtenerColaborador(Arg.Any<Guid>());
            await _repositorioColaborador.Received(1).AgregarColaborador(Arg.Is<Entities.Colaborador>(c => c.NumeroDocumento == colaborador.NumeroDocumento));
        }
    }
}
