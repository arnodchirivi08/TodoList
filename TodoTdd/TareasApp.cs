
namespace TodoTdd
{
    public class TareasApp
    {
        private IConsole consolaMock;
        private ListaDeTareas listaDeTareas;
        private ValidadorComando validador;

        public TareasApp(IConsole consolaMock, ListaDeTareas listaDeTareas, ValidadorComando validador)
        {
            this.consolaMock = consolaMock;
            this.listaDeTareas = listaDeTareas;
            this.validador = validador;
        }

        public void MostrarMenu()
        {
            throw new NotImplementedException();
        }
    }
}