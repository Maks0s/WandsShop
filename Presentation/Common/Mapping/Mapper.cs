using Application.Wands.Commands.Create;
using Application.Wands.Commands.Update;
using Domain.Models;
using Presentation.Common.DTO.Request;
using Presentation.Common.DTO.Response;
using Riok.Mapperly.Abstractions;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Presentation.Common.Mapping
{
    [Mapper]
    public partial class Mapper : IMapper
    {
        public partial CreateWandCommand MapToCreateWandCommand(CreateWandRequest createWandRequest);
        public partial UpdateWandCommand MapToUpdateWandCommand(UpdateWandRequest updateWandRequest);

        public partial WandResponse MapToWandResponse(Wand wand);
        public ICollection<WandResponse> MapToCollectionOfWandResponses(ICollection<Wand> wands)
        {
            var wandResponseCollection = new ConcurrentQueue<WandResponse>();
            Parallel.ForEach<Wand>(wands, (wand) => 
                wandResponseCollection.Enqueue(MapToWandResponse(wand)));

            return wandResponseCollection.ToImmutableList();
        }
    }
}
