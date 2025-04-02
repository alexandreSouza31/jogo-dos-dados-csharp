
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

                int casaAvanco = 3;

                bool jogoEmAndamento = true;

                Console.Clear();
                Console.Write("Digite o seu nome de Usuário: ");
                string nomeJogador = Console.ReadLine()!;

                while (jogoEmAndamento) 
                {
                    Console.Clear();
                    ExibirCabeçalho(nomeJogador,posicaoUsuario,posicaoComputador);

                    (posicaoUsuario, posicaoComputador) = RolarDado(nomeJogador,posicaoUsuario,posicaoComputador,casaAvanco);

                    //Recuo: Se o competidor parar em outra posição específica(ex.: 7, 13, 20), ele recua -2 casas.
                    //Rodada extra: Se o competidor tirar 6 no dado, ele ganha uma rodada extra.


                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.Clear();
                        Console.WriteLine("\nParabéns! Você alcançou a linha de chegada!");
                        Console.ReadLine();
                        ExibirCabeçalho(nomeJogador, posicaoUsuario, posicaoComputador);

                        jogoEmAndamento = false;

                        continue;
                    }

                    if (posicaoComputador >= limiteLinhaChegada)
                    {
                        Console.Clear();
                        Console.WriteLine("\nQue pena o Computador alcançou a linha de chegada!");
                        ExibirCabeçalho(nomeJogador, posicaoUsuario, posicaoComputador);
                        Console.ReadLine() ;
                        jogoEmAndamento = false;

                        continue;
                    }

                    Console.WriteLine("\nDigite Enter para continuar...");
                    Console.ReadLine();
                }

                string opcaoContinuar=ExibirMenuContinuar();

                if (opcaoContinuar != "S") break;

            }
        }

        static void ExibirCabeçalho(string nomeJogador, int posicaoUsuario, int posicaoComputador)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("      Jogo de Dados");
            Console.WriteLine($"\n Nome do jogador: {nomeJogador}");
            Console.WriteLine($"Posição do jogador: {posicaoUsuario}\t\tPosição do Computador: {posicaoComputador}");
            Console.WriteLine("------------------------------------------------------------");
        }

        static (int , int ) RolarDado(string nomeJogador, int posicaoUsuario, int posicaoComputador, int casaAvanco)
        {
            posicaoUsuario = RodadaJogador(nomeJogador, posicaoUsuario,casaAvanco);

            Random geradorNumeros = new Random();
            Console.WriteLine("\n\nTurno do Computador:");
            Console.ReadLine();

            int resultadoComputador = geradorNumeros.Next(1, 7);
            Console.WriteLine($"\nO valor sorteado para o Computador foi {resultadoComputador}!");
            posicaoComputador += resultadoComputador;

            //Avanço extra: Se o competidor parar em uma posição específica(ex.: 5, 10, 15), ele avança +3 casas.
            if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15)
            {
                Console.WriteLine($"Parou na casa {posicaoComputador}. O Computador avançará {casaAvanco} casas!");
                posicaoComputador += casaAvanco;
            }

            return (posicaoUsuario, posicaoComputador);
        }

        static int RodadaJogador(string nomeJogador, int posicaoUsuario, int casaAvanco)
           
        {
            Console.WriteLine($"\nTurno do(a) {nomeJogador}:");

            Random geradorNumeros = new Random();

            if (!string.IsNullOrEmpty(nomeJogador))
            {
                Console.Write("\nPressione Enter para rolar o dado:");
                Console.ReadLine();

            }
            int resultadoUsuario = geradorNumeros.Next(1, 7);
            posicaoUsuario += resultadoUsuario;
            Console.WriteLine($"\n\nO valor sorteado para {nomeJogador} foi {resultadoUsuario}!");

            //Avanço extra: Se o competidor parar em uma posição específica(ex.: 5, 10, 15), ele avança +3 casas.
            if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15)
            {
                Console.WriteLine($"Parou na casa {posicaoUsuario}. Você avançará {casaAvanco} casas, {nomeJogador}!");
                posicaoUsuario += casaAvanco;
                Console.ReadLine();
            }


            return posicaoUsuario;
        }

        static string ExibirMenuContinuar(){
            Console.WriteLine("Deseja continuar? [s/n]");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            return opcaoContinuar;
        }
    }
}