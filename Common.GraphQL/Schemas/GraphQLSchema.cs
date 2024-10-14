using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Common.GraphQL.Schemas
{
    public class GraphQLSchema<T> : Schema where T : ObjectGraphType
    {
        public GraphQLSchema( IServiceProvider serviceProvider ) : base ( serviceProvider )
        {
            Query = serviceProvider.GetRequiredService<T> ();
        }
    }
}
