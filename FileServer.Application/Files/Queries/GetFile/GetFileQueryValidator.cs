namespace FileServer.Application.Files.Queries.GetFile
{
    using Common.Validators;
    using FluentValidation;

    public class GetFileQueryValidator : AbstractValidator<GetFileQuery>
    {
        public GetFileQueryValidator()
        {
            RuleFor(x => x.SubFolder).NotEmpty().MustBeFolderName();
            RuleFor(x => x.FileName).NotEmpty().MustBeFileName();
        }
    }
}
