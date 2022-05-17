using GameStore.Models;
using GameStore.Repositories;
using System;

namespace GameStore.Screens.GameScreen
{
    public static class ListGameScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de jogos na loja");
            Console.WriteLine();
            List();
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar ao menu");
            Console.ReadLine();
            MenuGameScreen.Load();
        }
        public static void List()
        {
            var repository = new Repository<Game>(Database.connection);
            var items = repository.Read();
            foreach (var i in items)
                Console.WriteLine($"Nome: {i.Name} - Preço: R$ {i.Price}");
        }
    }
}
