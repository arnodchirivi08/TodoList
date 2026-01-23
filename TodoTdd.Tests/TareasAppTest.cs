using FluentAssertions;
using Moq;

namespace TodoTdd.Tests
{
    public class TareasAppTest
    {
        [Fact]
        public void Debe_MostrarElMenuInicial_CuandoSeInicieLaAplicacion()
        {
            var consolaMock = new Mock<IConsole>();
            var listaDeTareas = new ListaDeTareas();
            var validador = new ValidadorComando();

            var aplicacion = new TareasApp(consolaMock.Object, listaDeTareas, validador);

            aplicacion.MostrarMenu();

            consolaMock.Verify(console => console.WriteLine("Hello"), Times.Once());
            consolaMock.Verify(console => console.WriteLine("[S]ee all TODOs"), Times.Once());
            consolaMock.Verify(console => console.WriteLine("[A]dd a TODO"), Times.Once());
            consolaMock.Verify(console => console.WriteLine("[R]emove a TODO"), Times.Once());
            consolaMock.Verify(console => console.WriteLine("[E]xit"), Times.Once());
        }

        [Fact]
        public void Debe_LeerElTexto_CuandoElUsarioIngreseUnaOpcion()
        {
            var consoleMock = new Mock<IConsole>();
            consoleMock.Setup(c => c.ReadLine()).Returns("S");

            var listaTareas = new ListaDeTareas();
            var validador = new ValidadorComando();
            var aplicacion = new TareasApp(consoleMock.Object, listaTareas, validador);

            string textoIngresadoUsuario = aplicacion.LeerInstrucion();

            textoIngresadoUsuario.Should().Be("S");
        }
    }
}
