using System;
using System.Collections.Generic;

namespace Andoromeda.Framework.EosNode
{
    public class GetActionsResponse
    {
        public IEnumerable<GetActionsResponseAction> actions { get; set; }
    }

    public class GetActionsResponseAction
    {
        public ulong global_action_seq { get; set; }

        public ulong account_action_seq { get; set; }

        public ulong block_num { get; set; }

        public DateTime block_time { get; set; }

        public GetActionsResponseActionTrace action_trace { get; set; }
    }

    public class GetActionsResponseActionTrace
    {
        public GetActionsResponseActionTraceReceipt receipt { get; set; }

        public GetActionsResponseActionTraceAct act { get; set; }

        public bool context_free { get; set; }

        public ulong elapsed { get; set; }

        public string console { get; set; }

        public string trx_id { get; set; }

        public ulong block_num { get; set; }

        public DateTime block_time { get; set; }

        public string producer_block_id { get; set; }
    }

    public class GetActionsResponseActionTraceReceipt
    {
        public string receiver { get; set; }

        public string act_digest { get; set; }

        public ulong global_sequence { get; set; }

        public ulong recv_sequence { get; set; }

        public IEnumerable<IEnumerable<object>> auth_sequence { get; set; }

        public ulong code_sequence { get; set; }

        public ulong abi_sequence { get; set; }
    }

    public class GetActionsResponseActionTraceAct
    {
        public string account { get; set; }

        public string name { get; set; }

        public IEnumerable<GetActionsResponseActionTraceActAuthorization> authorization { get; set; }

        public GetActionsResponseActionTraceActData data { get; set; }
    }

    public class GetActionsResponseActionTraceActData
    {
        public string from { get; set; }

        public string to { get; set; }

        public string quantity { get; set; }

        public string memo { get; set; }
    }

    public class GetActionsResponseActionTraceActAuthorization
    {
        public string actor { get; set; }

        public string permission { get; set; }
    }
}
