
using FluentAssertions;

namespace TodoTdd.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void Debe_EstarVacia_CuandoSeCreaUnaListaDeTareas()
        {
            var todo = new ListaDeTareas();

            List<string> tareas = todo.ObtenerTareas();

            tareas.Should().BeEmpty();
        }
    }

    public class ListaDeTareas
    {
        public ListaDeTareas()
        {
        }

        public List<string> ObtenerTareas()
        {
            return new List<string>();
        }
    }
}
