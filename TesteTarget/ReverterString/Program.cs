/*
 * 5) Escreva um programa que inverta os caracteres de um string.

IMPORTANTE:
a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
b) Evite usar funções prontas, como, por exemplo, reverse;

 */

var str = string.Empty;
try
{
    while (str.Length == 0)
    {
        Console.WriteLine("Informe a palavra ou frase que deseja reverter.");
        str = Console.ReadLine();

        Console.WriteLine();

        if (str!.Length != 0 && !string.IsNullOrWhiteSpace(str))
        {
            Console.WriteLine("Aqui está sua string revertida:");
            Console.WriteLine(ReverterString(str));
        }
        else
        {
            Console.WriteLine("Por favor, informe uma palavra/frase válida para ser revertida.");
            Console.WriteLine("Pressione qualquer tecla para retornar.");
            Console.ReadKey();

            str = string.Empty;

            Console.Clear();
        }
    }
}
catch(Exception ex)
{
    Console.WriteLine($"Ocorreu um erro ao reverter a string: {ex.Message} - {ex.StackTrace}");
}


string ReverterString(string str)
{
    var stringRevertida = string.Empty;

    for(int i = str.Length - 1; i >= 0; i--)
        stringRevertida += str[i];

    return stringRevertida;
}
