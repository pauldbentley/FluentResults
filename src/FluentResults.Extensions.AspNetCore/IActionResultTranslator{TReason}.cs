namespace FluentResults.Extensions.AspNetCore
{
    public interface IActionResultTranslator<TReason, TContext>
        : IActionResultTranslator<TContext>
    {
    }
}
