
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
            if (!validador.EsValido(instruccion)) {
                consola.WriteLine("Incorrect input");
                return;
            }
                

            string opcionSeleccionada = instruccion.ToUpper();

            switch (opcionSeleccionada)
            {
                case "S": MostrarTareas();
                    break;
                case "A": ProcesarTarea();
                    break;
                case "R": EliminarTareaDesdeConsola();
                    break;
            }
        }

        private void EliminarTareaDesdeConsola()
        {
            var indiceValido = false;

            while(!indiceValido)
            {
                consola.WriteLine("Select the index of the TODO you want to remove:");

                var opcionSeleccionadaUsuario = consola.ReadLine();

                if (string.IsNullOrEmpty(opcionSeleccionadaUsuario))
                {
                    consola.WriteLine("Selected index cannot be empty");
                    continue;
                }

                indiceValido = true;
                var indiceTarea = int.Parse(opcionSeleccionadaUsuario) - 1;
                listaDeTareas.EliminarTarea(indiceTarea, out string tareaEliminada);              
                consola.WriteLine($"TODO removed: [{tareaEliminada}]");
            }
           
        }

        private void ProcesarTarea()
        {
            consola.WriteLine("Enter the TODO description:");
            string tarea = consola.ReadLine();

            var tareas = listaDeTareas.ObtenerTareas();
       

            if (string.IsNullOrEmpty(tarea))
            {
                consola.WriteLine("The description cannot be empty.");
                return;
            }

            if (listaDeTareas.Existe(tarea))
            {
                consola.WriteLine("The_description_must_be_unique.");
                return;
            }

            AgregarTareaALista(tarea);
        }

        private void AgregarTareaALista(string tarea)
        {
            listaDeTareas.AgregarTarea(tarea);
            consola.WriteLine($"TODO successfully added: {tarea}");
        }

        private void MostrarTareas()
        {
            var tareas = listaDeTareas.ObtenerTareas();
            var cantidadTareas = tareas.Count;

            if(cantidadTareas == 0)
                consola.WriteLine("No TODOs have been added yet");

            for (int i = 0; i < cantidadTareas; i++)
            {
                consola.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }

        public void Ejecutar()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenu();
                string instruccion = LeerInstrucion();

                if (instruccion?.ToUpper() == "E")
                {
                    continuar = false;
                }
                else
                {
                    ProcesarInstruccion(instruccion);
                }
            }
        }
    }
}