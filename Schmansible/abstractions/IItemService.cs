namespace Schmansible.Abstractions
{
    public interface IItemService
    {
        string UpdateItem(string path, string contents);
        bool DeleteItem(string path);
    }
}
