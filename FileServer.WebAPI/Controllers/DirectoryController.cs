using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FileServer.WebAPI.Controllers
{
    public class DirectoryController : BaseController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string[] directories = Directory.GetDirectories(RootFolder);

            foreach (var directory in directories)
            {
                DirectoryInfo info = new DirectoryInfo(directory);
                yield return info.Name;
            }
        }

        [HttpPost("{subFolder}")]
        public IActionResult Post(string subFolder)
        {
            Directory.CreateDirectory(Path.Combine(RootFolder, subFolder));

            return Ok(subFolder);
        }

        [HttpPut("{subFolder}")]
        public IActionResult Put(string subFolder, string newSubFolder)
        {
            string path = Path.Combine(RootFolder, subFolder);

            if (string.IsNullOrEmpty(path.Trim()))
                return BadRequest();

            Directory.Move(path, Path.Combine(RootFolder, newSubFolder));

            return Ok();
        }

        [HttpDelete("{subFolder}")]
        public IActionResult Remove(string subFolder)
        {
            string path = Path.Combine(RootFolder, subFolder);

            if (string.IsNullOrEmpty(path.Trim()))
                return BadRequest();

            Directory.Delete(Path.Combine(RootFolder, subFolder));

            return Ok();
        }
    }
}