using ASPWebApp.Models;

namespace ASPWebApp.Repositories.Interfaces
{
    public interface ITechnologyRepository : IBaseRepository<Technology>
    {
        IQueryable<Technology> QueryWithMedia(); 
    }
}