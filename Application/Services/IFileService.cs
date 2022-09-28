using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IFileService
    {
        public byte[] ConvertFileToByteArray(IFormFile file);
    }
}