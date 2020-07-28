namespace FileServer.Application.Files.Commands.UpdateFile
{
    using FluentValidation;
    using Common.Validators;

    public class UpdateFileCommandValidator : AbstractValidator<UpdateFileCommand>
    {
        public UpdateFileCommandValidator()
        {
            RuleFor(x => x.SubFolder).NotEmpty().MustBeFolderName();
            RuleFor(x => x.FileName).NotEmpty().MustBeFileName();
            RuleFor(x => x.File).NotEmpty();
        }
    }
}
