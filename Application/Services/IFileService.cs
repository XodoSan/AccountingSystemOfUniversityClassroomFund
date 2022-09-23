using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IFileService
    {
        public void AddFileInDirectory(IFormFile file, string currentFilePath);
    }
}