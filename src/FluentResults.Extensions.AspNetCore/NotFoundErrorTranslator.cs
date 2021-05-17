namespace FluentResults.Extensions.AspNetCore
{
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class NotFoundErrorTranslator : IActionResultTranslator<NotFoundError>
    {
        public ActionResult ToActionResult(ResultTranslating context)
        {
            return context.Controller.NotFound(context.Value);
        }
    }
}
