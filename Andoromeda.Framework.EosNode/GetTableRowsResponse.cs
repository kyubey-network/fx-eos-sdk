using System.Collections.Generic;

namespace Andoromeda.Framework.EosNode
{
    public class GetTableRowsResponse<T>
    {
        public IEnumerable<T> data { get; set; }
        public bool more { get; set; }
    }

    public class GetTableByScopeResponse
    {
        public IEnumerable<GetTableByScopeResponseRow> data { get; set; }
        public string more { get; set; }
    }

    public class GetTableByScopeResponseRow
    {
        public string code { get; set; }

        public string scope { get; set; }

        public string table { get; set; }

        public string payer { get; set; }

        public ulong count { get; set; }
    }
}
