namespace FluentResults.Extensions.AspNetCore
{
    using Microsoft.AspNetCore.Mvc;

    public interface IActionResultTranslator<TContext>
    {
        ActionResult ToActionResult(TContext context);
    }
}
