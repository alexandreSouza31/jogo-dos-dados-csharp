
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
                
                Console.Write("Digite o seu nome de Usuário: ");
                string nomeJogador = Console.ReadLine()!;

                while (jogoEmAndamento) 
                {
                    Console.Clear();
                    ExibirCabeçalho();

                    var (resultadoUsuario, resultadoComputador )= RolarDado(nomeJogador);

                    posicaoUsuario += resultadoUsuario;


                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.WriteLine("\nParabéns! Você alcançou a linha de chegada!");
                        Console.ReadLine();
                        jogoEmAndamento = false;

                        continue;
                    }
                    else Console.WriteLine($"\nO jogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}.");

                    Console.Write("\nDigite Enter para continuar...");
                    Console.ReadLine();

                    posicaoComputador += resultadoComputador;


                    if (posicaoComputador >= limiteLinhaChegada)
                    {
                        Console.WriteLine("\nQue pena o Computador alcançou a linha de chegada!");
                        Console.ReadLine() ;
                        jogoEmAndamento = false;

                        continue;
                    }
                    else Console.WriteLine($"\nO Computador está na posição: {posicaoComputador} de {limiteLinhaChegada}.");
                    Console.WriteLine("------------------------------");

                    Console.WriteLine("\nDigite Enter para continuar...");
                    Console.ReadLine();
                }

                string opcaoContinuar=ExibirMenuContinuar();

                if (opcaoContinuar != "s") break;

            }
        }

        static void ExibirCabeçalho()
        {
            //Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("      Jogo  de Dados");
        }

        static (int resultadoUsuário,int resultadoComputador) RolarDado(string nomeJogador="")
        {
            bool vezJogador = true;

            Console.WriteLine($"\n\nTurno do(a) {nomeJogador}:");

            Random geradorNumeros = new Random();

            if (!string.IsNullOrEmpty(nomeJogador))
            {
                Console.Write("\n\nPressione Enter para rolar o dado:");
                Console.ReadLine();
                
            }
            int resultadoUsuario = geradorNumeros.Next(1, 7);
            Console.WriteLine($"\n\nO valor sorteado para {nomeJogador} foi {resultadoUsuario}!");

            vezJogador = false;
            Console.WriteLine("\n\nTurno do Computador:");
            int resultadoComputador = geradorNumeros.Next(1, 7);
            Console.WriteLine($"\n\nO valor sorteado para o Computador foi {resultadoComputador}!");


            return (resultadoUsuario,resultadoComputador);
        }

        static string ExibirMenuContinuar(){
            Console.WriteLine("Deseja continuar? [s/n]");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();//essa exclamação diz pro VS não reclamar

            return opcaoContinuar;
        }
    }
}