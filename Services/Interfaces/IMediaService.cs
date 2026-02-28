using ASPWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace ASPWebApp.Services.Interfaces
{
    public interface IMediaService
    {
        Media UploadFile(IFormFile file);
        Media UpdateFile(IFormFile file, Media existingMedia);
        void DeleteFile(string fileName);
    }
}