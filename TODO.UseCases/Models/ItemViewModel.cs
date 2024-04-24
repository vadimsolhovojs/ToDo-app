namespace TODO.UseCases.Models;

public class ItemViewModel
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required bool IsCompleted { get; set; }
}