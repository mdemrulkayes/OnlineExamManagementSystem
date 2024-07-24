using AutoMapper;
using Modules.Quiz.Application.Tag.Dtos;
using Modules.Quiz.Core.Tag;
using Shared.Application;
using Shared.Core;

namespace Modules.Quiz.Application.Tag.Query;
internal sealed class GetAllTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
    : IQueryHandler<GetAllTagQuery, Result<PagedListDto<TagResponse>>>
{
    public async Task<Result<PagedListDto<TagResponse>>> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
    {
        var tags = await tagRepository.GetAllAsync(pageNumber: request.PageNumber, pageSize: request.PageSize,
            cancellationToken: cancellationToken);

        return mapper.Map<PagedListDto<TagResponse>>(tags);
    }
}
