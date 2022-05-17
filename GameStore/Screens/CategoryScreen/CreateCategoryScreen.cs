using GameStore.Models;
using GameStore.Repositories;
using System;
using System.Threading;

namespace GameStore.Screens.CategoryScreen
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Insira uma nova categoria de jogos na loja");
            Console.WriteLine();
            Console.WriteLine("Nome da categoria: ");
            var name = Console.ReadLine();
            Console.WriteLine();

            if(name != "")
            {
                var category = new Category()
                {
                    Name = name
                };
                Create(category);
                Console.WriteLine();

                Console.WriteLine("Pressione ENTER para voltar ao menu");
                Console.ReadLine();
                MenuCategoryScreen.Load();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("É necessário inserir um nome para a categoria. Tente novamente");
                Thread.Sleep(2500);
                Load();
            }
        }
        public static void Create(Category category)
        {
            var repository = new Repository<Category>(Database.connection);
            repository.Create(category);
            Console.WriteLine("Inserção realizada com sucesso!");
        }
    }
}
