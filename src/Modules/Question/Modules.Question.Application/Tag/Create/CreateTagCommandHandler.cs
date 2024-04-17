using AutoMapper;
using Modules.Question.Application.Tag.Dtos;
using Modules.Question.Core.Tag;
using SharedKernel.Core;

namespace Modules.Question.Application.Tag.Create;
internal sealed class CreateTagCommandHandler(ITagRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<CreateTagCommand, Result<TagResponse>>
{
    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<Result<TagResponse>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = Core.Tag.Tag.Create(request.Name, request.Description);

        if (!tag.IsSuccess || tag.Value is null)
        {
            return tag.Error;
        }

        var dataTag = tag.Value;

        repository.Add(dataTag);
        await unitOfWork.CommitAsync(cancellationToken);

        return mapper.Map<Core.Tag.Tag, TagResponse>(dataTag);
    }
}
