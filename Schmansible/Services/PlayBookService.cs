using Microsoft.Extensions.Logging;
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

        public PlayBookService(IFileService fileService,
            ILogger<PlayBookService> logger)
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

        public List<PlayBook> GetPlayBooks(string path = "/mnt/c/Users/arron/schman/playbooks")
        {
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
