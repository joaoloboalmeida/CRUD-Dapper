using System;
using System.Threading;

namespace GameStore.Screens.GameScreen.UpdateGameScreen
{
    public static class UpdateGameMenuScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma das opções abaixo");
            Console.WriteLine();
            Console.WriteLine("1 - Atualizar nome do jogo");
            Console.WriteLine("2 - Atualizar preço do jogo");
            Console.WriteLine("3 - Atualizar categoria do jogo");
            Console.WriteLine("4 - Atualizar publisher do jogo");
            Console.WriteLine("5 - Atualizar todos os dados do jogo");
            Console.WriteLine("6 - Retornar ao menu de gestão de jogos");
            Console.WriteLine("7 - Retornar ao menu principal");
            Console.WriteLine("8 - Sair do sistema");
            Console.WriteLine();

            try
            {
                var option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: UpdateGameNameScreen.Load(); break;
                    case 2: UpdateGamePriceScreen.Load(); break;
                    case 3: UpdateGameCategoryScreen.Load(); break;
                    case 4: UpdateGamePublisherScreen.Load(); break;
                    case 5: UpdateGameAll.Load(); break;
                    case 6: MenuGameScreen.Load(); break;
                    case 7: Program.Load(); break;
                    case 8: Environment.Exit(0); break;
                    default: Load(); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ocorreu um erro no registro do comando digitado. Tente novamente");
                Console.WriteLine(ex.Message);
                Thread.Sleep(2500);
                Load();
            }
        }
    }
}
