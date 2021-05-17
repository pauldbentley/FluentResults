namespace FluentResults.Extensions.AspNetCore
{
    using System;
    using System.Linq;
    using FluentResults;
    using Microsoft.Extensions.DependencyInjection;

    public class ActionResultTranslatorFactory
    {
        public ActionResultTranslatorFactory(IServiceProvider services)
        {
            Services = services;
        }

        public IServiceProvider Services { get; }

        public IActionResultTranslator GetTranslator(ResultBase result)
        {
            var customReasons = result
                .Reasons
                .Where(r => r.GetType() != typeof(Success))
                .Where(r => r.GetType() != typeof(Error));

            foreach (var reason in customReasons)
            {
                var serviceType = typeof(IActionResultTranslator<>)
                    .MakeGenericType(reason.GetType());

                var translator = Services.GetService(serviceType);

                if (translator is not null)
                {
                    return (IActionResultTranslator)translator;
                }
            }

            if (result.IsSuccess)
            {
                return Services.GetService<IActionResultTranslator<Success>>()!;
            }

            return Services.GetService<IActionResultTranslator<Error>>()!;
        }
    }
}
