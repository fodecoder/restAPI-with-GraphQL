﻿using Common.GraphQL.Middlewares;
using Common.GraphQL.Options;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Common.GraphQL.Extensions
{
    public static class GraphQLMiddlewareExtensions
    {
        public static IApplicationBuilder UseGraphQL( this IApplicationBuilder builder )
        {
            return builder.UseMiddleware<GraphQLMiddleware> ();
        }

        public static IServiceCollection AddGraphQLExtension<T>( this IServiceCollection services , Action<GraphQLOptions> action ) where T : ObjectGraphType
        {
            services.AddGraphQL ( builder => builder
                .AddAutoSchema<T> ()
                .AddSystemTextJson () );

            return services.Configure ( action );
        }
    }
}
