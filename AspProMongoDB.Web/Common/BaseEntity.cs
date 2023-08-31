using MongoDB.Bson.Serialization.Attributes;

namespace AspProMongoDB.Web.Common
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
