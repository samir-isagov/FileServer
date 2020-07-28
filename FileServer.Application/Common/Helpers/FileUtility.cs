namespace FileServer.Application.Common.Helpers
{
    using System;
    using MimeTypes;
    using System.IO;

    public static class FileUtility
    {
        public static string GetUniqueFileName(string extension)
        {
            return $"{Guid.NewGuid()}.{extension}";
        }

        public static string GetExtensionWithPeriod(string filePath)
        {
            return Path.GetExtension(filePath);
        }

        public static string GetExtensionWithoutPeriod(string filePath)
        {
            string extensionWithPeriod = GetExtensionWithPeriod(filePath);
            return extensionWithPeriod.Substring(1);
        }

        public static string GetMimeType(string filePath)
        {
            string extension = GetExtensionWithoutPeriod(filePath);

            return MimeTypeMap.GetMimeType(extension);
        }
    }
}