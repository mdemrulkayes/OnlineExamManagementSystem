using AutoMapper;
using Modules.Question.Application.Tag.Dtos;
using Modules.Question.Core.Tag;
using SharedKernel.Core;

namespace Modules.Question.Application.Tag.Query;
internal class GetTagByIdQueryHandler(ITagRepository repository,
    IMapper mapper) : IQueryHandler<GetTagByIdQuery, Result<TagResponse>>
{
    public async Task<Result<TagResponse>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var tagDetails = await repository.FirstOrDefaultAsync(x => x.TagId == request.TagId);
        if (tagDetails == null)
        {
            return TagErrors.TagNotFound;
        }

        return mapper.Map<TagResponse>(tagDetails);
    }
}
