using Application.Common.CQRS;
using Application.Common.ApplicationErrors.DataAccess;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using ErrorOr;

namespace Application.Wands.Queries.GetAll
{
    internal class GetAllWandsQueryHandler : IQueryHandler<GetAllWandsQuery, ICollection<Wand>>
    {
        private readonly IWandRepository _wandRepository;

        public GetAllWandsQueryHandler(IWandRepository wandRepository)
        {
            _wandRepository = wandRepository;
        }

        public async Task<ErrorOr<ICollection<Wand>>> Handle(GetAllWandsQuery query, CancellationToken cancellationToken)
        {
            var allWands = await _wandRepository.GetAllWandsAsync();

            if(allWands.Count == 0)
            {
                return Errors.DataAccess.EmptyReceivedDataError();
            }

            return ErrorOrFactory.From(allWands);
        }
    }
}
