using GameStore.Models;
using GameStore.Repositories;
using GameStore.Screens.GameScreen.ReturnMethods;
using System;
using System.Threading;

namespace GameStore.Screens.GameScreen.UpdateGameScreen
{
    public static class UpdateGameCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Insira o Id do jogo a ser atualizado: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                try
                {
                    Console.WriteLine("Insira o Id da nova categoria do jogo: ");
                    var category = int.Parse(Console.ReadLine());

                    var g = new Game()
                    {
                        Id = id,
                        fkCategory = category,
                        fkPublisher = ReturnGameMethods.ReturnPublisherId(id),
                        Name = ReturnGameMethods.ReturnName(id),
                        Price = ReturnGameMethods.ReturnPrice(id),
                    };

                    UpdateCategory(g);
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para voltar ao menu");

                    Console.ReadLine();
                    MenuGameScreen.Load();
                }
                catch(Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ocorreu um erro no registro do comando digitado. Tente novamente");
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2500);
                    Load();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ocorreu um erro no registro do comando digitado. Tente novamente");
                Console.WriteLine(ex.Message);
                Thread.Sleep(2500);
                Load();
            }
        }
        public static void UpdateCategory(Game game)
        {
            var repository = new Repository<Game>(Database.connection);
            repository.Update(game);
            Console.WriteLine("Atualização realizada com sucesso!");
        }
    }
}