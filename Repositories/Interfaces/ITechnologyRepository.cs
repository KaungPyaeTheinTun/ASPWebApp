using ASPWebApp.Models;

namespace ASPWebApp.Repositories.Interfaces
{
    public interface ITechnologyRepository : BaseInterface<Technology>
    {
        IQueryable<Technology> QueryWithMedia(); 
    }
}