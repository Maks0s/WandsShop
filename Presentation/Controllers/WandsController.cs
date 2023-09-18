using Application.Wands.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common.DTO.Response;
using Presentation.Common.DTO.Request;
using Presentation.Common.Mapping;
using Application.Wands.Queries.GetById;
using Application.Wands.Commands.Delete;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class WandsController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WandsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateWand([FromBody] CreateWandRequest createWandRequest)
        {
            var creatWandCommand = _mapper.MapToCreateWandCommand(createWandRequest);

            var createResult = await _mediator.Send(creatWandCommand);

            return createResult.Match(
                created => CreatedAtAction(
                    nameof(GetWandById), 
                    new { created.Id }, 
                    _mapper.MapToWandResponse(created)
                    ),
                errors => Problem(errors)
                );
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<WandResponse>>> GetAllWands()
        {
            var getAllWandsQuery = new GetAllWandsQuery();

            var getResult = await _mediator.Send(getAllWandsQuery);

            return getResult.Match(
                received =>
                {
                    return Ok(_mapper.MapToCollectionOfWandResponses(received));
                },
                errors => Problem(errors)
                );
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<WandResponse>> GetWandById(int id)
        {
            var getWandByIdQuery = new GetWandByIdQuery(id);

            var getResult = await _mediator.Send(getWandByIdQuery);

            return getResult.Match(
                received =>
                {
                    return Ok(_mapper.MapToWandResponse(received));
                },
                errors => Problem(errors)
                );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UptadeWand(int id, [FromBody] UpdateWandRequest updateWandRequest)
        {
            var updateWandCommand = _mapper.MapToUpdateWandCommand(updateWandRequest);
            updateWandCommand.Id = id;

            var updateResult = await _mediator.Send(updateWandCommand);

            return updateResult.Match(
                updated => NoContent(),
                errors => Problem(errors)
                );
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteWand(int id)
        {
            var deleteWandCommand = new DeleteWandCommand(id);

            var deleteResult = await _mediator.Send(deleteWandCommand);

            return deleteResult.Match(
                deleted => NoContent(),
                errors => Problem(errors)
                );
        }
    }
}
