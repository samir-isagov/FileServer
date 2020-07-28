namespace FileServer.Application.Common.Helpers
{
    using System.IO;

    public static class PathUtility
    {
        public static string GetFolderPath(string rootFolder, string subFolder)
        {
            return Path.Combine(rootFolder, subFolder);
        }

        public static string GetFilePath(string rootFolder, string subFolder, string fileName)
        {
            return Path.Combine(rootFolder, subFolder, fileName);
        }
    }
}