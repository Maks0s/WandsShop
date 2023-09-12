using Application.Common.CQRS;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wands.Queries.GetById
{
    public record GetWandByIdQuery(int Id) : IQuery<Wand>;
}
