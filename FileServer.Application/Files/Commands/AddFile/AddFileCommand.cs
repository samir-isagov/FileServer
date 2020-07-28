namespace FileServer.Application.Files.Commands.AddFile
{
    using MediatR;
    using System.IO;

    public class AddFileCommand : IRequest<string>
    {
        public string RootFolder { get; set; }

        public string SubFolder { get; set; }

        public string FileName { get; set; }

        public Stream File { get; set; }
    }
}