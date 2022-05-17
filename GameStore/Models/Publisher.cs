using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace GameStore.Models
{
    [Table("[Publisher]")]
    public class Publisher
    {
        //constructor method
        public Publisher() => Games = new List<Game>();

        //properties
        public int Id { get; set; }
        public string Name { get; set; }

        [Write(false)]
        public List<Game> Games { get; set; }
    }
}
