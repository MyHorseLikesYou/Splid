using MediatR;
using Splid.Domain.Main.Services;

namespace Splid.Application.Handlers.Commands.Groups
{
    public abstract class GroupCommandHandler<TRequest> : AsyncRequestHandler<TRequest>
        where TRequest : IRequest
    {
        protected GroupsService _groupsService;

        protected GroupCommandHandler(GroupsService groupsService)
        {
            _groupsService = groupsService;
        }
    }
}
