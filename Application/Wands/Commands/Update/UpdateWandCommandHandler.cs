using Application.Common.CQRS;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wands.Commands.Update
{
    public class UpdateWandCommandHandler : ICommandHandler<UpdateWandCommand, ErrorOr.Updated>
    {
        private readonly IWandRepository _wandRepository;

        public UpdateWandCommandHandler(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        public async Task<ErrorOr<Updated>> Handle(UpdateWandCommand command, CancellationToken cancellationToken)
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

            await _wandRepository.UpdateWandAsync(wandToUpdate);

            return Result.Updated;
        }
    }
}
