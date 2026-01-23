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

        [Fact]
        public void Debe_LeerElTexto_CuandoElUsarioIngreseUnaOpcionIncorrectaMostrarMensaje_Incorrect_input()
        {
            var consoleMock = new Mock<IConsole>();

            var listaTareas = new ListaDeTareas();
            var validador = new ValidadorComando();
            var aplicacion = new TareasApp(consoleMock.Object, listaTareas, validador);

            aplicacion.ProcesarInstruccion("Z");

            consoleMock.Verify(console => console.WriteLine("Incorrect input"), Times.Once());
        }


        [Fact]
        public void Debe_MostrarTodasLasTareas_CuandoElUsuarioIngreseLaInstruccion_S()
        {
            var consoleMock = new Mock<IConsole>();
            var listaTareas = new ListaDeTareas();
            listaTareas.AgregarTarea("Estudiar C");
            listaTareas.AgregarTarea("Lavar loza");

            var validador = new ValidadorComando();
            var aplicacion = new TareasApp(consoleMock.Object, listaTareas, validador);

            aplicacion.ProcesarInstruccion("S");

            consoleMock.Verify(c => c.WriteLine("1. Estudiar C"), Times.Once);
            consoleMock.Verify(c => c.WriteLine("2. Lavar loza"), Times.Once);
        }

        [Fact]
        public void Debe_MostrarElMensaje_No_TODOs_have_been_added_yet_CuandoNoHayTareas()
        {
            var consolaMock = new Mock<IConsole>();

            var listadoTareas = new ListaDeTareas();
            var validador = new ValidadorComando();

            var aplicacion = new TareasApp(consolaMock.Object,listadoTareas, validador);

            aplicacion.ProcesarInstruccion("s");

            consolaMock.Verify(c => c.WriteLine("No TODOs have been added yet"), Times.Once);
        }

        [Fact]
        public void Debe_MostrarUnMensaje_CuandoSeAgregueUnaNuevaTareaYElMenuDeOpciones()
        {
            var consolaMock = new Mock<IConsole>();
            consolaMock.Setup(c => c.ReadLine()).Returns("Lavar loza");

            var listadoTareas = new ListaDeTareas();
            var validador = new ValidadorComando();
            var aplicacion = new TareasApp(consolaMock.Object, listadoTareas, validador);
      

            aplicacion.ProcesarInstruccion("A");


            consolaMock.Verify(c => c.WriteLine("Enter the TODO description:"), Times.Once);
            consolaMock.Verify(c => c.ReadLine(), Times.Once);
            consolaMock.Verify(console => console.WriteLine("TODO successfully added: Lavar loza"), Times.Once());

            listadoTareas.ObtenerTareas().Should().Contain("Lavar loza");
        }


        [Fact]
        public void Debe_MostrarMensajeQueNoPuedeSerVaciaLaDescricpcion_CuandoLaTareaSeaVacio()
        {
            var consolaMock = new Mock<IConsole>();
            consolaMock.Setup(c => c.ReadLine()).Returns("");

            var listadoTareas = new ListaDeTareas();
            var validador = new ValidadorComando();
            var aplicacion = new TareasApp(consolaMock.Object, listadoTareas, validador);

            aplicacion.ProcesarInstruccion("A");
            consolaMock.Verify(c => c.WriteLine("Enter the TODO description:"), Times.Once);
            consolaMock.Verify(c => c.ReadLine(), Times.Once);
            consolaMock.Verify(console => console.WriteLine("The description cannot be empty."), Times.Once());
        }
    }
}
