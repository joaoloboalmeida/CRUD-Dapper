using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace GameStore.Repositories
{
    public class Repository<T> where T : class
    {
        //connection on Database
        private readonly SqlConnection _connection;

        //constructor method
        public Repository(SqlConnection connection) => _connection = connection;

        //CRUD methods+
        public IEnumerable<T> Read() => _connection.GetAll<T>();
        public T Read(int id) => _connection.Get<T>(id);
        public void Create(T model) => _connection.Insert(model);
        public void Update(T model) => _connection.Update(model);
        public void Delete(T model) => _connection.Delete(model); 
        public void Delete(int id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete(model);
        }
    }
}
