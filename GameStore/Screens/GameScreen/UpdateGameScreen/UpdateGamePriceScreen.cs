using GameStore.Models;
using GameStore.Repositories;
using GameStore.Screens.GameScreen.ReturnMethods;
using System;
using System.Threading;

namespace GameStore.Screens.GameScreen.UpdateGameScreen
{
    public static class UpdateGamePriceScreen
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
                    Console.WriteLine("Insira o novo preço do jogo: ");
                    var price = decimal.Parse(Console.ReadLine());

                    var g = new Game()
                    {
                        Id = id,
                        Price = price,
                        Name = ReturnGameMethods.ReturnName(id),
                        fkCategory = ReturnGameMethods.ReturnCategoryId(id),
                        fkPublisher = ReturnGameMethods.ReturnPublisherId(id)
                    };

                    UpdatePrice(g);
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
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ocorreu um erro no registro do comando digitado. Tente novamente");
                Console.WriteLine(ex.Message);
                Thread.Sleep(2500);
                Load();
            }
        }
        public static void UpdatePrice(Game game)
        {
            var repository = new Repository<Game>(Database.connection);
            repository.Update(game);
            Console.WriteLine("Atualização realizada com sucesso!");
        }
    }
}