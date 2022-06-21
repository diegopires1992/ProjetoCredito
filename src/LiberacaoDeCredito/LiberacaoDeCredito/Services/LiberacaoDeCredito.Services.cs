using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiberacaoDeCredito
{
  internal class LiberacaoDeCredito
  {
    public static int? ConverteNumeroParaString(string Numero)
    {
      int outInt;
      return int.TryParse(Numero, out outInt) ? outInt : (int?)null;
    }

    public static void AnaliseDeCredito()
    {
      MenuCredito();
      var opcaoDeCredito = Console.ReadLine();

      if (ConverteNumeroParaString(opcaoDeCredito) < 0 || ConverteNumeroParaString(opcaoDeCredito) > 5)
      {
        Console.WriteLine("Valor digitado inválido");
        return;
      }

      Console.WriteLine("Favor digite o valor do crédito:");
      string ValorDoCredito = Console.ReadLine();

      if (ConverteNumeroParaString(ValorDoCredito) < 0)
      {
        Console.WriteLine("Valor digitado inválido");
        return;
      }

      if (ConverteNumeroParaString(ValorDoCredito) > 1000000)
      {
        Console.WriteLine("Valor digitado é maior que  R$ 1.000.000,00");
        return;
      }

      if (ConverteNumeroParaString(opcaoDeCredito) == 3 && ConverteNumeroParaString(opcaoDeCredito) < 15000)
      {
        Console.WriteLine("Credito para pessoas juridicas liberado valor somente a partir de  R$ 15.000,00");
        return;
      }
      Console.WriteLine("Digite a quantidade de parcelas desejada:");
      string NumeroParcelas = Console.ReadLine();

      if (ConverteNumeroParaString(NumeroParcelas) < 0 || ConverteNumeroParaString(NumeroParcelas) < 5 || ConverteNumeroParaString(NumeroParcelas) > 72)
      {
        Console.WriteLine("Quantidade de parcelas deve ser maior que 5 e menor que 72");
        return;
      }

      Console.WriteLine("Digite a Data do Vencimento:exemplo:09/09/1992");
      string inputAno = Console.ReadLine();
      var DataLimpa = ValidaData(inputAno);

      Console.WriteLine($"Digite a Data do Vencimento:exemplo:{DataLimpa}");




    }

    public static string ValidaData(string Date)
    {
      String result = DateTime
        .ParseExact(Date, "MM/dd/yyyy", CultureInfo.InvariantCulture)
        .ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

      return result;
    }

    public static void MenuCredito()
    {
      Console.WriteLine("----------------------------Liberação do Crédito------------------------------------------");
      Console.WriteLine("Favor digite o tipo de crédito:");
      Console.WriteLine("1- Credito Direto - Taxa de 2% ao mes");
      Console.WriteLine("2- Credito Consignado - Taxa de 1% ao mes");
      Console.WriteLine("3- Credito Pessoa Juridica - Taxa de 5% ao mes");
      Console.WriteLine("4- Credito Pessoa Fisica - Taxa de 3% ao mes");
      Console.WriteLine("5- Credito Imobiliario - Taxa de 9% ao ano");
    }
  }
}
