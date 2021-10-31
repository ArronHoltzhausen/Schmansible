namespace Schmansible.Abstractions
{
    public interface IItemService
    {
        string UpdateItem(int itemId);
        string DeleteItem(int itemId);
    }
}
