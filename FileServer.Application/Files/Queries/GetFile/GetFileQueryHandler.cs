namespace FileServer.Application.Files.Queries.GetFile
{
    using MediatR;
    using System.IO;
    using Common.Helpers;
    using System.Threading;
    using Common.Exceptions;
    using System.Threading.Tasks;

    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, GetFileQueryResponse>
    {
        public async Task<GetFileQueryResponse> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            string filePath = PathUtility.GetFilePath(request.RootFolder, request.SubFolder, request.FileName);

            if (!File.Exists(filePath))
                throw new NotFoundException($"File is not found. File name is {request.FileName}");

            return new GetFileQueryResponse { File = new FileStream(filePath, FileMode.Open), MimeType = FileUtility.GetMimeType(filePath) };
        }
    }
}