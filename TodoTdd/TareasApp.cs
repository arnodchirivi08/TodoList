


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
            return consola.ReadLine();
        }

        public void MostrarMenu()
        {
            consola.WriteLine("Hello");
            consola.WriteLine("[S]ee all TODOs");
            consola.WriteLine("[A]dd a TODO");
            consola.WriteLine("[R]emove a TODO");
            consola.WriteLine("[E]xit");
        }

        public void ProcesarInstruccion(string instruccion)
        {
            if (!validador.EsValido(instruccion))
                consola.WriteLine("Incorrect input");

            if (instruccion.ToUpper() == "S")
            {
                MostrarTareas();
            }
        }

        private void MostrarTareas()
        {
            var tareas = listaDeTareas.ObtenerTareas();
            var cantidadTareas = tareas.Count;

            if(cantidadTareas > 0)
            {
                for (int i = 0; i < cantidadTareas; i++)
                {
                    consola.WriteLine($"{i + 1}. {tareas[i]}");
                }
            }
            else
            {
                consola.WriteLine("No TODOs have been added yet");
            }
         
        }
    }
}