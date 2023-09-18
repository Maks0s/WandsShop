using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Presentation.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult Problem(List<Error> errors)
        {
            if(errors.TrueForAll(error => error.Code.Equals("Validation failed")))
            {
                var modelStateDictionary = new ModelStateDictionary();
                foreach(var error in errors)
                {
                    var errorPropertyAndMessage = error.Description.Split('-');
                    modelStateDictionary.AddModelError(
                        errorPropertyAndMessage[0],
                        errorPropertyAndMessage[1]);
                }

                return ValidationProblem(modelStateDictionary);
            }

            var firstError = errors[0];

            return Problem(
                title: firstError.Code,
                detail: firstError.Description,
                instance: Request.Path.Value,
                statusCode: firstError.NumericType
                );
        }
    }
}
