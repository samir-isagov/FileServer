using System.ComponentModel.DataAnnotations;

namespace FileServer.WebAPI.Models
{
    public class FileModel
    {
        //todo accept subFolder with '_' symbol
        [RegularExpression("^[a-zA-Z_]+$", ErrorMessage = "SubFolder must contain only letters")]
        public string SubFolder { get; set; }

        [RegularExpression(@"[^\\]*\.(\w+)$", ErrorMessage = "Name or extension is not correct (Must be like 'test.docx')")]
        public string FileName { get; set; }
    }
}
