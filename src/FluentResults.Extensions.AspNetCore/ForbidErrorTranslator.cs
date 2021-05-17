namespace FluentResults.Extensions.AspNetCore
{
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class ForbidErrorTranslator : IActionResultTranslator<ForbidError, ControllerResultContext>
    {
        public ActionResult ToActionResult(ControllerResultContext context)
        {
            return context.Controller.Forbid();
        }
    }
}
