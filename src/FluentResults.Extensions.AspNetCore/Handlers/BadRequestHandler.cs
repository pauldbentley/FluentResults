namespace FluentResults.Extensions.AspNetCore.Handlers
{
    using System.Linq;
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public static class BadRequestErrorHandler
    {
        public static ActionResult Handle(ControllerResultContext context)
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
