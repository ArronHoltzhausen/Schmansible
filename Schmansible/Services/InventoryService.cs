using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Schmansible.Abstractions;
using Schmansible.Models;
using Schmansible.Services.IO;
using System;
using System.Collections.Generic;

namespace Schmansible.Services
{
    public class InventoryService : IItemService
    {
        private readonly IFileService _fileService;
        private readonly ILogger _logger;
        private readonly Settings _settings;

        public InventoryService(IFileService fileService,
            IOptions<Settings> settings,
            ILogger<InventoryService> logger)
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

        public List<Inventory> GetInventories()
        {
            string path = $"{_settings.BaseDirectory}inventories";
            List<Inventory> lInv = new List<Inventory>();
            var results = _fileService.GetFiles(path);
            if (results == null || results.Count == 0) return lInv;
            foreach(var item in results)
            {
                lInv.Add(new Inventory()
                {
                      Location = item,
                      Name = item.Split("/")[item.Split("/").Length-1],
                });
            }
            return lInv;
        }
    }
}
