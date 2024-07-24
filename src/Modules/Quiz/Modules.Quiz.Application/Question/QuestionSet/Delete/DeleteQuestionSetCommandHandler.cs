using Modules.Quiz.Core.QuestionAggregate;
using Modules.Quiz.Core.Tag;
using SharedKernel.Core;

namespace Modules.Quiz.Application.Question.QuestionSet.Delete;
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
