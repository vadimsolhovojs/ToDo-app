using MediatR;
using TODO.UseCases.Models;

namespace TODO.UseCases.Items.DeleteItem;

public class DeleteItemCommand(int id) : IRequest<ServiceResult>
{
    public int Id { get; } = id;
}