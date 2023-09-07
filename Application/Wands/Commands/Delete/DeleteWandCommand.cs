using Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wands.Commands.Delete
{
    public record DeleteWandCommand(int Id) : ICommand<ErrorOr.Deleted>;
}
