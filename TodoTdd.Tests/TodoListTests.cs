
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
        public void Deberia_TenerUnaTarea_CuandoSeAgregaUnaATareaAListaVacia()
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

    public class ListaDeTareas
    {
        private List<string> tareas = new List<string>();

        public IReadOnlyList<string> ObtenerTareas()
        {
            return tareas.AsReadOnly();
        }

        public void AgregarTarea(string tarea)
        {
            if (String.IsNullOrEmpty(tarea))
                throw new ArgumentException("La descripción no puede estar vacia");

            tareas.Add(tarea);
        }
    }
}
