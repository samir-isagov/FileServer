namespace FileServer.WebAPI.Common.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class FileDto
    {
        //todo accept subFolder with '_' symbol
        [RegularExpression("^[a-zA-Z_]+$", ErrorMessage = "SubFolder must contain only letters")]
        public string SubFolder { get; set; }

        [RegularExpression(@"[^\\]*\.(\w+)$", ErrorMessage = "Name or extension is not correct (Must be like 'test.docx')")]
        public string FileName { get; set; }
    }
}