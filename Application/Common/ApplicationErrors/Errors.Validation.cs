using ErrorOr;
using System.Net;

namespace Application.Common.ApplicationErrors.Validation
{
    public static class Errors
    {
        public static class Validation
        {
            public static Error NotValid(string propertyName, string errorMessage) =>
                Error.Custom(
                    (int)HttpStatusCode.BadRequest,
                    "Validation failed",
                    $"{propertyName}-{errorMessage}"
                    );
        }
    }
}
