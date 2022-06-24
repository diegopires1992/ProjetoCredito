using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LiberacaoDeCredito
{
  public class LiberacaoDeCredito
  {
    public static int? ConverteStringParaNumber(string Numero)
    {
      int outInt;
      return int.TryParse(Numero, out outInt) ? outInt : (int?)null;
    }

    public static void AnaliseDeCredito()
    {
      MenuCredito();
      var OpcaoDeCredito = Console.ReadLine();

      if (ConverteStringParaNumber(OpcaoDeCredito) < 0 || ConverteStringParaNumber(OpcaoDeCredito) > 5)
      {
        Console.WriteLine("Valor digitado inválido");
        return;
      }

      Console.WriteLine("Favor digite o valor do crédito:");
      string ValorDoCredito = Console.ReadLine();

      if (ConverteStringParaNumber(ValorDoCredito) < 0)
      {
        Console.WriteLine("Valor digitado inválido");
        return;
      }

      if (ConverteStringParaNumber(ValorDoCredito) > 1000000)
      {
        Console.WriteLine("Valor digitado é maior que  R$ 1.000.000,00");
        return;
      }

      if (ConverteStringParaNumber(OpcaoDeCredito) == 3 && ConverteStringParaNumber(OpcaoDeCredito) < 15000)
      {
        Console.WriteLine("Credito para pessoas juridicas liberado valor somente a partir de  R$ 15.000,00");
        return;
      }
      Console.WriteLine("Digite a quantidade de parcelas desejada:");
      string NumeroParcelas = Console.ReadLine();

      if (ConverteStringParaNumber(NumeroParcelas) < 0 || ConverteStringParaNumber(NumeroParcelas) < 5 || ConverteStringParaNumber(NumeroParcelas) > 72)
      {
        Console.WriteLine("Quantidade de parcelas deve ser maior que 5 e menor que 72");
        return;
      }

      DateTime MaisQuarenta = DateTime.Today.AddDays(40);
      DateTime MaisQuinzeDias = DateTime.Today.AddDays(15);

      Console.WriteLine($"Digite a Data do Vencimento entre {MaisQuinzeDias} e {MaisQuarenta}");
      string DataVencimento = Console.ReadLine();

      ValidaData(DataVencimento);

      DateTime DataConvertida = ConverteData(DataVencimento);

      if (VerificaDataVencimento(DataConvertida))
      {
        var TotalComJurosCompostos = CalculaJurosCompostos(ValorDoCredito, NumeroParcelas, OpcaoDeCredito);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine(" Status do crédito : APROVADO");
        Console.WriteLine($" Valor total com juros : {NormalizaçãoDecimal(TotalComJurosCompostos)}");
        Console.WriteLine($" Valor do Juros : {NormalizaçãoDecimal(TotalComJurosCompostos - Convert.ToDecimal(ValorDoCredito))}");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Pressione Qualquer Tecla Para Retornar ao Menu");
        Console.ReadKey();
      }

    }

    public static string NormalizaçãoDecimal(decimal Numero)
    {
      Decimal NumeroSemArredondamento = Math.Truncate(Numero * 100) / 100;
      return NumeroSemArredondamento.ToString();
    }


    public static void ValidaData(string Date)
    {
      DateTime resultado = DateTime.MinValue;

      if (!DateTime.TryParse(Date.Trim(), out resultado))
      {

        Console.WriteLine("Data esta inválida");
        return;
      }
    }

    public static bool VerificaDataVencimento(DateTime DataConvertida)
    {
      DateTime MaisQuarenta = DateTime.Today.AddDays(40);
      DateTime MaisQuinzeDias = DateTime.Today.AddDays(15);

      if (DateTime.Today > DataConvertida.Date || MaisQuinzeDias.Date < DataConvertida.Date && MaisQuarenta.Date < DataConvertida.Date)
      {
        Console.WriteLine($"Data para solicitação pode ser atendida entre  {MaisQuinzeDias}  e {MaisQuarenta} ");
        Console.WriteLine("  A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo,D+40 (Dia atual + 40 dias)");
        return false;
      }
      return true;
    }

    public static DateTime ConverteData(string Date)
    {
      DateTime resultado = DateTime.ParseExact(Date, "dd/MM/yyyy", null);
      var formatadaParaBanco = String.Format("{0:yyyy-MM-dd}", resultado);
      DateTime formatadaDatetime = DateTime.ParseExact(formatadaParaBanco, "yyyy-MM-dd", null);
      return resultado;
    }

    public static decimal CalculaJurosCompostos(string ValorEmprestimo, string Parcelas, string OpcaoDeCredito)
    {
      double TaxaJuros;
      double ValorEmprestimoConvertido = double.Parse(ValorEmprestimo, CultureInfo.InvariantCulture);
      double NumeroDeMeses = double.Parse(Parcelas);

      switch (OpcaoDeCredito.ToUpper())
      {
        case "1":
          TaxaJuros = TaxaJuros = 2d / 100d;
          return Convert.ToDecimal(ValorEmprestimoConvertido * Math.Pow((1 + TaxaJuros), NumeroDeMeses));

        case "2":
          TaxaJuros = TaxaJuros = 1d / 100d;
          return Convert.ToDecimal(ValorEmprestimoConvertido * Math.Pow((1 + TaxaJuros), NumeroDeMeses));

        case "3":
          TaxaJuros = TaxaJuros = 5d / 100d;
          return Convert.ToDecimal(ValorEmprestimoConvertido * Math.Pow((1 + TaxaJuros), NumeroDeMeses));

        case "4":
          TaxaJuros = TaxaJuros = 3d / 100d;
          return Convert.ToDecimal(ValorEmprestimoConvertido * Math.Pow((1 + TaxaJuros), NumeroDeMeses));

        case "5":
          TaxaJuros = TaxaJuros = 9d / 100d;
          double Ano = 12;
          return Convert.ToDecimal(ValorEmprestimoConvertido * Math.Pow((1 + TaxaJuros), NumeroDeMeses / Ano));

        default:
          Console.WriteLine("Opção de credito inválida");
          return 1;
      }
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
