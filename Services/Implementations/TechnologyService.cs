using ASPWebApp.Models;
using ASPWebApp.Repositories.Interfaces;
using ASPWebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ASPWebApp.Services.Implementations
{
    public class TechnologyService 
        : CommonService<Technology>, ITechnologyService
    {
        private readonly ITechnologyRepository _techRepo;

        public TechnologyService(ITechnologyRepository repo) : base(repo)
        {
            _techRepo = repo; 
        }

        public List<Technology> GetAllWithMedia()
        {
            return _techRepo.QueryWithMedia().ToList();
        }

        public Technology? GetByIdWithMedia(int id)
        {
            return _techRepo.QueryWithMedia()
                            .FirstOrDefault(t => t.Id == id);
        }
    }
}