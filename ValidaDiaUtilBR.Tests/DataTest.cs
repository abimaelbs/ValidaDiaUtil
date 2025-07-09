
namespace ValidaDiaUtilBR.Tests
{
    public class DataTest
    {        
        private readonly ValidaDiaUtil _feriados;
        public DataTest()
        {
            _feriados = new ValidaDiaUtil(2025);
        }

        [TestCase("2025-05-19", true)]
        [TestCase("2025-07-04", true)]
        [TestCase("2025-01-02", true)]
        public void EhDiaUtil_DeveRetornarVerdadeiro_ParaDatasUteis(DateTime data, bool esperado) 
            => _feriados.EhDiaUtil(data).Should().Be(esperado);        

        [TestCase("2025-02-02", true)] // Sábado (não útil)
        [TestCase("2023-01-01", true)] // Domingo Feriado (Ano Novo) 
        public void EhFinalDeSemana_DeveRetornarVerdadeiro_ParaSabadoOuDomingo(DateTime data, bool esperado) 
            => _feriados.EhFinalDeSemana(data).Should().Be(esperado);

        [TestCase("2025-01-01", false)] // Feriado (Ano Novo)
        public void EhDiaUtil_DeveRetornarFalso_ParaFeriado(DateTime data, bool esperado)
            => _feriados.EhDiaUtil(data).Should().Be(esperado);
            
        [TestCase("2025-01-25", false)]
        public void AdicionarFeriado_DeveMarcarDataComoNaoUtil(DateTime data, bool esperado)
        {
            _feriados.AdicionarFeriado(data, "Aniversário de São Paulo");

            _feriados.EhDiaUtil(data).Should().Be(esperado);            
        }

        [TestCase("2025-01-25", true)]
        public void AdicionarFeriado_DeveReconhecerDataComoFeriadoComDescricao(DateTime data, bool esperado)
        {
            _feriados.AdicionarFeriado(data, "Aniversário de São Paulo");

            bool resultado = _feriados.EhFeriado(data);

            var desc = _feriados.DescricaoFeriado(data);

            Assert.AreEqual(esperado, resultado);
        }
       
        [TestCase("2025-04-20", true)]        
        public void EhFeriado_DeveReconhecerPascoaComoFeriado(DateTime data, bool esperado)
        { 
            bool resultado = _feriados.EhFeriado(data);

            var desc = _feriados.DescricaoFeriado(data);

            Assert.AreEqual(esperado, resultado);
        }

        [TestCase("2024-03-31", true)]
        public void EhFeriado_DeveReconhecerPascoaComoFeriado_Em2024(DateTime data, bool esperado)
        {
            var validar = new ValidaDiaUtil(2024);

            bool resultado = validar.EhFeriado(data);

            var desc = validar.DescricaoFeriado(data);

            Assert.AreEqual(esperado, resultado);
        }

        [TestCase("2025-01-01", true)]
        public void EhProximoDiaUtil_DeveRetornarVerdadeiro_ParaProximoDiaUtil(DateTime data, bool esperado)
        {            
            var resultado = _feriados.DiaUtilProximo(data);

            _feriados.EhDiaUtil(resultado).Should().Be(esperado);            
        }

        [TestCase("2025-01-01", true)]
        public void EhDiaUtil_Anterior_DeveRetornarVerdadeiro_ParaDiaAnteriorUtil(DateTime data, bool esperado)
        {
            var resultado = _feriados.DiaUtilAnterior(data);

            _feriados.EhDiaUtil(resultado).Should().Be(esperado);
        }
    }
}