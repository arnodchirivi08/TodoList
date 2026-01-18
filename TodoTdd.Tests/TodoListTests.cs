
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
