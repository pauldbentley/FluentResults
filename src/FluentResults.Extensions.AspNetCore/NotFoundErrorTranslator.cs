namespace FluentResults.Extensions.AspNetCore
{
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class NotFoundErrorTranslator : IActionResultTranslator<NotFoundError, ControllerResultContext>
    {
        public ActionResult ToActionResult(ControllerResultContext context)
        {
            return context.Controller.NotFound(context.Value);
        }
    }
}
