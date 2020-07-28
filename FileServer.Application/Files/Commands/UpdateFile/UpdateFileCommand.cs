namespace FileServer.Application.Files.Commands.UpdateFile
{
    using MediatR;
    using System.IO;

    public class UpdateFileCommand : IRequest<string>
    {
        public string RootFolder { get; set; }

        public string SubFolder { get; set; }

        public string FileName { get; set; }

        public Stream File { get; set; }
    }
}
