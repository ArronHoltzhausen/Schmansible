namespace Schmansible.abstractions
{
    public interface IItemService
    {
        string UpdateItem(int itemId);
        string DeleteItem(int itemId);
    }
}
