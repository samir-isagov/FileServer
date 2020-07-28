namespace FileServer.Application.Files.Commands.CreateFile
{
    using MediatR;
    using System.IO;
    using Common.Helpers;
    using System.Threading;
    using Common.Exceptions;
    using System.Threading.Tasks;

    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, string>
    {
        public async Task<string> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            string folderPath = PathUtility.GetFolderPath(request.RootFolder, request.SubFolder);
            string filePath = PathUtility.GetFilePath(request.RootFolder, request.SubFolder, request.FileName);

            if (!Directory.Exists(folderPath))
                throw new NotFoundException($"Folder is not found. Folder path is {folderPath}");

            if (File.Exists(filePath))
                throw new AlreadyExistsException($"File is already exists. File name is {request.FileName}");

            using (var fileStream = File.Open(filePath, FileMode.Create))
            {
                int bytesRead = 0;
                byte[] buffer = new byte[2048];
                while ((bytesRead = await request.File.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }

            return request.FileName;
        }
    }
}