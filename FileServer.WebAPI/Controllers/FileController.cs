using System.IO;
using System.Threading.Tasks;
using FileServer.WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FileServer.WebAPI.Controllers
{
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
        public async Task<ActionResult<byte[]>> GetFile([FromRoute]FileModel fileModel)
        {
            string filePath = GetFilePath(rootFolder, fileModel.SubFolder, fileModel.FileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            byte[] file = await System.IO.File.ReadAllBytesAsync(filePath);

            return Ok(file);
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
