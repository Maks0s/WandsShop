using ErrorOr;
using System.Net;

namespace Domain.Common.DomainErrors.Wands
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

            public static Error NotValid(string propertyName, string errorMessage) =>
                Error.Custom(
                    (int)HttpStatusCode.BadRequest,
                    "Validation failed",
                    $"{propertyName}-{errorMessage}"
                    );
        }
    }
}
