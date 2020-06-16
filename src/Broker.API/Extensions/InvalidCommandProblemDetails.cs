using Microsoft.AspNetCore.Http;
using Broker.Application.Configuration.Validation;

namespace Broker.API.Extensions
{
    public class InvalidCommandProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public InvalidCommandProblemDetails(InvalidCommandException exception)
        {
            this.Title = exception.Message;
            this.Status = StatusCodes.Status400BadRequest;
            this.Detail = exception.Details;
            this.Type = "";
        }
    }
}