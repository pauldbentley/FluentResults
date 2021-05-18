namespace FluentResults.Extensions.AspNetCore.Handlers
{
    using Microsoft.AspNetCore.Mvc;

    public static class NotFoundErrorHandler
    {
        public static ActionResult Handle(ControllerResultContext context)
        {
            return context.Controller.NotFound(context.Value);
        }
    }
}
