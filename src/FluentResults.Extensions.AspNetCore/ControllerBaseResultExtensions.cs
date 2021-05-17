namespace Microsoft.AspNetCore.Mvc
{
    using FluentResults;
    using FluentResults.Extensions.AspNetCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ControllerBaseResultExtensions
    {
        public static ActionResult Result(
            this ControllerBase controller,
            ResultBase result)
        {
            var context = new ControllerResultContext(controller, result);

            var factory = controller
                .HttpContext
                .RequestServices
                .GetRequiredService<ActionResultTranslatorFactory<ControllerResultContext>>();

            var translator = factory.GetTranslator(result);
            return translator.ToActionResult(context);
        }
    }
}
