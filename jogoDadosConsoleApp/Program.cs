
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
                int casaRecuo = 2;
                int rodadaExtra = 6;

                bool jogoEmAndamento = true;

                Console.Clear();
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("      Jogo de Dados");
                Console.WriteLine("------------------------------------------------------------");
                Console.Write("Digite o seu nome de Usuário: ");
                string nomeJogador = Console.ReadLine()!;

                while (jogoEmAndamento) 
                {
                    Console.Clear();
                    ExibirCabeçalho(nomeJogador,posicaoUsuario,posicaoComputador);

                    (posicaoUsuario, posicaoComputador) = RolarDado(nomeJogador,posicaoUsuario,posicaoComputador,casaAvanco,casaRecuo, rodadaExtra);

                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.Clear();
                        Console.WriteLine("\nParabéns! Você alcançou a linha de chegada!");
                        ExibirCabeçalho(nomeJogador, posicaoUsuario, posicaoComputador);

                        jogoEmAndamento = false;

                        continue;
                    }

                    if (posicaoComputador >= limiteLinhaChegada)
                    {
                        Console.Clear();
                        Console.WriteLine("\nQue pena o Computador alcançou a linha de chegada!");
                        ExibirCabeçalho(nomeJogador, posicaoUsuario, posicaoComputador);
                        jogoEmAndamento = false;

                        continue;
                    }

                    Console.WriteLine("\nPressione Enter para continuar...");
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

        static (int , int ) RolarDado(string nomeJogador, int posicaoUsuario, int posicaoComputador, int casaAvanco, int casaRecuo, int numeroRodadaExtra)
        {

            int resultadoUsuario, resultadoComputador;
            (posicaoUsuario, resultadoUsuario) = RodadaJogador(nomeJogador, posicaoUsuario, casaAvanco, casaRecuo);
            (posicaoComputador, resultadoComputador) = RodadaComputador(posicaoComputador, casaAvanco, casaRecuo);

            while (resultadoUsuario == numeroRodadaExtra)
            {
                Console.Clear();
                ExibirCabeçalho(nomeJogador, posicaoUsuario, posicaoComputador);
                Console.Write($"\nRodada extra para você por tirar {numeroRodadaExtra}!");
                (posicaoUsuario, resultadoUsuario) = RodadaJogador(nomeJogador, posicaoUsuario, casaAvanco, casaRecuo);
                ExibirCabeçalho(nomeJogador, posicaoUsuario, posicaoComputador);
            }
            while (resultadoComputador == numeroRodadaExtra)
            {
                Console.Clear();
                ExibirCabeçalho(nomeJogador, posicaoUsuario, posicaoComputador);
                Console.Write($"\nRodada extra para o computador por tirar {numeroRodadaExtra}!");
                (posicaoComputador, resultadoComputador) = RodadaComputador(posicaoComputador, casaAvanco, casaRecuo);
                ExibirCabeçalho(nomeJogador, posicaoUsuario, posicaoComputador);
            }

            Console.Clear();
            ExibirCabeçalho(nomeJogador, posicaoUsuario, posicaoComputador);

            return (posicaoUsuario, posicaoComputador);
        }

        static (int, int) RodadaJogador(string nomeJogador, int posicaoUsuario, int casaAvanco, int casaRecuo)
           
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
            Console.Write("\nPressione Enter para continuar...");
            Console.ReadLine();

            if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15)
            {
                Console.WriteLine($"Parou na casa {posicaoUsuario}. Você avançará {casaAvanco} casas, {nomeJogador}!");
                posicaoUsuario += casaAvanco;
                Console.Write("\nPressione Enter para continuar...");
                Console.ReadLine();
            }

            else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
            {
                Console.WriteLine($"Parou na casa {posicaoUsuario}. Você recuará {casaRecuo} casas!");
                posicaoUsuario -= casaRecuo;
            }


            return (posicaoUsuario,resultadoUsuario);
        }

        static (int,int) RodadaComputador( int posicaoComputador, int casaAvanco, int casaRecuo)

        {
            Console.WriteLine("\n\nTurno do Computador:");

            Random geradorNumeros = new Random();
            int resultadoComputador = geradorNumeros.Next(1, 7);
            posicaoComputador += resultadoComputador;
            Console.WriteLine($"\nO valor sorteado para o Computador foi {resultadoComputador}!");
            Console.Write("\nPressione Enter para continuar...");
            Console.ReadLine();

            if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15)
            {
                Console.WriteLine($"Parou na casa {posicaoComputador}. O Computador avançará {casaAvanco} casas!");
                posicaoComputador += casaAvanco;
                Console.Write("\nPressione Enter para continuar...");
                Console.ReadLine();
            }

            else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
            {
                Console.WriteLine($"Parou na casa {posicaoComputador}. O Computador recuará {casaRecuo} casas!");
                posicaoComputador -= casaRecuo;
            }

            return (posicaoComputador, resultadoComputador);
        }

        static string ExibirMenuContinuar(){
            Console.WriteLine("Deseja continuar? [s/n]");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            return opcaoContinuar;
        }
    }
}