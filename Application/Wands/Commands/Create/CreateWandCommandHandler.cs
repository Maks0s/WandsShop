using Application.Common.CQRS;
using Application.Common.ApplicationErrors;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using ErrorOr;

namespace Application.Wands.Commands.Create
{
    public class CreateWandCommandHandler
        : ICommandHandler<CreateWandCommand, Wand?>
    {
        private readonly IWandRepository _wandRepository;

        public CreateWandCommandHandler(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        public async Task<ErrorOr<Wand?>> Handle(CreateWandCommand command, 
            CancellationToken cancellationToken)
        {
            var wandToCreate = new Wand()
            {
                Core = command.Core,
                Wood = command.Wood,
                LengthInInches = command.LengthInInches,
                Owner = command.Owner,
                Description = command.Description
            };

            Wand? createdWand = await _wandRepository.CreateWandAsync(wandToCreate);

            if(createdWand is null)
            {
                return Errors.DataAccess.DataAddingError();
            }

            return createdWand;
        }
    }
}
