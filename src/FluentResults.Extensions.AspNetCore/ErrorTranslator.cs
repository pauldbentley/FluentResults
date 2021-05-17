namespace FluentResults.Extensions.AspNetCore
{
    using System.Linq;
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class ErrorTranslator : IActionResultTranslator<Error>
    {
        public ActionResult ToActionResult(ResultTranslating context)
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
