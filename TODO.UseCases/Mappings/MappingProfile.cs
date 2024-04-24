using AutoMapper;
using TODO.Core.Models;
using TODO.Models;
using TODO.UseCases.Models;

namespace TODO.UseCases.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddItemRequest, Item>();
        CreateMap<DeleteItemRequest, Item>();
        CreateMap<Item, ItemViewModel>();
    }
}