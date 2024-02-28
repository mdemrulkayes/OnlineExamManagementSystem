using Modules.Identity.Features.Registration.Enums;
using SharedKernel.Core;

namespace Modules.Identity.Features.Registration.Events;
internal sealed record UserRegistered(Guid UserId, string Email, string FirstName, string LastName, UserType UserType) : IDomainEvent;
