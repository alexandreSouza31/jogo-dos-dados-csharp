
namespace jogoDados.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int limiteLinhaChegada = 30;

            while (true)
            {
                int posicaoUsuario = 0;
                int posicaoComputador = 0;

                bool jogoEmAndamento = true;

                Console.Clear();
                Console.Write("Digite o seu nome de Usuário: ");
                string nomeJogador = Console.ReadLine()!;

                while (jogoEmAndamento) 
                {
                    Console.Clear();
                    ExibirCabeçalho();

                    var (resultadoUsuario, resultadoComputador )= RolarDado(nomeJogador);

                    posicaoUsuario += resultadoUsuario;

                    //Avanço extra: Se o competidor parar em uma posição específica(ex.: 5, 10, 15), ele avança +3 casas.
                    //Recuo: Se o competidor parar em outra posição específica(ex.: 7, 13, 20), ele recua -2 casas.
                    //Rodada extra: Se o competidor tirar 6 no dado, ele ganha uma rodada extra.


                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.WriteLine("\nParabéns! Você alcançou a linha de chegada!");
                        Console.ReadLine();
                        jogoEmAndamento = false;

                        continue;
                    }

                    else 
                    { 
                        Console.WriteLine("********************************************************");
                        Console.WriteLine($"\n{nomeJogador} está na posição: {posicaoUsuario} de {limiteLinhaChegada}.");
                    }

                    posicaoComputador += resultadoComputador;


                    if (posicaoComputador >= limiteLinhaChegada)
                    {
                        Console.WriteLine("\nQue pena o Computador alcançou a linha de chegada!");
                        Console.ReadLine() ;
                        jogoEmAndamento = false;

                        continue;
                    }
                    else Console.WriteLine($"\nO Computador está na posição: {posicaoComputador} de {limiteLinhaChegada}.");
                    Console.WriteLine("********************************************************");

                    Console.WriteLine("\nDigite Enter para continuar...");
                    Console.ReadLine();
                }

                string opcaoContinuar=ExibirMenuContinuar();

                if (opcaoContinuar != "S") break;

            }
        }

        static void ExibirCabeçalho()
        {
            //Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("      Jogo de Dados");
            Console.WriteLine("------------------------------");
        }

        static (int resultadoUsuário,int resultadoComputador) RolarDado(string nomeJogador="")
        {
            int resultadoUsuario = RodadaJogador(nomeJogador);

            Random geradorNumeros = new Random();
            Console.WriteLine("\n\nTurno do Computador:");
            Console.ReadLine();

            int resultadoComputador = geradorNumeros.Next(1, 7);
            Console.WriteLine($"\nO valor sorteado para o Computador foi {resultadoComputador}!");


            return (resultadoUsuario,resultadoComputador);
        }

        static int RodadaJogador(string nomeJogador)
        {
            Console.WriteLine($"\nTurno do(a) {nomeJogador}:");

            Random geradorNumeros = new Random();

            if (!string.IsNullOrEmpty(nomeJogador))
            {
                Console.Write("\n\nPressione Enter para rolar o dado:");
                Console.ReadLine();

            }
            int resultadoUsuario = geradorNumeros.Next(1, 7);
            Console.WriteLine($"\n\nO valor sorteado para {nomeJogador} foi {resultadoUsuario}!");

            return resultadoUsuario;
        }

        static string ExibirMenuContinuar(){
            Console.WriteLine("Deseja continuar? [s/n]");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            return opcaoContinuar;
        }
    }
}