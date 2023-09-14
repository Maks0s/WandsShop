using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ApplicationErrors
{
    public static class Errors
    {
        public static class DataAccess
        {
            public static Error DataAddingError() =>
                Error.Custom(
                    (int)HttpStatusCode.InternalServerError,
                    "Adding data failed",
                    "Server side error occurred while adding data. Try again later."
                    );

            public static Error EmptyReceivedDataError() =>
                Error.Custom(
                    (int)HttpStatusCode.InternalServerError,
                    "The requested data is empty",
                    "Server side error occure while fetching the data. Try again later."
                    );
        }
    }
}
