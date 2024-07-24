using AutoMapper;
using Shared.Application;
using SharedKernel.Core;

namespace Modules.Quiz.Application.Common.Mapping;
internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(PaginatedList<>), typeof(PagedListDto<>));
    }
}
