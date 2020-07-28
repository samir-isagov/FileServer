namespace FileServer.Application.Files.Commands.CreateFile
{
    using FluentValidation;
    using Common.Validators;

    public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
    {
        public CreateFileCommandValidator()
        {
            //RuleFor(x => x.RootFolder).NotEmpty().MustBeFolderName();
            RuleFor(x => x.SubFolder).NotEmpty().MustBeFolderName();
            RuleFor(x => x.FileName).NotEmpty().MustBeFileName();
            RuleFor(x => x.File).NotEmpty();
        }
    }
}