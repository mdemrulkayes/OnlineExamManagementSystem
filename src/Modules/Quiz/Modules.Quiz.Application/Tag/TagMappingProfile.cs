using AutoMapper;
using Modules.Quiz.Application.Tag.Dtos;

namespace Modules.Quiz.Application.Tag;
internal sealed class TagMappingProfile : Profile
{
    public TagMappingProfile()
    {
        CreateMap<Core.Tag.Tag, TagResponse>()
            .ConstructUsing(tag => new TagResponse(
                tag.TagId,
                tag.Name,
                tag.Description
            ))
            .ReverseMap();
    }
}
