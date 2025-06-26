using Think_Digitally_week01.Models;

namespace Think_Digitally_week01.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        List<T> GetAll();
        string Update(T entity);
        void Delete(T entity);
    }
}