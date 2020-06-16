using Microsoft.AspNetCore.Http;
using Broker.Domain.Extensions;

namespace Broker.API.Extensions
{
    public class BusinessRuleValidationExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            this.Title = "Erro de validação de regra de negócios";
            this.Status = StatusCodes.Status409Conflict;
            this.Detail = exception.Details;
            this.Type = "";
        }
    }
}