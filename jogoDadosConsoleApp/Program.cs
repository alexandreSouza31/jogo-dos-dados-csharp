
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

                bool jogoEmAndamento = true;

                while (jogoEmAndamento) 
                {
                    ExibirCabeçalho();

                    int resultado = RolarDado();

                    ExibirResultado(resultado);

                    posicaoUsuario += resultado;


                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Parabéns! Você alcançou a linha de chegada!");
                        jogoEmAndamento= false;
                    }
                    else Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}");

                    Console.WriteLine("Digite Enter para continuar...");
                    Console.ReadLine();
                }

                string opcaoContinuar=ExibirMenuContinuar();

                if (opcaoContinuar != "s") break;

            }
        }

        static void ExibirCabeçalho()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("      Jogo  de Dados");
            Console.WriteLine("------------------------------");
        }

        static int RolarDado()
        {
            Console.Write("Pressione Enter para rolar o dado:");
            Console.ReadLine();
            Random geradorNumeros = new Random();
            int resultado = geradorNumeros.Next(1, 7);

            return resultado;
        }

        static void ExibirResultado(int resultado)
        {

            Console.WriteLine("------------------------------");
            Console.WriteLine($"O valor sorteado foi {resultado}");
            Console.WriteLine("------------------------------");
        }

        static string ExibirMenuContinuar(){
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Deseja continuar? [s/n]");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();//essa exclamação diz pro VS não reclamar

            return opcaoContinuar;
        }
    }
}