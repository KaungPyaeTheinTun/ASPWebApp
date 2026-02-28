using ASPWebApp.Models;

namespace ASPWebApp.Services.Interfaces
{
    public interface ITechnologyService : IBaseService<Technology>
    {
        List<Technology> GetAllWithMedia();
        Technology? GetByIdWithMedia(int id);
    }
}