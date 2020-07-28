namespace FileServer.Application.Common.Validators
{
    using FluentValidation;
    using FluentValidation.Validators;
    using System.Text.RegularExpressions;

    public class FileNameValidator : PropertyValidator
    {
        private const string pattern = @"[^\\]*\.(\w+)$";

        public FileNameValidator() : base("{PropertyName} must be like file name") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string folderName = context.PropertyValue as string;

            return Regex.IsMatch(folderName, pattern);
        }
    }

    public static class FileNameValidatorExtension
    {
        public static IRuleBuilderOptions<T, string> MustBeFileName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new FileNameValidator());
        }
    }
}