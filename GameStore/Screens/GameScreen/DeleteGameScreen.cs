using GameStore.Models;
using GameStore.Repositories;
using System;
using System.Threading;

namespace GameStore.Screens.GameScreen
{
    public static class DeleteGameScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Insira o Id do jogo que quer excluir:");

            try
            {
                var id = int.Parse(Console.ReadLine());

                Delete(id);
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para voltar ao menu");
                Console.ReadLine();
                MenuGameScreen.Load();
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
        public static void Delete(int id)
        {
            var repository = new Repository<Game>(Database.connection);
            repository.Delete(id);
            Console.WriteLine("Exclusão realizada com sucesso!");
        }
    }
}