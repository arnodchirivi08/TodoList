
namespace TodoTdd
{
    public class ValidadorComando
    {
        public bool EsValido(string opcion)
        {
            return opcion == "S" || opcion == "s" || opcion == "A";
        }
    }
}