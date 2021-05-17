namespace FluentResults.Extensions.AspNetCore
{
    using System.Linq;
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class BadRequestErrorTranslator : IActionResultTranslator<BadRequestError, ControllerResultContext>
    {
        public ActionResult ToActionResult(ControllerResultContext context)
        {
            var error = context
                .Result
                .Errors
                .OfType<BadRequestError>()
                .First();

            return context.Controller.BadRequest(error.Error);
        }
    }
}
