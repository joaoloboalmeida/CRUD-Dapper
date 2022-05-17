using GameStore.Models;
using GameStore.Repositories;
using System;
using System.Threading;

namespace GameStore.Screens.PublisherScreen
{
    public static class CreatePublisherScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Insira uma nova publisher na loja");
            Console.WriteLine();
            Console.WriteLine("Nome da publisher: ");
            
            try
            {
                var name = Console.ReadLine();
                Console.WriteLine();

                if(name != "")
                {
                    var publisher = new Publisher()
                    {
                        Name = name
                    };
                    Create(publisher);
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
        public static void Create(Publisher publisher)
        {
            var repository = new Repository<Publisher>(Database.connection);
            repository.Create(publisher);
            Console.WriteLine("Inserção realizada com sucesso!");
        }
    }
}