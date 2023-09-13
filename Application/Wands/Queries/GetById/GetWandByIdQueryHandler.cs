using Application.Common.CQRS;
using Domain.Common.Errors;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wands.Queries.GetById
{
    public class GetWandByIdQueryHandler : IQueryHandler<GetWandByIdQuery, Wand?>
    {
        private readonly IWandRepository _wandRepository;

        public GetWandByIdQueryHandler(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        public async Task<ErrorOr<Wand?>> Handle(GetWandByIdQuery query, CancellationToken cancellationToken)
        {
            Wand? wand = await _wandRepository.GetWandByIdAsync(query.Id);

            if(wand is null)
            {
                return Errors.Wands.NotFound(query.Id);
            }

            return wand;
        }

    }
}
