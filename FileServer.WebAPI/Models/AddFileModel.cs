using Microsoft.AspNetCore.Http;

namespace FileServer.WebAPI.Models
{
    public class AddFileModel : FileModel
    {
        public IFormFile File { get; set; }
    }
}