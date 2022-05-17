using GameStore.Screens.CategoryScreen;
using GameStore.Screens.GameScreen;
using GameStore.Screens.PublisherScreen;
using GameStore.Screens.RelatoryScreen;
using Microsoft.Data.SqlClient;
using System;
using System.Threading;

namespace GameStore
{
    internal class Program
    {
        private const string CONNECTION_STRING = @"Server = localhost, 1433; Database = GameStore; User ID = sa;
                                                    Password = yourPassword; TrustServerCertificate = True";
        static void Main(string[] args)
        {
            using(Database.connection = new SqlConnection(CONNECTION_STRING))
            { Load(); }
        }

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Bem-vindo à GameStore!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Escolha uma das opções abaixo digitando seu número");
            Console.WriteLine("1 - Gestão de Jogos");
            Console.WriteLine("2 - Gestão de Categorias");
            Console.WriteLine("3 - Gestão de Publishers");
            Console.WriteLine("4 - Relatórios");
            Console.WriteLine("0 - SAIR");

            try
            {
                var option = short.Parse(Console.ReadLine());
                
                switch (option)
                {
                    case 1: MenuGameScreen.Load(); break;
                    case 2: MenuCategoryScreen.Load(); break;
                    case 3: MenuPublisherScreen.Load(); break;
                    case 4: MenuRelatoryScreen.Load(); break;
                    case 0: Environment.Exit(0); break;
                    default: Load(); break;
                }
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
    } 
}