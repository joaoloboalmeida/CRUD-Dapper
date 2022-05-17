using GameStore.Screens.GameScreen.UpdateGameScreen;
using System;
using System.Threading;

namespace GameStore.Screens.GameScreen
{
    public static class MenuGameScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Jogos");
            Console.WriteLine();
            Console.WriteLine("1 - Listar jogos");
            Console.WriteLine("2 - Inserir jogos");
            Console.WriteLine("3 - Atualizar jogos");
            Console.WriteLine("4 - Excluir jogos");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine();

            try
            {
                var option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: ListGameScreen.Load(); break;
                    case 2: CreateGameScreen.Load(); break;
                    case 3: UpdateGameMenuScreen.Load(); break;
                    case 4: DeleteGameScreen.Load(); break;
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