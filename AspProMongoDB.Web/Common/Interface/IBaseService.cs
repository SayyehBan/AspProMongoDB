
namespace AspProMongoDB.Web.Common.Interface
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid Id);
        TEntity GetById(Guid Id);
        List<TEntity> GetAll();
    }
}
