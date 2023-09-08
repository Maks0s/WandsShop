using Application.Wands.Commands.Create;
using Application.Wands.Commands.Update;
using Domain.Models;
using Presentation.Common.DTO.Request;
using Presentation.Common.DTO.Response;

namespace Presentation.Common.Mapping
{
    public interface IMapper
    {
        public CreateWandCommand MapToCreateWandCommand(CreateWandRequest createWandRequest);
        public UpdateWandCommand MapToUpdateWandCommand(UpdateWandRequest updateWandRequest);

        public WandResponse MapToWandResponse(Wand wand);
        public ICollection<WandResponse> MapToCollectionOfWandResponses(ICollection<Wand> wands);
    }
}
