using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FileServer.WebAPI.Models
{
    public class FileModel
    {
        [FromRoute(Name = "subFolder")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "SubFolder must contain only letters")]
        public string SubFolder { get; set; }

        [FromRoute(Name = "fileName")]
        [RegularExpression(@"[^\\]*\.(\w+)$", ErrorMessage = "Name or extension is not correct (Must be like 'test.docx')")]
        public string FileName { get; set; }
    }
}
