using Application.Authentication.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common.DTO.AppUserDTOs.Requests;
using Presentation.Common.Mapping;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(
            IMediator mediator,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(
            RegisterRequest registerRequest
            )
        {
            var registerCommand = _mapper.MapToRegisterUserCommand(registerRequest);

            var registerResult = await _mediator.Send(registerCommand);

            return registerResult.Match(
                registered => Created(
                        HttpContext.Request.Path,
                        _mapper.MapToAuthResponse(registered)
                        ),
                errors => Problem(errors)
                );
        }
    }
}
