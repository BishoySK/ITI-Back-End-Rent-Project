

namespace Realstate_DAL
{ 
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly RealstateContext _context;

        public GenericRepo(RealstateContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T? GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
 
        public void Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {    
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
