using Dapper;
using GameStore.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Repositories
{
    public class PublisherRepository : Repository<Publisher>
    {
        private readonly SqlConnection _connection;

        public PublisherRepository(SqlConnection connection) 
            :base(connection)
            => _connection = connection;

        public void ReadPublisherWithGame(SqlConnection connection)
        {
            var query = @"select 
                            p.Id,
                            p.Name,
                            g.Name,
                            g.Price
                        from [Publisher] as p 
                        inner join [Game] as g on p.Id = g.fkPublisher";

            var publi = new List<Publisher>();

            var items = connection.Query<Publisher, Game, Publisher>(
                query,
                (publisher, game) =>
                {
                    var isIn = publi.Where(x => x.Id == publisher.Id).FirstOrDefault();

                    if(isIn == null)
                    {
                        isIn = publisher;
                        isIn.Games.Add(game); 
                        publi.Add(isIn); 
                    }
                    else
                        isIn.Games.Add(game); 
                    
                    return publisher;
                }, splitOn: "Name");

            foreach(var item in items)
            {
                if (item.Games.Any())
                {
                    Console.WriteLine($"Nome da publisher: {item.Name}");
                    foreach (var i in item.Games)
                        Console.WriteLine($" - {i.Name}   R$ {i.Price}");
                    
                    Console.WriteLine();
                }
            }
        }
    }
}
