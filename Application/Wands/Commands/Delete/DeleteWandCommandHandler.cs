using Application.Common.CQRS;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using ErrorOr;

namespace Application.Wands.Commands.Delete
{
    internal class DeleteWandCommandHandler : ICommandHandler<DeleteWandCommand, ErrorOr.Deleted>
    {
        private readonly IWandRepository _wandRepository;

        public DeleteWandCommandHandler(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(DeleteWandCommand command, CancellationToken cancellationToken)
        {
            int deletedWandsCount = await _wandRepository.DeleteWandAsync(command.Id);

            if (deletedWandsCount == 0)
            {
                return Errors.Wands.NotFound(command.Id);
            }

            return Result.Deleted;
        }
    }
}
