using Application.Common.CQRS;
using Domain.Entities;

namespace Application.Wands.Queries.GetById
{
    public record GetWandByIdQuery(int Id) : IQuery<Wand?>;
}
