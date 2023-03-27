/*
 * 3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
• O menor valor de faturamento ocorrido em um dia do mês;
• O maior valor de faturamento ocorrido em um dia do mês;
• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.
*/

using FaturamentoDiario.ViewModels;
using Newtonsoft.Json;

namespace FaturamentoDiario.Program
{
    public class Program
    {
        static void Main()
        {
            try
            {
                var listaFaturamento = ListarFaturamentos();
                var maiorFaturamento = BuscarMaiorFaturamento(listaFaturamento);
                var menorFaturamento = BuscarMenorFaturamento(listaFaturamento);
                var mediaFaturamento = BuscarMediaFaturamento(listaFaturamento);

                Console.WriteLine($"O maior faturamento foi em {maiorFaturamento.Data} - {maiorFaturamento.Valor:C}");
                Console.WriteLine($"O menor faturamento foi em {menorFaturamento.Data} - {menorFaturamento.Valor:C}");
                Console.WriteLine($"A média do faturamento mensal foi de {mediaFaturamento:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao retornar as informações: {ex.Message} - {ex.StackTrace}");
            }

            ViewModelFaturamentoDiario BuscarMaiorFaturamento(IEnumerable<ViewModelFaturamentoDiario> listaFaturamento)
            {
                return listaFaturamento.OrderByDescending(f => f.Valor).FirstOrDefault()!;
            }

            ViewModelFaturamentoDiario BuscarMenorFaturamento(IEnumerable<ViewModelFaturamentoDiario> listaFaturamento)
            {
                return listaFaturamento.OrderBy(f => f.Valor).FirstOrDefault()!;
            }

            double BuscarMediaFaturamento(IEnumerable<ViewModelFaturamentoDiario> listaFaturamento)
            {
                return listaFaturamento.Average(f => f.Valor)!;
            }

            IEnumerable<ViewModelFaturamentoDiario> ListarFaturamentos()
            {
                var faturamentoJson = BuscarFaturamentoDiarioJson();
                var listaFaturamento = JsonConvert.DeserializeObject<IEnumerable<ViewModelFaturamentoDiario>>(faturamentoJson)!
                                                                                                .Where(f => f.Valor > 0)
                                                                                                .ToList();

                return listaFaturamento!;
            }

            string BuscarFaturamentoDiarioJson()
            {
               
                string caminhoJson = Path.Combine(Directory.GetCurrentDirectory(), "FaturamentoDiario.json");
                var faturamentoJson = File.ReadAllText(caminhoJson);

                return faturamentoJson;
            }
        }
    }
}
