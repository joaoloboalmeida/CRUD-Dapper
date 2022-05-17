using GameStore.Models;
using GameStore.Repositories;
using System;
using System.Threading;

namespace GameStore.Screens.GameScreen.UpdateGameScreen
{
    public static class UpdateGameAll
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
                var name = Console.ReadLine();
                Console.WriteLine();

                if(name != "")
                {
                    try
                    {
                        Console.WriteLine("Insira o novo preço do jogo: ");
                        var price = decimal.Parse(Console.ReadLine());
                        Console.WriteLine();

                        try
                        {
                            Console.WriteLine("Insira o Id da nova categoria do jogo: ");
                            var category = int.Parse(Console.ReadLine());
                            Console.WriteLine();

                            try
                            {
                                Console.WriteLine("Insira o Id da nova publisher do jogo: ");
                                var publisher = int.Parse(Console.ReadLine());

                                var g = new Game()
                                {
                                    Id = id,
                                    Name = name,
                                    Price = price,
                                    fkCategory = category,
                                    fkPublisher = publisher
                                };

                                UpdateAll(g);
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
                    catch(Exception ex)
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
            catch(Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ocorreu um erro no registro do comando digitado. Tente novamente");
                Console.WriteLine(ex.Message);
                Thread.Sleep(2500);
                Load();
            }
        }
        public static void UpdateAll(Game game)
        {
            var repository = new Repository<Game>(Database.connection);
            repository.Update(game);
            Console.WriteLine("Atualização realizada com sucesso!");
        }
    }
}