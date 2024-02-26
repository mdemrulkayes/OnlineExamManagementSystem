using MediatR;

namespace SharedKernel.Core;
public interface IQuery<out TResponse> : IRequest<TResponse>;
