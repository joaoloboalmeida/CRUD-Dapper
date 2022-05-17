using System;
using System.Threading;

namespace GameStore.Screens.PublisherScreen
{
    public static class MenuPublisherScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Publishers");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1 - Listar publishers");
            Console.WriteLine("2 - Inserir publishers");
            Console.WriteLine("3 - Atualizar publishers");
            Console.WriteLine("4 - Excluir publishers");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine();

            try
            {
                var option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: ListPublisherScreen.Load(); break;
                    case 2: CreatePublisherScreen.Load(); break;
                    case 3: UpdatePublisherScreen.Load(); break;
                    case 4: DeletePublisherScreen.Load(); break;
                    case 5: Program.Load(); break;
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