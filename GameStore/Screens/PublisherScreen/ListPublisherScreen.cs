using GameStore.Models;
using GameStore.Repositories;
using System;

namespace GameStore.Screens.PublisherScreen
{
    public static class ListPublisherScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de publishers na loja");
            Console.WriteLine();
            List();
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar ao menu");
            Console.ReadLine();
            MenuPublisherScreen.Load();
        }
        public static void List()
        {
            var repository = new Repository<Publisher>(Database.connection);
            var items = repository.Read();
            foreach (var i in items)
                Console.WriteLine($"Id: {i.Id} - Nome: {i.Name}");
        }
    }
}
