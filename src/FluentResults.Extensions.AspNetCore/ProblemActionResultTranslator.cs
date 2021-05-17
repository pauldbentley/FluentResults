namespace FluentResults.Extensions.AspNetCore
{
    using System.Linq;
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class ProblemErrorTranslator : IActionResultTranslator<ProblemError>
    {
        public ActionResult ToActionResult(ResultTranslating context)
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
                    error.Title);
        }
    }
}
