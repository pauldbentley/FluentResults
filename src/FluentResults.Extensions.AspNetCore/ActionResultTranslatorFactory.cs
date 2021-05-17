namespace FluentResults.Extensions.AspNetCore
{
    using System;
    using System.Linq;
    using FluentResults;
    using Microsoft.Extensions.DependencyInjection;

    public class ActionResultTranslatorFactory<TContext>
    {
        public ActionResultTranslatorFactory(IServiceProvider services)
        {
            Services = services;
        }

        public IServiceProvider Services { get; }

        public IActionResultTranslator<TContext> GetTranslator(ResultBase result)
        {
            var customReasons = result
                .Reasons
                .Where(r => r.GetType() != typeof(Success))
                .Where(r => r.GetType() != typeof(Error));

            foreach (var reason in customReasons)
            {
                var serviceType = typeof(IActionResultTranslator<,>)
                    .MakeGenericType(
                        reason.GetType(),
                        typeof(TContext));

                var translator = Services.GetService(serviceType) as IActionResultTranslator<TContext>;

                if (translator is not null)
                {
                    return translator;
                }
            }

            if (result.IsSuccess)
            {
                return Services.GetService<IActionResultTranslator<Success, TContext>>()!;
            }

            return Services.GetService<IActionResultTranslator<Error, TContext>>()!;
        }
    }
}
