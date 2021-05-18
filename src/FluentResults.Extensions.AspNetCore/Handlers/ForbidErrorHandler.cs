namespace FluentResults.Extensions.AspNetCore.Handlers
{
    using Microsoft.AspNetCore.Mvc;

    public static class ForbidErrorHandler
    {
        public static ActionResult Handle(ControllerResultContext context)
        {
            return context.Controller.Forbid();
        }
    }
}
