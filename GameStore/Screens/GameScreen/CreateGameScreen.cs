using GameStore.Models;
using GameStore.Repositories;
using System;
using System.Threading;

namespace GameStore.Screens.GameScreen
{
    public static class CreateGameScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Insira um novo jogo na loja");
            Console.WriteLine();
            Console.WriteLine("Nome do jogo: ");
            string name = Console.ReadLine();

            Console.WriteLine();

            if(name != "")
            {
                try
                {
                    Console.WriteLine("Preço do jogo: ");
                    var price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine();
                    try
                    {
                        Console.WriteLine("Id da categoria: ");
                        var category = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        try
                        {
                            Console.WriteLine("Id da publisher: ");
                            var publisher = int.Parse(Console.ReadLine());

                            var newGame = new Game()
                            {
                                Name = name,
                                Price = price,
                                fkCategory = category,
                                fkPublisher = publisher
                            };

                            Create(newGame);
                            Console.WriteLine();

                            Console.WriteLine("Pressione ENTER para voltar ao menu");
                            Console.ReadLine();
                            MenuGameScreen.Load();
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
                    catch (Exception ex)
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
            else
            {
                Console.WriteLine();
                Console.WriteLine("É necessário inserir um nome para o jogo. Tente novamente");
                Thread.Sleep(2500);
                Load();
            }
        }
        public static void Create(Game game)
        {
            var repository = new Repository<Game>(Database.connection);
            repository.Create(game);
            Console.WriteLine("Inserção realizada com sucesso!");
        }
    }
}