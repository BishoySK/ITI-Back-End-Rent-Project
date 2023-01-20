

namespace Realstate_DAL
{
    public interface IGenericRepo<T> where T : class
    {
        List<T> GetAll();   

        void Add(T item);
        T? GetById(Guid id);
        void Update(T entity);  
        void Delete(T entity);
        void SaveChanges();

    }
}
