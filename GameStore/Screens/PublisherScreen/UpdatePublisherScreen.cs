using GameStore.Models;
using GameStore.Repositories;
using System;
using System.Threading;

namespace GameStore.Screens.PublisherScreen
{
    public static class UpdatePublisherScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Insira o Id da publisher a ser atualizada: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Insira o novo nome da publisher: ");
                var name = Console.ReadLine();

                if(name != "")
                {
                    var publisher = new Publisher()
                    {
                        Id = id,
                        Name = name
                    };

                    Update(publisher);
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para voltar ao menu");

                    Console.ReadLine();
                    MenuPublisherScreen.Load();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("É necessário inserir um nome para a publisher. Tente novamente");
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
        public static void Update(Publisher publisher)
        {
            var repository = new Repository<Publisher>(Database.connection);
            repository.Update(publisher);
            Console.WriteLine("Atualização realizada com sucesso!");
        }
    }
}