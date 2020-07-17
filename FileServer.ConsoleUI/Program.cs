using System.IO;
using System.Net.Http;

namespace FileServer.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string subFolder = "esdas";
            string fileName = "ttt.pdf";
            var stream = File.OpenRead(@$"C:\Users\smrsgv\Desktop\esdas\{fileName}");

            UploadAsStream(subFolder, fileName, stream);
        }

        static void UploadAsStream(string subFolder, string fileName, Stream stream)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization",
                    "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJrdWxwaW4iLCJuYmYiOjE1OTQ3NjMyMDksImV4cCI6MTU5NDg0OTYwOSwiaWF0IjoxNTk0NzYzMjA5fQ.rCkCeXLFGCQEnJE0sCSHvoE5v5zCQ6MKQEnkDWibRJlo7vl4QAXwkZYSQ8-2PjlVfXcA4NS9RR05p7bYK5e5zQ");

                string url = $"http://localhost:6048/api/{subFolder}/{fileName}";

                using (var content = new StreamContent(stream))
                {
                    var postResult = httpClient.PostAsync(url, content).Result;
                    postResult.EnsureSuccessStatusCode();
                }
            }
        }
    }
}