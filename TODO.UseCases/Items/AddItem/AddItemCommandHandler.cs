using System.Net;
using AutoMapper;
using FluentValidation;
using MediatR;
using TODO.Core.Models;
using TODO.Core.Services;
using TODO.Models;
using TODO.UseCases.Models;

namespace TODO.UseCases.Items.AddItem;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand, ServiceResult>
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;
    private readonly IValidator<AddItemRequest> _validator;

    public AddItemCommandHandler(IItemService itemService, IMapper mapper, IValidator<AddItemRequest> validator)
    {
        _itemService = itemService;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<ServiceResult> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.AddItemRequest, cancellationToken);
        var response = new ServiceResult();
        if (!validationResult.IsValid)
        {
            response.Status = HttpStatusCode.BadRequest;
            response.ResultObject = validationResult.Errors;
            return response;
        }
        
        var item = _mapper.Map<Item>(request.AddItemRequest);
        
        _itemService.Create(item);
        
        response.Status = HttpStatusCode.Created;
        response.ResultObject = _mapper.Map<ItemViewModel>(item);

        return response;
    }
}