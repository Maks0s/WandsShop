using Application.Common.CQRS;
using Application.Common.Interfaces.Persistence;
using Domain.Models;
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
            var wandToUpdate = await _wandRepository.GetWandByIdAsync(command.Id);

            MapToWandToUpdate(wandToUpdate, command);

            await _wandRepository.UpdateWandAsync(wandToUpdate);

            return Result.Updated;
        }

        private void MapToWandToUpdate(Wand wandToUpdate, UpdateWandCommand command)
        {
            if(command.Core  != null)
            {
                wandToUpdate.Core = command.Core;
            }

            if (command.Wood != null)
            {
                wandToUpdate.Wood = command.Wood;
            }

            if (command.LengthInInches != null)
            {
                wandToUpdate.LengthInInches = (decimal)command.LengthInInches;
            }

            if (command.Owner != null)
            {
                wandToUpdate.Owner = command.Owner;
            }

            if (command.Description != null)
            {
                wandToUpdate.Description = command.Description;
            }
        }
    }
}
