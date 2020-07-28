namespace FileServer.Application.Files.Commands.AddFile
{
    using FluentValidation;
    using Common.Validators;

    public class AddFileCommandValidator : AbstractValidator<AddFileCommand>
    {
        public AddFileCommandValidator()
        {
            //RuleFor(x => x.RootFolder).NotEmpty().MustBeFolderName();
            RuleFor(x => x.SubFolder).NotEmpty().MustBeFolderName();
            RuleFor(x => x.FileName).NotEmpty().MustBeFileName();
            RuleFor(x => x.File).NotEmpty();
        }
    }
}