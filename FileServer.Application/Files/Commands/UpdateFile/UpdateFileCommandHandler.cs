namespace FileServer.Application.Files.Commands.UpdateFile
{
    using MediatR;
    using System.IO;
    using Common.Helpers;
    using System.Threading;
    using Common.Exceptions;
    using System.Threading.Tasks;

    public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, string>
    {
        public async Task<string> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
        {
            string filePath = PathUtility.GetFilePath(request.RootFolder, request.SubFolder, request.FileName);

            if (!File.Exists(filePath))
                throw new NotFoundException($"File is not found. File name is {request.FileName}");

            using (var fileStream = System.IO.File.Open(filePath, FileMode.Create))
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
