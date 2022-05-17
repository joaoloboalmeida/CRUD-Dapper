using Dapper.Contrib.Extensions;

namespace GameStore.Models
{
    [Table("[Game]")]
    public class Game
    {
        //properties
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int fkCategory { get; set; }
        public int fkPublisher { get; set; }
        
    }
}
