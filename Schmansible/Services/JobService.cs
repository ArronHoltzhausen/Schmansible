using Microsoft.Extensions.Logging;
using Schmansible.Abstractions;
using Schmansible.Services.IO;
using System;

namespace Schmansible.Services
{
    public class JobService : IItemService
    {
        private readonly IFileService _fileService;
        private readonly ILogger _logger;

        public JobService(IFileService fileService, ILogger<JobService> logger)
        {
            _fileService = fileService;
            _logger = logger;
        }

        public bool DeleteItem(string path)
        {
            return _fileService.DeleteFile(path);
        }

        public string UpdateItem(string path, string contents)
        {
            return _fileService.UpdateFile(path, contents);
        }
    }
}
