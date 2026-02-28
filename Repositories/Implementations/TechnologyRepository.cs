using ASPWebApp.Data;
using ASPWebApp.Models;
using ASPWebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPWebApp.Repositories.Implementations
{
    public class TechnologyRepository : BaseRepository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(ApplicationDbContext context): base(context){}

        public IQueryable<Technology> QueryWithMedia()
            =>_dbSet
                .Include(t => t.Media);
        
    }
}