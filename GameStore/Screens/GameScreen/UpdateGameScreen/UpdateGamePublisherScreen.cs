using GameStore.Models;
using GameStore.Repositories;
using GameStore.Screens.GameScreen.ReturnMethods;
using System;
using System.Threading;

namespace GameStore.Screens.GameScreen.UpdateGameScreen
{
    public static class UpdateGamePublisherScreen
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
                    Console.WriteLine("Insira o Id da nova publisher do jogo: ");
                    var publisher = int.Parse(Console.ReadLine());

                    var g = new Game()
                    {
                        Id = id,
                        fkPublisher = publisher,
                        fkCategory = ReturnGameMethods.ReturnCategoryId(id),
                        Name = ReturnGameMethods.ReturnName(id),
                        Price = ReturnGameMethods.ReturnPrice(id)
                    };

                    UpdatePublisher(g);
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
        public static void UpdatePublisher(Game game)
        {
            var repository = new Repository<Game>(Database.connection);
            repository.Update(game);
            Console.WriteLine("Atualização realizada com sucesso!");
        }
    }
}