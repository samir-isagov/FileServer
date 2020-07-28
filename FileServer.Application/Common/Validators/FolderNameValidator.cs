namespace FileServer.Application.Common.Validators
{
    using FluentValidation;
    using FluentValidation.Validators;
    using System.Text.RegularExpressions;

    public class FolderNameValidator : PropertyValidator
    {
        private const string pattern = "^[a-zA-Z_]+$";

        public FolderNameValidator() : base("{PropertyName} must contain only letters and underscore(_)") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string folderName = context.PropertyValue as string;

            return Regex.IsMatch(folderName, pattern);
        }
    }

    public static class FolderNameValidatorExtension
    {
        public static IRuleBuilderOptions<T, string> MustBeFolderName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new FolderNameValidator());
        }
    }
}