namespace FluentResults.Extensions.AspNetCore
{
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class CreatedSuccessTranslator : IActionResultTranslator<CreatedSuccess>
    {
        public ActionResult ToActionResult(ResultTranslating context)
        {
            var success = context
                .Result
                .Successes
                .OfType<CreatedSuccess>()
                .First();

            if (success.Location == null)
            {
                return context.Controller.StatusCode(StatusCodes.Status201Created, context.Value);
            }

            return context.Controller.Created(success.Location, context.Value);
        }
    }
}
