using GameStore.Models;
using GameStore.Repositories;
using GameStore.Screens.GameScreen.ReturnMethods;
using System;
using System.Threading;

namespace GameStore.Screens.GameScreen.UpdateGameScreen
{
    public static class UpdateGameNameScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Insira o Id do jogo a ser atualizado: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Insira o novo nome do jogo: ");
                var game = Console.ReadLine();

                if(game != "")
                {
                    var g = new Game()
                    {
                        Id = id,
                        Name = game,
                        Price = ReturnGameMethods.ReturnPrice(id),
                        fkCategory = ReturnGameMethods.ReturnCategoryId(id),
                        fkPublisher = ReturnGameMethods.ReturnPublisherId(id)
                    };

                    UpdateName(g);
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para voltar ao menu");

                    Console.ReadLine();
                    MenuGameScreen.Load();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("É necessário inserir um nome para o jogo. Tente novamente");
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
        public static void UpdateName(Game game)
        {
            var repository = new Repository<Game>(Database.connection);
            repository.Update(game);
            Console.WriteLine("Atualização realizada com sucesso!");
        }
    }
}