using TODO.Core.Models;

namespace TODO.Core.Services;

public interface IItemService : IEntityService<Item>
{
    public Item? GetByTitle(string title);
    public void IsCompleted(Item item);
}