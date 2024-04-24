using System.Net;
using AutoMapper;
using MediatR;
using TODO.Core.Models;
using TODO.Core.Services;
using TODO.UseCases.Models;

namespace TODO.UseCases.Items.MarkAsDone;

public class MarkAsDoneCommandHandler : IRequestHandler<MarkAsDoneCommand, ServiceResult>
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;

    public MarkAsDoneCommandHandler(IItemService itemService, IMapper mapper)
    {
        _itemService = itemService;
        _mapper = mapper;
    }

    public async Task<ServiceResult> Handle(MarkAsDoneCommand request, CancellationToken cancellationToken)
    {
        var item = _itemService.GetById(request.Id);
        var response = new ServiceResult();

        if (item == null)
        {
            response.Status = HttpStatusCode.NotFound;
            return response;
        }
        
        _itemService.IsCompleted(item);

        response.ResultObject = _mapper.Map<ItemViewModel>(item);
        response.Status = HttpStatusCode.OK;

        return response;
    }
}