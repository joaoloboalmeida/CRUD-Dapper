using GameStore.Models;
using GameStore.Repositories;
using System;
using System.Threading;

namespace GameStore.Screens.CategoryScreen
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Insira o Id da categoria a ser atualizada: ");

            try
            {
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Insira o novo nome da categoria: ");
                var name = Console.ReadLine();

                if(name != "")
                {
                    var category = new Category()
                    {
                        Id = id,
                        Name = name
                    };

                    Update(category);
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
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ocorreu um erro no registro do comando digitado. Tente novamente");
                Console.WriteLine(ex.Message);
                Thread.Sleep(2500);
                Load();
            }
        }
        public static void Update(Category category)
        {
            var repository = new Repository<Category>(Database.connection);
            repository.Update(category);
            Console.WriteLine("Atualização realizada com sucesso!");
        }
    }
}