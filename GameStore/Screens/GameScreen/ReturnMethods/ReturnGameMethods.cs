using GameStore.Models;
using GameStore.Repositories;

namespace GameStore.Screens.GameScreen.ReturnMethods
{
    public static class ReturnGameMethods
    {
        /*
       * Os métodos abaixo são utilizados para pegar os valores da fkCategory,
       * fkPublisher, Name e Price e os retornar para que o usuário tenha apenas que informar
       * o id e o outro dado do jogo para atualização e evitando com que ele repita valores
       */
        public static int ReturnCategoryId(int id)
        {
            var repository = new Repository<Game>(Database.connection);
            var categoryId = repository.Read(id);
            int fkCat = categoryId.fkCategory;

            return fkCat;
        }

        public static int ReturnPublisherId(int id)
        {
            var repository = new Repository<Game>(Database.connection);
            var publisherId = repository.Read(id);
            int fkPub = publisherId.fkPublisher;

            return fkPub;
        }

        public static string ReturnName(int id)
        {
            var repository = new Repository<Game>(Database.connection);
            var gName = repository.Read(id);
            string name = gName.Name;

            return name;
        }
        
        public static decimal ReturnPrice(int id)
        {
            var repository = new Repository<Game>(Database.connection);
            var priceValue = repository.Read(id);
            decimal price = priceValue.Price;

            return price;
        }
    }
}