namespace FileServer.Application
{
    using MediatR;
    using Common.Behaviors;
    using FluentValidation;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}