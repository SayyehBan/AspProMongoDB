using AspProMongoDB.Web.Common.Interface;
using AspProMongoDB.Web.Entities;
using AspProMongoDB.Web.Models;
using MongoDB.Driver;

namespace AspProMongoDB.Web.Common.Repository
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _Collection;
        public BaseService(MongoSettings settings, IMongoClient Client)
        {
            var database = Client.GetDatabase(settings.DatabaseName);
            _Collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public void Delete(Guid Id)
        {
            _Collection.DeleteOne(f => f.Id == Id);
        }

        public List<TEntity> GetAll()
        {
            return _Collection.Find(_ => true).ToList();
        }

        public TEntity GetById(Guid Id)
        {
            return _Collection.Find(f => f.Id == Id).FirstOrDefault();
        }

        public void Insert(TEntity entity)
        {
            _Collection.InsertOne(entity);
        }

        public void Update(TEntity entity)
        {
            _Collection.ReplaceOne(f => f.Id == entity.Id, entity);
        }
    }
}
