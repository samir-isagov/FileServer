namespace FileServer.ConsoleUI
{
    using System.IO;
    using System.Net.Http;

    class Program
    {
        static void Main(string[] args)
        {
            string subFolder = "int_doc";
            string fileName = "2006071537020.pdf";
            var stream = File.OpenRead(@$"C:\Users\smrsgv\Downloads\{fileName}");

            UploadAsStream(subFolder, fileName, stream);
        }

        static void UploadAsStream(string subFolder, string fileName, Stream stream)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization",
                    "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJlc2RhcyIsIm5iZiI6MTU5NTUyNTg5MCwiZXhwIjoxNTk1NjEyMjkwLCJpYXQiOjE1OTU1MjU4OTB9.zOxONdE5oJYnBQp8Z0Dt0m7H3wrwl_FbFh7BFBlyNd4nnEJtrBKzPVPocSmxKcVnvee8DcjxKxURIYOztkhNcQ");

                string url = $"http://localhost:6048/api/file/{subFolder}";

                using (var content = new StreamContent(stream))
                {
                    var postResult = httpClient.PostAsync(url, content).Result;
                    postResult.EnsureSuccessStatusCode();
                }
            }
        }
    }
}