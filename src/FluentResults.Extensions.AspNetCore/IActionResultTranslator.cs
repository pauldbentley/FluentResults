namespace FluentResults.Extensions.AspNetCore
{
    using Microsoft.AspNetCore.Mvc;

    public interface IActionResultTranslator
    {
        ActionResult ToActionResult(ResultTranslating context);
    }
}
