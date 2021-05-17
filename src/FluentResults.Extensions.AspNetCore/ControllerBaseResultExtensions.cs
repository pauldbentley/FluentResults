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
            var context = new ResultTranslating(result, controller);

            var factory = controller
                .HttpContext
                .RequestServices
                .GetRequiredService<ActionResultTranslatorFactory>();

            var translator = factory.GetTranslator(result);
            return translator.ToActionResult(context);
        }
    }
}
