using Application.Common.CQRS;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Domain.Common.DomainErrors;
using ErrorOr;

namespace Application.Wands.Commands.Update
{
    public class UpdateWandCommandHandler 
        : ICommandHandler<UpdateWandCommand, ErrorOr.Updated>
    {
        private readonly IWandRepository _wandRepository;

        public UpdateWandCommandHandler(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        public async Task<ErrorOr<Updated>> Handle(UpdateWandCommand command, 
            CancellationToken cancellationToken)
        {
            var wandToUpdate = new Wand()
            {
                Id = command.Id,
                Core = command.Core,
                Wood = command.Wood,
                LengthInInches = command.LengthInInches,
                Owner = command.Owner,
                Description = command.Description
            };

            int updatedWandsCount = 
                await _wandRepository.UpdateWandAsync(wandToUpdate);

            if (updatedWandsCount == 0)
            {
                return Errors.Wands.NotFound(command.Id);
            }

            return Result.Updated;
        }
    }
}
