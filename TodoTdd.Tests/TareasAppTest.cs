using FluentAssertions;
using Moq;
using System;

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

        [Theory]
        [InlineData("Lavar loza")]
        [InlineData("Lavar ropa")]
        public void Debe_MostrarUnMensaje_CuandoSeAgregueUnaNuevaTarea(string tarea)
        {
            var consolaMock = new Mock<IConsole>();
            consolaMock.Setup(c => c.ReadLine()).Returns(tarea);

            var listadoTareas = new ListaDeTareas();
            var validador = new ValidadorComando();
            var aplicacion = new TareasApp(consolaMock.Object, listadoTareas, validador);
      

            aplicacion.ProcesarInstruccion("A");


            consolaMock.Verify(c => c.WriteLine("Enter the TODO description:"), Times.Once);
            consolaMock.Verify(c => c.ReadLine(), Times.Once);
            consolaMock.Verify(console => console.WriteLine($"TODO successfully added: {tarea}"), Times.Once());

            listadoTareas.ObtenerTareas().Should().Contain(tarea);
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

        [Fact]
        public void DebeMostrarMensajeDe_The_description_must_be_unique_CuandoExistaUnaTareaConEseMismoNombre()
        {
            string tareaDuplicada = "Lavar el carro";
            var consolaMock = new Mock<IConsole>();
            consolaMock.Setup(c => c.ReadLine()).Returns(tareaDuplicada);

            var listadoTareas = new ListaDeTareas();
            listadoTareas.AgregarTarea(tareaDuplicada);

            var validador = new ValidadorComando();
            var aplicacion = new TareasApp(consolaMock.Object, listadoTareas, validador);

            aplicacion.ProcesarInstruccion("A");
            consolaMock.Verify(c => c.WriteLine("Enter the TODO description:"), Times.Once);

            consolaMock.Verify(console => console.WriteLine("The_description_must_be_unique."), Times.Once());
        }


        [Fact]
        public void DebeEliminarLaTareaNumero2DelListado_CuandoSeEjecuteElMetodo_EliminarTareaDesdeConsola_MostrarEnConsolaElMensajeQueEliminoLaTarea()
        {
            var tareaAEliminar = "Tarea 1";
            var consolaMock = new Mock<IConsole>();
            consolaMock.Setup(c => c.ReadLine()).Returns("1");

            var listadoTareas = new ListaDeTareas();
            listadoTareas.AgregarTarea(tareaAEliminar);
            listadoTareas.AgregarTarea("Tarea 2");

            var validador = new ValidadorComando();
            
            var aplicacion = new TareasApp(consolaMock.Object, listadoTareas, validador);

            aplicacion.ProcesarInstruccion("R");

            consolaMock.Verify(c => c.WriteLine("Select the index of the TODO you want to remove:"));
            consolaMock.Verify(c => c.WriteLine($"TODO removed: [{tareaAEliminar}]"));

            listadoTareas.ObtenerTareas().Should().NotContain(tareaAEliminar);
		}

        [Fact]
        public void Debe_LanzarELMensajeDeError_Selected_index_cannot_be_empty_CuandoSeEnvieUnaDescripcionVaciaYVolverAImprimerMensajeDeSolicitudEliminacion()
        { 
            
            var consolaMock = new Mock<IConsole>();
            consolaMock.SetupSequence(c => c.ReadLine()).Returns("").Returns("1");

            var listadoTareas = new ListaDeTareas();
            listadoTareas.AgregarTarea("Tarea 2");

            var validador = new ValidadorComando();

            var aplicacion = new TareasApp(consolaMock.Object, listadoTareas, validador);

            aplicacion.ProcesarInstruccion("R");

            consolaMock.Verify(c => c.WriteLine("Selected index cannot be empty"));
            consolaMock.Verify(c => c.WriteLine("Select the index of the TODO you want to remove:"), Times.Exactly(2));
        }

        [Fact]
        public void Debe_SalirDelBucle_CuandoElUsuarioIngreseLaOpcion_E()
        {
            var consolaMock = new Mock<IConsole>();
            consolaMock.Setup(c => c.ReadLine()).Returns("E");

            var listadoTareas = new ListaDeTareas();
            var validador = new ValidadorComando();
            var aplicacion = new TareasApp(consolaMock.Object, listadoTareas, validador);

            aplicacion.Ejecutar();

            consolaMock.Verify(c => c.WriteLine("Hello"), Times.Once());
        }

        [Fact]
        public void Debe_MostrarElMenu_YProcesarInstrucciones_HastaQueElUsuarioIngrese_E()
        {
            var consolaMock = new Mock<IConsole>();
            consolaMock.SetupSequence(c => c.ReadLine())
                .Returns("A")
                .Returns("Comprar pan")
                .Returns("S")
                .Returns("E");

            var listadoTareas = new ListaDeTareas();
            var validador = new ValidadorComando();
            var aplicacion = new TareasApp(consolaMock.Object, listadoTareas, validador);

            aplicacion.Ejecutar();

            consolaMock.Verify(c => c.WriteLine("Hello"), Times.Exactly(3));
            consolaMock.Verify(c => c.WriteLine("1. Comprar pan"), Times.Once());
        }
    }
}
