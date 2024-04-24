using System.Net;
using MediatR;
using TODO.Core.Services;
using TODO.UseCases.Models;

namespace TODO.UseCases.Items.DeleteAll;

public class DeleteAllCommandHandler : IRequestHandler<DeleteAllCommand, ServiceResult>
{
    private readonly IItemService _itemService;

    public DeleteAllCommandHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<ServiceResult> Handle(DeleteAllCommand request, CancellationToken cancellationToken)
    {
        _itemService.DeleteAll();
        var response = new ServiceResult
        {
            ResultObject = _itemService.GetAll(),
            Status = HttpStatusCode.OK
        };

        return response;
    }
}