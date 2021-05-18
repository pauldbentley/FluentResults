namespace FluentResults.Extensions.AspNetCore.Handlers
{
    using Microsoft.AspNetCore.Mvc;

    public static class SuccessHandler
    {
        public static ActionResult Handle(ControllerResultContext context)
        {
            if (context.IsValueResult)
            {
                return context.Controller.Ok(context.Value);
            }

            return context.Controller.Ok();
        }
    }
}
