using GameStore.Repositories;
using System;

namespace GameStore.Screens.RelatoryScreen
{
    public static class PublisherGameRelatoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de publishers com seus respectivos jogos");
            Console.WriteLine();

            Relatory();
            Console.WriteLine();
            
            Console.WriteLine("Pressione ENTER para voltar ao menu");
            Console.ReadLine();
            MenuRelatoryScreen.Load();
        }
        public static void Relatory()
        {
            var repository = new PublisherRepository(Database.connection);
            repository.ReadPublisherWithGame(Database.connection);
        }
    }
}