using Application.Common.CQRS;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wands.Queries.GetAll
{
    public record GetAllWandsQuery() : IQuery<ICollection<Wand>>;
}
