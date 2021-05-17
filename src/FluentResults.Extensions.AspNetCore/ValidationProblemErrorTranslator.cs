namespace FluentResults.Extensions.AspNetCore
{
    using System.Linq;
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class ValidationProblemErrorTranslator : IActionResultTranslator<ValidationProblemError>
    {
        public ActionResult ToActionResult(ResultTranslating context)
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
