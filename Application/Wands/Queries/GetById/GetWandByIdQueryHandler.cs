using Application.Common.CQRS;
using Domain.Common.DomainErrors;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using ErrorOr;

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
