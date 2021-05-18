namespace FluentResults.Extensions.AspNetCore.Handlers
{
    using System.Linq;
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public static class ProblemErrorHandler
    {
        public static ActionResult Handle(ControllerResultContext context)
        {
            var error = context
                .Result
                .Errors
                .OfType<ProblemError>()
                .First();

            return context.Controller.Problem(
                    error.Detail,
                    error.Instance,
                    error.StatusCode,
                    error.Title,
                    error.Type);
        }
    }
}
