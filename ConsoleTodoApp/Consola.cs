
using TodoTdd;

namespace ConsoleTodoApp
{
    public class Consola : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public void WriteLine(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
