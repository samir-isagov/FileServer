using System.IO;
using MimeTypes;
using System.Threading.Tasks;
using FileServer.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileServer.WebAPI.Controllers
{
    [Route("api")]
    public class FileController : BaseController
    {
        [HttpGet("{subFolder}/{fileName}")]
        public IActionResult GetFile([FromRoute] FileModel fileModel)
        {
            string filePath = GetFilePath(RootFolder, fileModel.SubFolder, fileModel.FileName);
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
            //todo 1. Generate File Name. Note. Get File Extension from File Signature. Look: https://kec.az/B2HUr
            //todo 2. Get File Path
            //todo 3. Read file as stream from Request.Body
            //todo 4. Write FileStream to FilePath
            
            return null;
        }

        //todo Configure MultipartFormData
        [HttpPost("{subFolder}/{fileName}")]
        public async Task<IActionResult> AddFile([FromRoute] FileModel fileModel)
        {
            string filePath = GetFilePath(RootFolder, fileModel.SubFolder, fileModel.FileName);

            await using (var fileStream = System.IO.File.Open(filePath, FileMode.Create))
            {
                int bytesRead = 0;
                byte[] buffer = new byte[2048];
                while ((bytesRead = await Request.Body.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }

            return Ok(fileModel.FileName);
        }

        [HttpDelete("{subFolder}/{fileName}")]
        public IActionResult DeleteFile([FromRoute] FileModel fileModel)
        {
            string filePath = GetFilePath(RootFolder, fileModel.SubFolder, fileModel.FileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            System.IO.File.Delete(filePath);
            return Ok();
        }

        #region Helper Methods

        private string GetFilePath(string rootFolder, string subFolder, string fileName)
        {
            string filePath = Path.Combine(RootFolder, subFolder, fileName);

            return filePath;
        }

        #endregion
    }
}
