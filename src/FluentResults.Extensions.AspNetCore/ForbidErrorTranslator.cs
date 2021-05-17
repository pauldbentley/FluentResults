namespace FluentResults.Extensions.AspNetCore
{
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class ForbidErrorTranslator : IActionResultTranslator<ForbidError>
    {
        public ActionResult ToActionResult(ResultTranslating context)
        {
            return context.Controller.Forbid();
        }
    }
}
