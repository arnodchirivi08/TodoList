
namespace TodoTdd
{
    public class ValidadorComando
    {
        public bool EsValido(string opcion)
        {
            string[] comandosAceptados = ["S", "A", "R"];
            return comandosAceptados.Contains(opcion.ToUpper());
        }
    }
}