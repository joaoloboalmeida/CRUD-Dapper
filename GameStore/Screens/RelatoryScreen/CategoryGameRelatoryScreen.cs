using GameStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Screens.RelatoryScreen
{
    public static class CategoryGameRelatoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de categorias com seus respectivos jogos");
            Console.WriteLine();

            Relatory();
            Console.WriteLine();

            Console.WriteLine("Pressione ENTER para voltar ao menu");
            Console.ReadLine();
            MenuRelatoryScreen.Load();
        }
        public static void Relatory()
        {
            var repository = new CategoryRepository(Database.connection);
            repository.ReadCategoryWithGame(Database.connection);
        }
    }
}
