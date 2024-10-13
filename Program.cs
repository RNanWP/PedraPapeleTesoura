using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Jogador
{
    public string Nome { get; set; }
    public int Escolha { get; set; }
}

class Program
{
    const int PEDRA = 1;
    const int PAPEL = 2;
    const int TESOURA = 3;

    static void Main(string[] args)
    {
        Jogador jogador1 = new Jogador();
        Jogador jogador2 = new Jogador();
        string resultado;

        Console.Write("Informe o nome do Jogador 1: ");
        jogador1.Nome = Console.ReadLine();

        Console.Write("Informe o nome do Jogador 2: ");
        jogador2.Nome = Console.ReadLine();

        do
        {
            jogador1.Escolha = EscolherOpcao(jogador1.Nome);
            jogador2.Escolha = EscolherOpcao(jogador2.Nome);

            resultado = VerificarVencedor(jogador1, jogador2);

            if (resultado == "Empate")
            {
                Console.WriteLine("Empate! O jogo será reiniciado.\n");
            }

        } while (resultado == "Empate");

        Console.WriteLine(resultado);
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    static int EscolherOpcao(string nome)
    {
        int escolha;
        do
        {
            Console.WriteLine($"{nome}, escolha 1 para PEDRA, 2 para PAPEL, 3 para TESOURA:");
            escolha = int.Parse(Console.ReadLine());
        } while (escolha < 1 || escolha > 3);

        return escolha;
    }

    static string VerificarVencedor(Jogador jogador1, Jogador jogador2)
    {
        if (jogador1.Escolha == jogador2.Escolha)
        {
            return "Empate";
        }

        if ((jogador1.Escolha == PEDRA && jogador2.Escolha == TESOURA) ||
            (jogador1.Escolha == PAPEL && jogador2.Escolha == PEDRA) ||
            (jogador1.Escolha == TESOURA && jogador2.Escolha == PAPEL))
        {
            return $"{jogador1.Nome} venceu! {Verbo(jogador1.Escolha)} {Verbo(jogador2.Escolha)}.";
        }
        else
        {
            return $"{jogador2.Nome} venceu! {Verbo(jogador2.Escolha)} {Verbo(jogador1.Escolha)}.";
        }
    }

    static string Verbo(int escolha)
    {
        switch (escolha)
        {
            case PEDRA: return "PEDRA quebra";
            case PAPEL: return "PAPEL cobre";
            case TESOURA: return "TESOURA corta";
            default: return "";
        }
    }
}