using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common.DTO.AppUserDTOs.Requests;
using Presentation.Common.DTO.AppUserDTOs.Responses;
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
        public async Task<ActionResult> Register(RegisterRequest registerRequest)
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

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest loginRequest)
        {
            var loginQuery = _mapper.MapToLoginUserQuery(loginRequest);

            var loginResult = await _mediator.Send(loginQuery);

            return loginResult.Match(
                authenticated => Ok(_mapper.MapToAuthResponse(authenticated)),
                errors => Problem(errors)
                );
        }
    }
}
