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
        private readonly string _rootFolder = "App_Data";

        public FileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("{subFolder}/{fileName}")]
        public IActionResult GetFile([FromRoute] FileModel fileModel)
        {
            string filePath = GetFilePath(_rootFolder, fileModel.SubFolder, fileModel.FileName);
            Stream stream = !System.IO.File.Exists(filePath) ? null : new FileStream(filePath, FileMode.Open);

            if (stream == null)
                return NotFound();

            string fileExtension = fileModel.FileName.Split('.')[1];
            string mimeType = MimeTypeMap.GetMimeType(fileExtension);
            return File(stream, mimeType);
        }

        [HttpPost("{subFolder}")]
        public IActionResult AddFile(string subFolder)
        {
            //todo 1. Generate File Name
            //todo 2. Get File Path
            //todo 3. Read file as stream from Request.Body
            //todo 4. Write FileStream to FilePath
            return null;
        }

        [HttpPost("{subFolder}/{fileName}")]
        public async Task<IActionResult> AddFile([FromForm] AddFileModel fileModel)
        {
            string filePath = GetFilePath(_rootFolder, fileModel.SubFolder, fileModel.FileName);

            await using (var stream = fileModel.File.OpenReadStream())
            {
                await using (var fileStream = System.IO.File.Open(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }

            return Ok(fileModel.FileName);
        }

        [HttpDelete("{subFolder}/{fileName}")]
        public IActionResult DeleteFile([FromRoute] FileModel fileModel)
        {
            string filePath = GetFilePath(_rootFolder, fileModel.SubFolder, fileModel.FileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            System.IO.File.Delete(filePath);
            return Ok();
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
