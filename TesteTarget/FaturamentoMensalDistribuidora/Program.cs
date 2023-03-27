/*

4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:

SP – R$67.836,43
RJ – R$36.678,66
MG – R$29.229,88
ES – R$27.165,48
Outros – R$19.849,53

Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado 
teve dentro do valor total mensal da distribuidora.
 */


using System.Text;

Dictionary<string, decimal> faturamentosPorEstado = new()
{
    {"SP", 67836.43m},
    {"RJ", 36678.66m},
    {"MG", 29229.88m},
    {"ES", 27165.48m},
    {"Outros", 19849.53m}
};

try
{
    Console.WriteLine(PercentualPorEstado());
}
catch(Exception ex)
{
    Console.WriteLine($"Ocorreu um erro ao calcular o percentual: {ex.Message} - {ex.StackTrace}");
}

string PercentualPorEstado()
{
    StringBuilder sb = new();
    var faturamentoTotal = SomarTotalFaturamento();

    sb.AppendLine("Percentual de faturamento por estado:");

    foreach(var fat in faturamentosPorEstado)
    {
        var percentualFat = (fat.Value / faturamentoTotal) * 100;
        sb.AppendLine($"{fat.Key}: {percentualFat:f2}%");
    }

    return sb.ToString();
}

decimal SomarTotalFaturamento()
{
    return faturamentosPorEstado.Sum(f => f.Value); 

}