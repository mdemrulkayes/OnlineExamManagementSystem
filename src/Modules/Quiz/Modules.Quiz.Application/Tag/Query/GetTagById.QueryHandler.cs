﻿using AutoMapper;
using Modules.Quiz.Application.Tag.Dtos;
using Modules.Quiz.Core.Tag;
using SharedKernel.Core;

namespace Modules.Quiz.Application.Tag.Query;
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
