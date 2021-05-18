namespace FluentResults.Extensions.AspNetCore.Handlers
{
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public static class CreatedSuccessHandler
    {
        public static ActionResult Handle(ControllerResultContext context)
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
