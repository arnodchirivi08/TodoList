using FluentAssertions;

namespace TodoTdd.Tests
{
    public class ValidadorComandoTest
    {
        [Fact]
        public void Debe_SerComandoValido_CuandoEs_S()
        {
            var validador = new ValidadorComando();

            bool resultado = validador.EsValido("S");

            resultado.Should().BeTrue();
        }


        [Fact]
        public void Debe_SerComandoValido_CuandoEs_s_minuscula()
        {
            var validador = new ValidadorComando();

            bool resultado = validador.EsValido("s");

            resultado.Should().BeTrue();
        }

        [Fact]
        public void Debe_SerComandoValido_CuandoEs_A()
        {
            var validador = new ValidadorComando();

            bool resultado = validador.EsValido("A");

            resultado.Should().BeTrue();
        }

        [Fact]
        public void Debe_SerComandoValido_CuandoEs_a_minuscula()
        {
            var validador = new ValidadorComando();

            bool resultado = validador.EsValido("a");

            resultado.Should().BeTrue();
        }

        [Fact]
        public void Debe_SerComandoValido_CuandoEs_R()
        {
            var validador = new ValidadorComando();

            bool resultado = validador.EsValido("R");

            resultado.Should().BeTrue();
        }

        [Fact]
        public void Debe_SerComandoValido_CuandoEs_r_minuscula()
        {
            var validador = new ValidadorComando();

            bool resultado = validador.EsValido("r");

            resultado.Should().BeTrue();
        }
    }
}
