using MediatR;
using TODO.Models;
using TODO.UseCases.Models;

namespace TODO.UseCases.Items.AddItem;

public class AddItemCommand(AddItemRequest addItemRequest) : IRequest<ServiceResult>
{
    public AddItemRequest AddItemRequest { get; } = addItemRequest;
}