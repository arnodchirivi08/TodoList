

namespace TodoTdd
{
    public class TareasApp
    {
        private IConsole consola;
        private ListaDeTareas listaDeTareas;
        private ValidadorComando validador;

        public TareasApp(IConsole consola, ListaDeTareas listaDeTareas, ValidadorComando validador)
        {
            this.consola = consola;
            this.listaDeTareas = listaDeTareas;
            this.validador = validador;
        }

        public string LeerInstrucion()
        {
            throw new NotImplementedException();
        }

        public void MostrarMenu()
        {
            consola.WriteLine("Hello");
            consola.WriteLine("[S]ee all TODOs");
            consola.WriteLine("[A]dd a TODO");
            consola.WriteLine("[R]emove a TODO");
            consola.WriteLine("[E]xit");
        }
    }
}