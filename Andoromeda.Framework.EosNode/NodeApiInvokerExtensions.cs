using Andoromeda.Framework.EosNode;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NodeApiInvokerExtensions
    {
        public static IServiceCollection AddEosNodeApiInvoker(this IServiceCollection self)
        {
            return self.AddSingleton<INodeProvider, DefaultNodeProvider>()
                .AddSingleton<NodeApiInvoker>();
        }
    }
}
