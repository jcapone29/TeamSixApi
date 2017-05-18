using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
   public class MongoRepository<T> : IMongoRepository<T>, IDisposable where T : EntityBase
    {
        private readonly IMongoCollection<T> _collection;
       
        public MongoRepository()
        {
            try
            {
                var client = DataConnectionProvider.GetMongoClient();
                var db = client.GetDatabase("TeamSix");
                _collection = db.GetCollection<T>(typeof(T).Name);
            }
            catch (Exception ex)
            {
               
            }

        }

        public MongoRepository(IMongoClient client)
        {
            var db = client.GetDatabase("TeamSix");
            _collection = db.GetCollection<T>(typeof(T).Name);
        }


        public Task Update(T model)
        {
            var filter = Builders<T>.Filter.Eq("Id", model.Id);
            return _collection.ReplaceOneAsync(filter, model);
        }


        public Task Remove(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return _collection.DeleteOneAsync(filter);
        }

        public Task RemoveRange(IEnumerable<T> models)
        {
            var filter = Builders<T>.Filter.In("Id", models.Select(model => model.Id));
            return _collection.DeleteManyAsync(filter);
        }

        public IQueryable<T> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public Task<T> GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefaultAsync();
        }

        public Task Save(T model)
        {
            return _collection.InsertOneAsync(model);

        }

        public Task SaveRange(IEnumerable<T> models)
        {
            return _collection.InsertManyAsync(models);
        }

        public Task<List<T>> FindByProperty(string property, string search)
        {
            var filter = Builders<T>.Filter.Eq(property, search);
            return _collection.Find(filter).ToListAsync();
        }

        public void Dispose()
        {
            //Not sure yet if I need to dispose of a Mongo client connection
        }
    }
}
