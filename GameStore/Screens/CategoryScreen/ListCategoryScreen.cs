using GameStore.Models;
using GameStore.Repositories;
using System;

namespace GameStore.Screens.CategoryScreen
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias na loja");
            Console.WriteLine();
            
            List();
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar ao menu");
            
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }
        public static void List()
        {
            var repository = new Repository<Category>(Database.connection);
            var items = repository.Read();
            foreach (var i in items)
                Console.WriteLine($"Id: {i.Id} - Nome: {i.Name}");
        }
    }
}
