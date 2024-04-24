using System.Net;
using AutoMapper;
using MediatR;
using TODO.Core.Services;
using TODO.UseCases.Models;

namespace TODO.UseCases.Items.DeleteItem;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, ServiceResult>
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;

    public DeleteItemCommandHandler(IItemService itemService, IMapper mapper)
    {
        _itemService = itemService;
        _mapper = mapper;
    }

    public async Task<ServiceResult> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var item = _itemService.GetById(request.Id);
        var response = new ServiceResult();

        if (item == null)
        {
            response.Status = HttpStatusCode.NotFound;
            return response;
        }
        
        _itemService.Delete(item);

        response.ResultObject = _mapper.Map<ItemViewModel>(item);
        response.Status = HttpStatusCode.OK;

        return response;
    }
}