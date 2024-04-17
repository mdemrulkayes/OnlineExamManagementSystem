using AutoMapper;
using common;
using SharedKernel.Core;

namespace Modules.Question.Application.Common.Mapping;
internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(PaginatedList<>), typeof(PagedListDto<>));
    }
}
