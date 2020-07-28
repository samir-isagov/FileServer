namespace FileServer.WebAPI.Controllers
{
    using System;
    using System.IO;
    using MimeTypes;
    using Common.Dtos;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Application.Common.Helpers;
    using Application.Files.Commands.AddFile;

    public class FileController : BaseController
    {
        [HttpGet("{subFolder}/{fileName}")]
        public IActionResult GetFile([FromRoute] FileDto fileModel)
        {
            string filePath = PathGenerator.GenerateFilePath(RootFolder, fileModel.SubFolder, fileModel.FileName);
            Stream stream = !System.IO.File.Exists(filePath) ? null : new FileStream(filePath, FileMode.Open);

            if (stream == null)
                return NotFound();

            string fileExtension = fileModel.FileName.Split('.')[1];
            string mimeType = MimeTypeMap.GetMimeType(fileExtension);

            return File(stream, mimeType);
        }

        //todo: Get File Extension from File Signature. Look: https://kec.az/B2HUr
        [HttpPost("{subFolder}")]
        public async Task<IActionResult> AddFile(string subFolder)
        {
            string fileEx = "";
            string fileFullName = $@"{Guid.NewGuid()}.{fileEx}";

            string filePath = PathGenerator.GenerateFilePath(RootFolder, subFolder, fileFullName);

            await using (var fileStream = System.IO.File.Open(filePath, FileMode.Create))
            {
                int bytesRead = 0;
                byte[] buffer = new byte[2048];
                while ((bytesRead = await Request.Body.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }

            return Ok(fileFullName);
        }

        //todo: Configure MultipartFormData
        [HttpPost("{subFolder}/{fileName}")]
        public async Task<IActionResult> AddFile(string subFolder, string fileName)
        {
            fileName = await Mediator.Send(new AddFileCommand
            {
                RootFolder = RootFolder,
                SubFolder = subFolder,
                FileName = fileName,
                File = Request.Body
            });

            return Ok(fileName);
        }

        [HttpPut("{subFolder}/{fileName}")]
        public async Task<IActionResult> UpdateFile([FromRoute] FileDto fileModel)
        {
            string filePath = PathGenerator.GenerateFilePath(RootFolder, fileModel.SubFolder, fileModel.FileName);

            if (!System.IO.File.Exists(filePath))
                return BadRequest("File name is not exists!");
            
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
        public IActionResult DeleteFile([FromRoute] FileDto fileModel)
        {
            string filePath = PathGenerator.GenerateFilePath(RootFolder, fileModel.SubFolder, fileModel.FileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            System.IO.File.Delete(filePath);
            return Ok();
        }
    }
}
