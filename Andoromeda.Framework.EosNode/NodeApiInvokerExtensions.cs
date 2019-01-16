using Andoromeda.Framework.EosNode;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NodeApiInvokerExtensions
    {
        public static IServiceCollection AddEosNodeApiInvoker(this IServiceCollection self, string nodeAddress = null)
        {
            if (string.IsNullOrWhiteSpace(nodeAddress))
            {
                return self.AddSingleton<INodeProvider, DefaultNodeProvider>()
                           .AddSingleton<NodeApiInvoker>();
            }
            return self.AddSingleton<NodeApiInvoker>(x => new NodeApiInvoker(nodeAddress));
        }
    }
}
