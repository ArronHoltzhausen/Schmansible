using System.Collections.Generic;

namespace Schmansible.Services.IO
{
    public interface IFileService
    {
        List<string> GetFiles(string dir);
        string ReadFile(string path);
        string UpdateFile(string path, string text);
        bool DeleteFile(string path);
    }
}
