using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Schmansible.Abstractions;
using Schmansible.Models;
using Schmansible.Services.IO;
using System.Collections.Generic;

namespace Schmansible.Services
{
    public class PlayBookService : IItemService
    {
        private readonly IFileService _fileService;
        private readonly ILogger _logger;
        private readonly Settings _settings;

        public PlayBookService(IFileService fileService,
            IOptions<Settings> settings,
            ILogger<PlayBookService> logger)
        {
            _fileService = fileService;
            _settings = settings.Value;
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

        public List<PlayBook> GetPlayBooks()
        {
            string path = $"{_settings.BaseDirectory}playbooks";

            List<PlayBook> lPlayBook = new List<PlayBook>();
            var results = _fileService.GetFiles(path);
            if (results == null || results.Count == 0) return lPlayBook;
            foreach (var item in results)
            {
                lPlayBook.Add(new PlayBook()
                {
                    Location = item,
                    Name = item.Split("/")[item.Split("/").Length - 1],
                });
            }
            return lPlayBook;
        }
    }
}
