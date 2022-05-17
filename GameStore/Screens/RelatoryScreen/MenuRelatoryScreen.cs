using System;
using System.Threading;

namespace GameStore.Screens.RelatoryScreen
{
    public static class MenuRelatoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Visualização de relatórios");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1 - Relatório de categorias com seus respectivos jogos");
            Console.WriteLine("2 - Relatório de publishers com seus respectivos jogos");
            Console.WriteLine("3 - Voltar ao menu principal");
            Console.WriteLine();

            try
            {
                var option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: CategoryGameRelatoryScreen.Load(); break;
                    case 2: PublisherGameRelatoryScreen.Load(); break;
                    case 3: Program.Load(); break;
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