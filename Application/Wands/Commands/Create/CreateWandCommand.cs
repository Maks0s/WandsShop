using Application.Common.CQRS;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wands.Commands.Create
{
    public record CreateWandCommand(
        string Core,
        string Wood,
        decimal LengthInInches,
        string? Owner,
        string Description
        ) : ICommand<Wand>;
}
