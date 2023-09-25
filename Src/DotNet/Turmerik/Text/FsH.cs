﻿using Turmerik.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turmerik.Text
{
    public static class FsH
    {
        public const string FILE_URI_SCHEME = "file://";

        public static readonly string InvalidFileNameChars = Path.GetInvalidFileNameChars().ToStr();
        public static readonly string InvalidPathChars = Path.GetInvalidPathChars().ToStr();

        public static readonly ReadOnlyCollection<string> CommonTextFileExtensions = new string[]
        {
            ".txt", ".md", ".c", ".cpp", ".cs", ".java", ".xml", ".html", ".css", ".js", ".ts", ".json", ".scss", ".less", ".jsx", ".tsx"
        }.RdnlC();

        public static readonly ReadOnlyCollection<string> CommonImageFileExtensions = new string[]
        {
            ".jpg", ".jpeg", ".gif", ".png", ".bmp", ".ico"
        }.RdnlC();

        public static readonly ReadOnlyCollection<string> CommonVideoFileExtensions = new string[]
        {
            ".avi", ".mpeg", ".mpg", ".mp4", ".m4a", ".ogg"
        }.RdnlC();

        public static readonly ReadOnlyCollection<string> CommonAudioFileExtensions = new string[]
        {
            ".mp3", ".flac", ".aac", ".wav"
        }.RdnlC();

        public static readonly string ParentDir = string.Concat(
            "..", Path.DirectorySeparatorChar);

        public static bool IsWinDrive(string path)
        {
            bool isWinDrive = path.LastOrDefault() == ':';
            return isWinDrive;
        }

        public static void CopyDirectory(string sourceDir, string destinationDir)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            foreach (DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);

                CopyDirectory(
                    subDir.FullName,
                    newDestinationDir);
            }
        }

        public static void MoveDirectory(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);
            dir.MoveTo(destinationDir);
        }

        /// <summary>
        /// Taken from: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="destinationDir"></param>
        /// <param name="recursive"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        private static void CopyDirectoryCore(
            string sourceDir,
            string destinationDir,
            bool recursive,
            bool isMoveDir)
        {
            Action<FileInfo, string> copyFileFunc;

            if (isMoveDir)
            {
                copyFileFunc = (fileInfo, newPath) => fileInfo.MoveTo(newPath);
            }
            else
            {
                copyFileFunc = (fileInfo, newPath) => fileInfo.CopyTo(newPath);
            }

            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                copyFileFunc(file, targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);

                    CopyDirectoryCore(
                        subDir.FullName,
                        newDestinationDir,
                        true,
                        isMoveDir);

                    if (isMoveDir)
                    {
                        subDir.Delete();
                    }
                }
            }
        }

        public static string NormalizePath(string path)
        {
            var uri = new Uri(path);
            var localPath = uri.LocalPath;

            path = Path.GetFullPath(localPath);

            path = path.TrimEnd(
                Path.DirectorySeparatorChar,
                Path.AltDirectorySeparatorChar);

            return path;
        }

        public static string CombinePaths(
            string[] pathParts,
            string dirSep)
        {
            pathParts = pathParts.Select(
                part => part?.Trim().Trim('/', '\\')).ToArray();

            pathParts = pathParts.Where(
                part => !string.IsNullOrWhiteSpace(part)).ToArray();

            string retPath = null;

            if (pathParts.Any())
            {
                retPath = string.Join(dirSep, pathParts);
            }

            if (retPath?.EndsWith(":") ?? false)
            {
                retPath += dirSep;
            }

            return retPath;
        }
    }
}
