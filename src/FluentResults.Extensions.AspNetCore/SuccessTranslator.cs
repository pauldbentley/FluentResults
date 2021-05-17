namespace FluentResults.Extensions.AspNetCore
{
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class SuccessTranslator : IActionResultTranslator<Success, ControllerResultContext>
    {
        public ActionResult ToActionResult(ControllerResultContext context)
        {
            if (context.IsValueResult)
            {
                return context.Controller.Ok(context.Value);
            }

            return context.Controller.Ok();
        }
    }
}
