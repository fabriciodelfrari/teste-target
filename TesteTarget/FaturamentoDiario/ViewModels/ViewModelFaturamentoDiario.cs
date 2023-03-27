
namespace FaturamentoDiario.ViewModels
{
    public class ViewModelFaturamentoDiario
    {
        public DateTime Data { get; set; }
        public double Valor { get; set; }

        public ViewModelFaturamentoDiario(DateTime data, double valor)
        {
            Data = data;
            Valor = valor;
        }
    }
}
