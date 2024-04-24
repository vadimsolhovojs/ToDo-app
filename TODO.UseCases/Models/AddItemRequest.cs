namespace TODO.Models;

public class AddItemRequest
{
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
}