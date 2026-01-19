
using FluentAssertions;
using System.Threading;

namespace TodoTdd.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void Debe_EstarVacia_CuandoSeCreaUnaListaDeTareas()
        {
            var todo = new ListaDeTareas();

            var tareas = todo.ObtenerTareas();

            tareas.Should().BeEmpty();
        }


        [Fact]
        public void Debe_TenerUnaTarea_CuandoSeAgregaUnaATareaAListaVacia()
        {
            var listaDeTareas = new ListaDeTareas();
            var tarea = "Tarea 1";

            listaDeTareas.AgregarTarea(tarea);

            var tareas = listaDeTareas.ObtenerTareas();
            tareas.Should().Contain(tarea);
        }

        [Fact]
        public void Debe_GenerarUnaAlertaDeError_CuandoLaDescripcionDeLatareaEsVacia()
        {
            var listaDeTareas = new ListaDeTareas();

            Action accion = () => listaDeTareas.AgregarTarea("");

            accion.Should().Throw<ArgumentException>().WithMessage("La descripción no puede estar vacia");
        }

        [Fact]
        public void Debe_GenerarUnaAlertaDeError_CuandoLaDescripcionDeLatareaYaExiste()
        {
            var listaDeTareas = new ListaDeTareas();
            var tarea = "Tarea 1";

            listaDeTareas.AgregarTarea(tarea);
            Action accion = () => listaDeTareas.AgregarTarea(tarea);

            accion.Should().Throw<ArgumentException>().WithMessage("La descripción no puede ser duplicada");
        }

        [Fact]
        public void Debe_EliminarLaTarea_CuandoSeEnvieElIndice()
        {
            var listaDeTareas = new ListaDeTareas();
            var tarea1 = "Tarea 1";
            var tarea2 = "Tarea 2";

            listaDeTareas.AgregarTarea(tarea1);
            listaDeTareas.AgregarTarea(tarea2);

            listaDeTareas.EliminarTarea(1);

            var tareas = listaDeTareas.ObtenerTareas();

            tareas.Should().HaveCount(1);
            tareas.Should().NotContain(tarea2);
        }

        [Fact]
        public void Debe_GenerarUnaAlertaDeError_CuandoElIndiceProporcionadoNoExista()
        {
            var listaDeTareas = new ListaDeTareas();
            listaDeTareas.AgregarTarea("Tarea 1");

            Action accion = () => listaDeTareas.EliminarTarea(1);

            accion.Should().Throw<ArgumentException>().WithMessage("El indice es invalido");
        }
    }
}
