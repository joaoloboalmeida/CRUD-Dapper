using System;
using System.Threading;

namespace GameStore.Screens.CategoryScreen
{
    public static class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Categorias");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1 - Listar categorias");
            Console.WriteLine("2 - Inserir categorias");
            Console.WriteLine("3 - Atualizar categorias");
            Console.WriteLine("4 - Excluir categorias");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine();

            try
            {
                var option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: ListCategoryScreen.Load(); break;
                    case 2: CreateCategoryScreen.Load(); break;
                    case 3: UpdateCategoryScreen.Load(); break;
                    case 4: DeleteCategoryScreen.Load(); break;
                    case 5: Program.Load(); break;
                    default: Load(); break;
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
    }
}