using ASPWebApp.Models;
using ASPWebApp.Repositories.Interfaces;
using ASPWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPWebApp.Services.Implementations
{
    public class TechnologyService : CommonService<Technology>, ITechnologyService
    {
        public TechnologyService(IBaseRepository<Technology> repo): base(repo)
        {
        }

        public List<Technology> GetAllWithMedia()
        {
            return _repo.GetAll()
                .Include(t => t.Media)
                .ToList();
        }

        public Technology? GetByIdWithMedia(int id)
        {
            return _repo.GetAll()
                .Include(t => t.Media)
                .FirstOrDefault(t => t.Id == id);
        }
    }
}