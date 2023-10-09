using Application.Authentication.Commands.Register;
using Application.Authentication.Common;
using Application.Wands.Commands.Create;
using Application.Wands.Commands.Update;
using Domain.Entities;
using Presentation.Common.DTO.AppUserDTOs.Requests;
using Presentation.Common.DTO.AppUserDTOs.Responses;
using Presentation.Common.DTO.WandDTOs.Requests;
using Presentation.Common.DTO.WandDTOs.Responses;

namespace Presentation.Common.Mapping
{
    public interface IMapper
    {
        public CreateWandCommand MapToCreateWandCommand(CreateWandRequest createWandRequest);
        public UpdateWandCommand MapToUpdateWandCommand(UpdateWandRequest updateWandRequest);

        public WandResponse MapToWandResponse(Wand wand);
        public ICollection<WandResponse> MapToCollectionOfWandResponses(ICollection<Wand> wands);


        public RegisterUserCommand MapToRegisterUserCommand(RegisterRequest registerRequest);

        public AuthResponse MapToAuthResponse(AuthResult authResponse);
    }
}
