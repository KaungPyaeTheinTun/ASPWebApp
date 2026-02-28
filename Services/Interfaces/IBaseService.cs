namespace ASPWebApp.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Func<T, bool> predicate);
    }
}