using System.IO;
using System.Threading.Tasks;
using FileServer.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeTypes;

namespace FileServer.WebAPI.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string rootFolder = "App_Data";

        public FileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("{subFolder}/{fileName}")]
        public ActionResult GetFile([FromRoute] FileModel fileModel)
        {
            string filePath = GetFilePath(rootFolder, fileModel.SubFolder, fileModel.FileName);
            Stream stream = !System.IO.File.Exists(filePath) ? null : new FileStream(filePath, FileMode.Open);

            if (stream == null)
                return NotFound();

            string fileExtension = fileModel.FileName.Split('.')[1];
            string mimeType = MimeTypeMap.GetMimeType(fileExtension);
            return File(stream, mimeType); 
        }

        #region Helper Methods

        private string GetFilePath(string rootFolder, string subFolder, string fileName)
        {
            string filePath = Path.Combine(_environment.WebRootPath, rootFolder, subFolder, fileName);

            return filePath;
        }

        #endregion
    }
}
