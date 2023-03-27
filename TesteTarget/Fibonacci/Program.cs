/*
 * 2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores 
 * (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, 
 * ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.
 */

try
{
    var numero = ObterNumero();
    var sequenciaFibonacci = CriarSequenciaFibonacci(numero);
    bool numeroPertenceASequencia = false;

    foreach(var n in sequenciaFibonacci)
    {
        if (n == numero)
            numeroPertenceASequencia = true;
    }

    if(numeroPertenceASequencia)
        Console.WriteLine($"{numero} pertence a sequência Fibonacci");
    else
        Console.WriteLine($"{numero} não pertence a sequência Fibonacci");


    Console.WriteLine("Tecle para sair.");
    Console.ReadKey();

}
catch(Exception ex)
{
    Console.WriteLine($"Ocorreu um erro ao calcular a sequência Fibonacci: {ex.Message} - {ex.StackTrace}");
}

List<int> CriarSequenciaFibonacci(int numero)
{
    List<int> sequencia = new() { 0, 1}; //lista iniciada com os valores iniciais da sequência

    for (int i = sequencia.Count; i <= numero; i++)
    {
        sequencia.Add(sequencia[i - 1] + sequencia[i - 2]);
    }

    return sequencia;
}

int ObterNumero()
{
    var numero = SolicitarNumero();
    var numeroValido = int.TryParse(numero, out var num);
 
    while (!numeroValido)
    {
        Console.WriteLine("Número informado inválido. Por favor, digite um número inteiro válido. \nPressione qualquer tecla para retornar.");
        Console.ReadKey();
        Console.Clear();

        SolicitarNumero();
    }

    return int.Parse(numero);
}

string SolicitarNumero()
{
    Console.WriteLine("Informe um número e verifique se ele pertence a sequência Fibonacci.");
    Console.WriteLine();

    var numeroDigitado = Console.ReadLine();

    return numeroDigitado;
}