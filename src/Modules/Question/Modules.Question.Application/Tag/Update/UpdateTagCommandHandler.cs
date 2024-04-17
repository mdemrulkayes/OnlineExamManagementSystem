using AutoMapper;
using Modules.Question.Application.Tag.Dtos;
using Modules.Question.Core.Tag;
using SharedKernel.Core;

namespace Modules.Question.Application.Tag.Update;
internal sealed class UpdateTagCommandHandler(ITagRepository repository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ICommandHandler<UpdateTagCommand, Result<TagResponse>>
{
    public async Task<Result<TagResponse>> Handle(UpdateTagCommand request, CancellationToken cancellationToken = default)
    {
        var tag = await repository.FirstOrDefaultAsync(x => x.TagId == request.TagId);
        if (tag == null)
        {
            return TagErrors.TagNotFound;
        }

        var updatedTag = tag.Update(request.Name, request.Description);

        if (!updatedTag.IsSuccess || updatedTag.Value is null)
        {
            return updatedTag.Error;
        }

        repository.Update(updatedTag.Value);
        await unitOfWork.CommitAsync(cancellationToken);

        return mapper.Map<TagResponse>(updatedTag.Value);
    }
}
