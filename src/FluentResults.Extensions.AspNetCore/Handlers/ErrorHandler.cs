namespace FluentResults.Extensions.AspNetCore.Handlers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    public static class ErrorHandler
    {
        public static ActionResult Handle(ControllerResultContext context)
        {
            var error = context.Controller.ProblemDetailsFactory.CreateProblemDetails(
                context.Controller.HttpContext,
                statusCode: 400);

            error.Extensions["errors"] = context
                .Result
                .Errors
                .Select(e => e.Message);

            return context.Controller.BadRequest(error);
        }
    }
}
