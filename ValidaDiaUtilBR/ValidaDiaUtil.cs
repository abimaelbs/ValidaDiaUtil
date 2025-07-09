namespace ValidaDiaUtilBR
{
    public class ValidaDiaUtil
    {        
        private static int _ano { get; set; } = DateTime.Now.Year;

        private readonly Dictionary<DateTime, string> _feriados = new Dictionary<DateTime, string>();
       
        private void CarregarListaDeFeriados()
        {            
            _feriados.Add(new DateTime(_ano, 1, 1), "Ano Novo");
            _feriados.Add(CalcularCarnaval(_ano), "Carnaval");
            _feriados.Add(CalcularPascoa(_ano), "Páscoa");
            _feriados.Add(new DateTime(_ano, 4, 21), "Tiradentes");
            _feriados.Add(new DateTime(_ano, 5, 1), "Dia do Trabalho");
            _feriados.Add(new DateTime(_ano, 9, 7), "Independência do Brasil");
            _feriados.Add(new DateTime(_ano, 10, 12), "Nossa Senhora Aparecida");
            _feriados.Add(new DateTime(_ano, 11, 2), "Finados");
            _feriados.Add(new DateTime(_ano, 11, 15), "Proclamação da República");
            _feriados.Add(new DateTime(_ano, 11, 20), "Consciência Negra");
            _feriados.Add(new DateTime(_ano, 12, 25), "Natal");
        }

        /// <summary>
        /// Carrega feriados fixos do ano atual
        /// </summary>
        public ValidaDiaUtil() { CarregarListaDeFeriados(); }        

        /// <summary>
        /// Carrega feriados fixos do ano informado
        /// </summary>
        /// <param name="ano"></param>
        public ValidaDiaUtil(int ano) { _ano = ano; CarregarListaDeFeriados(); }
        
        private DateTime CalcularCarnaval(int ano)
        {
            return new DateTime(ano, 2, 25).AddDays(-47); // 47 dias antes da Páscoa
        }

        private DateTime CalcularPascoa(int ano)
        {
            // Algoritmo de Computus
            int a = ano % 19;
            int b = ano / 100;
            int c = ano % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 16;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;

            int mes = (h + l - 7 * m + 114) / 31; // Mês
            int dia = (h + l - 7 * m + 114) % 31 + 1; // Dia

            return new DateTime(ano, mes, dia);
        }

        /// <summary>
        /// Valida se a data é dia útil
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool EhDiaUtil(DateTime data)
        {
            if(EhFinalDeSemana(data) || EhFeriado(data))
                return false;
            
            return true;
        }

        /// <summary>
        /// Valida se é final de semana
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool EhFinalDeSemana(DateTime data)
        {            
            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
                return true;
            
            return false;
        }

        /// <summary>
        /// Valida se é feriado
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool EhFeriado(DateTime data)
        {
            return _feriados.ContainsKey(data.Date);            
        }

        /// <summary>
        /// Incrementa a data até encontrar um dia útil
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public DateTime DiaUtilProximo(DateTime data)
        {
            do
            {
                data = data.AddDays(1);
            } while (EhFeriado(data) || EhFinalDeSemana(data));

            return data;
        }

        /// <summary>
        /// Decrementa a data até encontrar um dia útil
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public DateTime DiaUtilAnterior(DateTime data)
        {
            do
            {
                data = data.AddDays(-1);
            } while (EhFeriado(data) || EhFinalDeSemana(data));

            return data;
        }

        /// <summary>
        /// Retorna a descrição do feriado
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string DescricaoFeriado(DateTime data)
        {
            if (_feriados.TryGetValue(data.Date, out var descricao))
            {
                return descricao;
            }
            return "Não é feriado.";
        }

        /// <summary>
        /// Adiciona feriado personalizado
        /// </summary>
        /// <param name="data"></param>
        /// <param name="descricao"></param>
        public void AdicionarFeriado(DateTime data, string descricao)
        {
            _feriados[data.Date] = descricao;
        }
    }
}
