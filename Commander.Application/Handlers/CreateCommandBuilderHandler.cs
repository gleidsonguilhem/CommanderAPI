using System.Threading;
using System.Threading.Tasks;
using Commander.Application.Commands;
using Commander.Data.Interfaces;
using MediatR;
using Commander.Domain;

namespace Commander.Application.Handlers
{
    public class CreateCommandBuilderHandler : IRequestHandler<CommanderBuilderCommand, Unit>
    {
        private IRepository _repo;

        public CreateCommandBuilderHandler(IRepository repo)
        {
            _repo = repo;
        }

        public Task<Unit> Handle(CommanderBuilderCommand request, CancellationToken cancellationToken)
        {
            var commandBuilder = CommandBuilder.Create(request.Command, request.Function, request.Platform, request.Application, request.User, request.Created, request.AdminRequired);
            _repo.Add(commandBuilder);

            return Task<Unit>.FromResult(Unit.Value);
        }
    }
}
