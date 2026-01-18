
using FluentAssertions;

namespace TodoTdd.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void Debe_EstarVacia_CuandoSeCreaUnaListaDeTareas()
        {
            var todo = new Todo();

            List<string> tareas = todo.ObtenerTareas();

            tareas.Should().BeEmpty();
        }
        //[Fact]
        //public void Debe_TenerUnaTarea_CuandoSeAgregaUnaTareaAListaVacia()
        //{
        //    // Arrange (Dado)
        //    var todo = new Todo();
        //    var tareaAAgregar = "Tarea 1";

        //    // Act (Cuando)
        //    todo.AgregarTarea(tareaAAgregar);
        //    List<string> tareas = todo.ObtenerTareas();

        //    // Assert (Entonces)
        //    tareas.Should().Contain(tareaAAgregar);
        //    tareas.Should().HaveCount(1);
        //}
    }

    public class Todo
    {
        public Todo()
        {
        }

        internal List<string> ObtenerTareas()
        {
            throw new NotImplementedException();
        }
    }
}
