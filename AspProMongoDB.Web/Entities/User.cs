using AspProMongoDB.Web.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace AspProMongoDB.Web.Entities
{
    public class User:BaseEntity
    {
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [BsonIgnore]
        public string FullName => $"{FirstName} {LastName}";
    }
}
