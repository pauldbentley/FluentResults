namespace FluentResults.Extensions.AspNetCore.Handlers
{
    using System.Linq;
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public static class ValidationProblemErrorHandler
    {
        public static ActionResult Handle(ControllerResultContext context)
        {
            var validationErrors = context
                .Result
                .Errors
                .OfType<ValidationProblemError>();

            foreach (var validationError in validationErrors)
            {
                context.Controller.ModelState.AddModelError(validationError.Key ?? string.Empty, validationError.Message);
            }

            var generalErrors = context
                .Result
                .Errors
                .Where(r => r.GetType() == typeof(Error))
                .Select(e => e.Message)
                .Where(e => e is not null);

            string detail = string.Join(" ", generalErrors);
            return context.Controller.ValidationProblem(detail: detail);
        }
    }
}
