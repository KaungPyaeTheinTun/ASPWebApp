using ASPWebApp.Models;
using ASPWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ASPWebApp.Services.Implementations
{
    public class MediaService : IMediaService
    {
        private readonly string _uploadPath;

        public MediaService()
        {
            _uploadPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "uploads"
            );

            if (!Directory.Exists(_uploadPath))
                Directory.CreateDirectory(_uploadPath);
        }

        public Media UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(_uploadPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            return new Media
            {
                FileName = fileName,
                FilePath = $"/uploads/{fileName}",
                ContentType = file.ContentType,
                CreatedAt = DateTime.UtcNow
            };
        }
        
        public Media UpdateFile(IFormFile file, Media existingMedia)
        {
            if (existingMedia != null)
                DeleteFile(existingMedia.FileName);

            return UploadFile(file);
        }

        public void DeleteFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            var filePath = Path.Combine(_uploadPath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}