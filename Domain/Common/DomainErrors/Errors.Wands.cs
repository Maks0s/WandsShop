using ErrorOr;
using System.Net;

namespace Domain.Common.DomainErrors
{
    public static class Errors
    {
        public static class Wands
        {
            public static Error NotFound(int wandId) => 
                Error.Custom(
                    (int)HttpStatusCode.NotFound,
                    "Requested wand not found",
                    $"The wand with id:{wandId} not found. Correct the request"
                    );

            public static Error NotValid(string propetryName, string errorMessage) =>
                Error.Custom(
                    (int)HttpStatusCode.BadRequest,
                    "Validation failed",
                    $"{propetryName} - {errorMessage}"
                    );
        }
    }
}
