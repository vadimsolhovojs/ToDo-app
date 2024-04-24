namespace TODO.Core.Models;

public class Item : Entity
{
    public required string Title { get; set; }
    public required bool IsCompleted { get; set; }
}