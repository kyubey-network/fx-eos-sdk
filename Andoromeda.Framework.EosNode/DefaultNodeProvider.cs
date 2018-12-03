using System;
using System.Collections.Generic;
using System.Text;

namespace Andoromeda.Framework.EosNode
{
    public class DefaultNodeProvider : INodeProvider
    {
        public virtual IEnumerable<string> GetNodes()
        {
            return new[] { "http://eos.greymass.com" };
        }
    }
}
