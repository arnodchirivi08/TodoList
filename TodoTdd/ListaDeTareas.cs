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
            ValidarDescripcionTarea(tarea);
            tareas.Add(tarea);
        }
        
        public void EliminarTarea(int indice, out string nombreTareaEliminada)
        {
            ValidarIndice(indice);
            tareas.RemoveAt(indice);
            nombreTareaEliminada = "";
        }
        private void ValidarIndice(int indice)
        {
            if (indice < 0 || indice >= tareas.Count)
                throw new ArgumentException("El indice es invalido");
        }
        private void ValidarDescripcionTarea(string tarea)
        {
            if (String.IsNullOrEmpty(tarea))
                throw new ArgumentException("La descripción no puede estar vacia");
            if (tareas.Contains(tarea))
                throw new ArgumentException("La descripción no puede ser duplicada");
        }

        public bool Existe(string tarea)
        {
            return tareas.Contains(tarea);
        }
    }
}
