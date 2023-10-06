using Application.Common.CQRS;
using Domain.Entities;

namespace Application.Wands.Queries.GetAll
{
    public record GetAllWandsQuery() : IQuery<ICollection<Wand>>;
}
