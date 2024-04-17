using Modules.Question.Core.QuestionAggregate;
using Modules.Question.Core.Tag;
using SharedKernel.Core;

namespace Modules.Question.Application.Question.QuestionSet.Delete;
internal sealed class DeleteQuestionSetCommandHandler(IQuestionSetRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteQuestionSetCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteQuestionSetCommand request, CancellationToken cancellationToken = default)
    {
        var questionSet = await repository.FirstOrDefaultAsync(x => x.QuestionSetId == request.QuestionSetId);

        if (questionSet == null)
        {
            return TagErrors.TagNotFound;
        }

        repository.Delete(questionSet);
        await unitOfWork.CommitAsync(cancellationToken);

        return true;
    }
}
