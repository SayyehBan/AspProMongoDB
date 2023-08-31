using AspProMongoDB.Web.Common.Repository;
using AspProMongoDB.Web.Entities;
using AspProMongoDB.Web.Models;
using AspProMongoDB.Web.Services.Interface;
using MongoDB.Driver;

namespace AspProMongoDB.Web.Services.Repository
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(MongoSettings settings, IMongoClient Client) : base(settings, Client)
        {
        }
    }
}
