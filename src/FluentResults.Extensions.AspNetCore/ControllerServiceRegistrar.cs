namespace FluentResults.Extensions.AspNetCore
{
    using FluentResults.Extensions.AspNetCore.Handlers;
    using Microsoft.Extensions.DependencyInjection;

    public static class ControllerServiceRegistrar
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.Configure<FluentResultOptions>(options =>
            {
                options.ControllerEvents.RegisterHandler<BadRequestError>(BadRequestErrorHandler.Handle);
                options.ControllerEvents.RegisterHandler<CreatedSuccess>(CreatedSuccessHandler.Handle);
                options.ControllerEvents.RegisterHandler<Error>(ErrorHandler.Handle);
                options.ControllerEvents.RegisterHandler<ForbidError>(ForbidErrorHandler.Handle);
                options.ControllerEvents.RegisterHandler<NotFoundError>(NotFoundErrorHandler.Handle);
                options.ControllerEvents.RegisterHandler<ProblemError>(ProblemErrorHandler.Handle);
                options.ControllerEvents.RegisterHandler<Success>(SuccessHandler.Handle);
                options.ControllerEvents.RegisterHandler<ValidationProblemError>(ValidationProblemErrorHandler.Handle);
            });

            return services;
        }
    }
}
