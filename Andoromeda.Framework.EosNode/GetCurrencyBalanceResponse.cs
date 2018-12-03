using System.Collections.Generic;

namespace Andoromeda.Framework.EosNode
{
    public class GetCurrencyBalanceResponse
    {
        public IEnumerable<GetCurrencyBalanceResponseRow> balances { get; set; }
    }

    public class GetCurrencyBalanceResponseRow
    {
        public string symbol { get; set; }

        public double amount { get; set; }
    }
}
