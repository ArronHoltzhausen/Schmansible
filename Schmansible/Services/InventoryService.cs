using Microsoft.Extensions.Logging;
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

        public InventoryService(IFileService fileService,
            ILogger<InventoryService> logger)
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

        public List<Inventory> GetInventories(string path = "/mnt/c/Users/arron/schman/inventories")
        {
            List<Inventory> lInv = new List<Inventory>();
            var results = _fileService.GetFiles(path);
            if (results.Count == 0) return lInv;
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
