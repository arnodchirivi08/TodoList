namespace TodoTdd
{
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
            if (tareas.Contains(tarea))
                throw new ArgumentException("La descripción no puede ser duplicada");

            tareas.Add(tarea);
        }
    }
}
