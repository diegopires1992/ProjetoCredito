using LiberacaoDeCredito.Display;
using System;

namespace LiberacaoDeCredito
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var opcaoRecebida = "";

      while (opcaoRecebida != "2")
      {
        Menus.MenuOpcoesEntrada();

        opcaoRecebida = Console.ReadLine();

        LeituraDaOpcao(opcaoRecebida);
      }

      Console.Read();
    }

    public static void LeituraDaOpcao(string opcaoRecebida)
    {

      switch (opcaoRecebida.ToUpper())
      {
        case "1":
          LiberacaoDeCredito.AnaliseDeCredito();
          break;
        case "2":
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Opção inválida");
          break;
      }
    }
  }
}
