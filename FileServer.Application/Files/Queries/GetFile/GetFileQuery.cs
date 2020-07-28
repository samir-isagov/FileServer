namespace FileServer.Application.Files.Queries.GetFile
{
    using MediatR;
    using System.IO;

    public class GetFileQuery : IRequest<GetFileQueryResponse>
    {
        public string RootFolder { get; set; }

        public string SubFolder { get; set; }

        public string FileName { get; set; }
    }

    public class GetFileQueryResponse
    {
        public Stream File { get; set; }

        public string MimeType { get; set; }
    }
}