using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Schmansible.Services.IO
{
    public class FileService: IFileService
    {
        private readonly ILogger _logger;
        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public List<string> GetFiles(string dir)
        {
            if (Directory.Exists(dir))
            {
                return Directory.GetFiles(dir).ToList();
            }
            else
            {
                _logger.LogInformation($"{dir} Does not exist. creating it");
                Directory.CreateDirectory(dir);
                return null;
            }
        }

        public string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                _logger.LogError($"{path} is not a valid file or directory.");
                return null;
            }
        }


        public string UpdateFile(string path, string text)
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, text);
                return text;
            }
            else
            {
                _logger.LogError($"{path} is not a valid file or directory.");
                return null;
            }
        }

        public bool DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else
            {
                _logger.LogError($"{path} is not a valid file or directory.");
                return false;
            }
        }
    }
}
