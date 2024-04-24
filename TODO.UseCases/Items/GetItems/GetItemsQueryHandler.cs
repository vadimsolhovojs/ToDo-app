using System.Net;
using AutoMapper;
using MediatR;
using TODO.Core.Services;
using TODO.UseCases.Models;

namespace TODO.UseCases.Items.GetItems;

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, ServiceResult>
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;

    public GetItemsQueryHandler(IItemService itemService, IMapper mapper)
    {
        _itemService = itemService;
        _mapper = mapper;
    }

    public async Task<ServiceResult> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var response = new ServiceResult();
        var result = _itemService.GetAll();
        
        response.ResultObject = _mapper.Map<IEnumerable<ItemViewModel>>(result);
        response.Status = HttpStatusCode.OK;

        return response;
    }
}