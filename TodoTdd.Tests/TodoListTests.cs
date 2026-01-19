
using FluentAssertions;

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
    }
}
