using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Infrastructure.Extensions;

public static class MediatrEndpointExtensions
{
    public static RouteGroupBuilder MediateGet<TRequest, TResponse>(this RouteGroupBuilder routeBuilder,
        string template, bool requireAuthorization = true) where TRequest : IRequest<TResponse>
    {
        routeBuilder
            .MapGet(template, (IMediator mediator, [AsParameters] TRequest request) => mediator.Send(request));
        return routeBuilder;
    }

    public static RouteGroupBuilder MediatePost<TRequest, TResponse>(this RouteGroupBuilder routeBuilder,
        string template, bool requireAuthorization = true) where TRequest : IRequest<TResponse>
    {
        routeBuilder
            .MapPost(template, (IMediator mediator, [FromBody] TRequest request) => mediator.Send(request));
        return routeBuilder;
    }

    public static RouteGroupBuilder MediatePut<TRequest, TResponse>(this RouteGroupBuilder routeBuilder,
        string template, bool requireAuthorization = true) where TRequest : IRequest<TResponse>
    {
        routeBuilder
            .MapPut(template, (IMediator mediator, [FromBody] TRequest request) => mediator.Send(request));
        return routeBuilder;
    }

    public static RouteGroupBuilder MediateDelete<TRequest, TResponse>(this RouteGroupBuilder routeBuilder,
        string template, bool requireAuthorization = true) where TRequest : IRequest<TResponse>
    {
        routeBuilder
            .MapDelete(template, (IMediator mediator, [AsParameters] TRequest request) => mediator.Send(request));
        return routeBuilder;
    }
}