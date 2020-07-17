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
        public void Post(string subFolder)
        {

        }

        [HttpPut("{subFolder}/{newSubFolder}")]
        public void Put(string subFolder, string newSubFolder)
        {
        }

        [HttpDelete("{subFolder}")]
        public void Remove(string subFolder)
        {
        }


    }
}
