using GameStore.Models;
using GameStore.Repositories;
using System;
using System.Threading;

namespace GameStore.Screens.PublisherScreen
{
    public static class DeletePublisherScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Insira o Id da publisher que quer excluir:");

            try
            {
                var id = int.Parse(Console.ReadLine());
                
                Delete(id);
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para voltar ao menu");

                Console.ReadLine();
                MenuPublisherScreen.Load();
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
        public static void Delete(int id)
        {
            var repository = new Repository<Publisher>(Database.connection);
            repository.Delete(id);
            Console.WriteLine("Exclusão realizada com sucesso!");
        }
    }
}