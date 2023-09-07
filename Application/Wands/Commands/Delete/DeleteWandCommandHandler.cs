using Application.Common.CQRS;
using Application.Common.Interfaces.Persistence;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _wandRepository.DeleteWandAsync(command.Id);

            return Result.Deleted;
        }
    }
}
