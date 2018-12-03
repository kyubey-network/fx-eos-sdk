using System;
using System.Collections.Generic;

namespace Andoromeda.Framework.EosNode
{
    public interface INodeProvider
    {
        IEnumerable<string> GetNodes();
    }
}
