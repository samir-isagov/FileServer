namespace FileServer.Application.Common.Helpers
{
    using System.IO;

    public static class PathGenerator
    {
        public static string GenerateFolderPath(string rootFolder, string subFolder)
        {
            return Path.Combine(rootFolder, subFolder);
        }

        public static string GenerateFilePath(string rootFolder, string subFolder, string fileName)
        {
            return Path.Combine(rootFolder, subFolder, fileName);
        }
    }
}