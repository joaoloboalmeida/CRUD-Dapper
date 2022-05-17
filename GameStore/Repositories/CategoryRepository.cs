using Dapper;
using GameStore.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection) 
            : base(connection)
            => _connection = connection; 
        
        public void ReadCategoryWithGame(SqlConnection connection)
        {
            var query = @"
                    select 
                        c.Id,
                        c.Name,
                        g.Name,
                        g.Price
                    from [Category] as c
                    inner join [Game] as g on c.Id = g.fkCategory";

            var cat = new List<Category>();
            var items = connection.Query<Category, Game, Category>(
                query,
                (category, game) =>
                {
                    //verificando se a categoria já existe na lista de categoria
                    var isIn = cat.Where(x => x.Id == category.Id).FirstOrDefault();

                    //se a categoria não existir 
                    if (isIn == null)
                    {
                        isIn = category; //cria a categoria
                        isIn.Games.Add(game); //adicionando o jogo na categoria
                        cat.Add(isIn); //adicionando a categoria na lista de categorias já com os jogos dela
                    } 
                    //se a categoria já existir
                    else
                       isIn.Games.Add(game); //apenas adiciona um jogo a ela
                    
                    return category;
                }, splitOn: "Name");
            
            foreach(var item in items)
            {
                if (item.Games.Any())
                {
                    Console.WriteLine($"Nome da categoria: {item.Name}");
                    foreach (var i in item.Games)
                        Console.WriteLine($" - {i.Name}  R$ {i.Price}");

                    Console.WriteLine();
                }
            }
        }
    }
}
