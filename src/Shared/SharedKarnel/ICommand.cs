using MediatR;

namespace SharedKernel.Core;

public interface ICommand<out TResponse> : IRequest<TResponse>;

public interface ICommand : IRequest;
