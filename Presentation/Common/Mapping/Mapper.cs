using Application.Wands.Commands.Create;
using Application.Wands.Commands.Update;
using Domain.Entities;
using Presentation.Common.DTO.WandDTOs.Requests;
using Presentation.Common.DTO.WandDTOs.Responses;
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
            var wandResponseCollection = new List<WandResponse>();

            foreach(var wand in wands)
            {
                wandResponseCollection.Add(MapToWandResponse(wand));
            }

            return wandResponseCollection;
        }
    }
}
