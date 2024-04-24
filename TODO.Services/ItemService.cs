using TODO.Core;
using TODO.Core.Models;
using TODO.Core.Services;
using TODO.Data;

namespace TODO.Services;

public class ItemService : EntityService<Item>, IItemService
{
    public ItemService(IToDoDbContext context) : base(context)
    {
    }

    public Item? GetByTitle(string title)
    {
        return _context.Items
            .SingleOrDefault(item => item.Title == title);
    }
    
    public void IsCompleted(Item item)
    {
        item.IsCompleted = !item.IsCompleted;
        _context.SaveChanges();
    }
}