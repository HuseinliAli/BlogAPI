using Application.Behaviors;
using Application.Utils.Aspects.Adapters;
using Application.Utils.Jwt;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using FluentValidation;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Module = Autofac.Module;

namespace Application
{
    public class AutofacApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.BaseType != null && t.BaseType.IsClosedTypeOf(typeof(AbstractValidator<>)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var configuration = MediatRConfigurationBuilder
                .Create(assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .WithRegistrationScope(RegistrationScope.Scoped)
                .Build();
            builder.RegisterMediatR(configuration);

            builder.RegisterGeneric(typeof(ValidationBehavior<,>))
                .As(typeof(IPipelineBehavior<,>))
                .InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(assembly)
                .Where(t => !t.IsAssignableTo<IValidator>() && !t.IsAssignableTo<IRequest>())
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                })
                .InstancePerLifetimeScope();
        }
    }
}
