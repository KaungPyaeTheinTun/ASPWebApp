using ASPWebApp.Models;

namespace ASPWebApp.Services.Interfaces
{
    public interface ITechnologyService
    {
        List<Technology> GetAll();
        Technology? GetById(int id);
        void Create(Technology tech);
        void Update(Technology tech);
        void Delete(Technology tech);
        List<Technology> GetAllWithMedia();
        Technology? GetByIdWithMedia(int id);
    }
}