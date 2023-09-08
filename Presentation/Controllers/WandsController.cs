using Application.Wands.Commands.Create;
using Application.Wands.Queries.GetAll;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common.DTO.Response;
using Presentation.Common.DTO.Request;
using Presentation.Common.Mapping;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WandsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<WandResponse>>> GetAllWands()
        {
            var getAllWandsQuery = new GetAllWandsQuery();

            var getResult = await _mediator.Send(getAllWandsQuery);

            return getResult.MatchFirst(
                received =>
                {
                    return Ok(_mapper.MapToCollectionOfWandResponses(received));
                },
                error => Problem());
        }
    }
}
