namespace Microsoft.AspNetCore.Mvc
{
    using System.Linq;
    using FluentResults;
    using FluentResults.Extensions.AspNetCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    public static class ControllerBaseResultExtensions
    {
        public static ActionResult Result(
            this ControllerBase controller,
            ResultBase result)
        {
            var context = new ControllerResultContext(controller, result);

            var options = controller
                .HttpContext
                .RequestServices
                .GetRequiredService<IOptions<FluentResultOptions>>();

            var events = options.Value.ControllerEvents;

            var customReasons = result
                .Reasons
                .Where(r => r.GetType() != typeof(Success))
                .Where(r => r.GetType() != typeof(Error));

            foreach (var reason in customReasons)
            {
                if (events.Handlers.ContainsKey(reason.GetType()))
                {
                    var handler = events.Handlers[reason.GetType()];
                    return handler(context);
                }
            }

            if (result.IsSuccess)
            {
                return options.Value.ControllerEvents.OnSuccess(context);
            }

            return options.Value.ControllerEvents.OnFailed(context);
        }
    }
}
