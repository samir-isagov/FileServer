namespace FileServer.WebAPI.Controllers
{
    using System;
    using System.IO;
    using Common.Dtos;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Application.Common.Helpers;
    using Application.Files.Commands.CreateFile;
    using FileServer.Application.Files.Queries.GetFile;

    public class FileController : BaseController
    {
        [HttpGet("{subFolder}/{fileName}")]
        public async Task<IActionResult> GetFile(string subFolder, string fileName)
        {
            var response = await Mediator.Send(new GetFileQuery
            {
                RootFolder = RootFolder,
                SubFolder = subFolder,
                FileName  = fileName
            });

            return File(response.File, response.MimeType);
        }

        //todo: Get File Extension from File Signature. Look: https://kec.az/B2HUr
        [HttpPost("{subFolder}")]
        public async Task<IActionResult> AddFile(string subFolder)
        {
            string fileName = FileUtility.GetUniqueFileName("");

            fileName = await Mediator.Send(new CreateFileCommand
            {
                RootFolder = RootFolder,
                SubFolder = subFolder,
                FileName = fileName,
                File = Request.Body
            });

            return Ok(fileName);
        }

        //todo: Configure MultipartFormData
        [HttpPost("{subFolder}/{fileName}")]
        public async Task<IActionResult> AddFile(string subFolder, string fileName)
        {
            fileName = await Mediator.Send(new CreateFileCommand
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
            string filePath = PathUtility.GetFilePath(RootFolder, fileModel.SubFolder, fileModel.FileName);

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
            string filePath = PathUtility.GetFilePath(RootFolder, fileModel.SubFolder, fileModel.FileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            System.IO.File.Delete(filePath);
            return Ok();
        }
    }
}
