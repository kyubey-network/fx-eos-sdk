using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Andoromeda.Framework.EosNode
{
    public class GetAccountResponse
    {
        [JsonProperty("self_delegated_bandwidth")]
        public SelfDelegatedBandwidth SelfDelegatedBandwidth { get; set; }

        [JsonProperty("refund_request")]
        public RefundRequest RefundRequest { get; set; }

        [JsonProperty("permissions")]
        public List<Permission> Permissions { get; set; }

        [JsonProperty("ram_usage")]
        public ulong? RamUsage { get; set; }

        [JsonProperty("cpu_limit")]
        public Resource CpuLimit { get; set; }

        [JsonProperty("net_limit")]
        public Resource NetLimit { get; set; }

        [JsonProperty("cpu_weight")]
        public long? CpuWeight { get; set; }

        [JsonProperty("net_weight")]
        public long? NetWeight { get; set; }

        [JsonProperty("ram_quota")]
        public long? RamQuota { get; set; }

        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        [JsonProperty("last_code_update")]
        public DateTime? LastCodeUpdate { get; set; }

        [JsonProperty("privileged")]
        public bool? Privileged { get; set; }

        [JsonProperty("head_block_time")]
        public DateTime? HeadBlockTime { get; set; }

        [JsonProperty("head_block_num")]
        public uint? HeadBlockNum { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("total_resources")]
        public TotalResources TotalResources { get; set; }

        [JsonProperty("voter_info")]
        public VoterInfo VoterInfo { get; set; }
    }

    public class SelfDelegatedBandwidth
    {
        [JsonProperty("cpu_weight")]
        public string CpuWeight { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("net_weight")]
        public string NetWeight { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }

    public class RefundRequest
    {
        [JsonProperty("cpu_amount")]
        public string CpuAmount { get; set; }

        [JsonProperty("net_amount")]
        public string NetAmount { get; set; }
    }

    public class VoterInfo
    {
        [JsonProperty("is_proxy")]
        public bool? IsProxy { get; set; }

        [JsonProperty("last_vote_weight")]
        public double? LastVoteWeight { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("producers")]
        public List<string> Producers { get; set; }

        [JsonProperty("proxied_vote_weight")]
        public double? ProxiedVoteWeight { get; set; }

        [JsonProperty("proxy")]
        public string Proxy { get; set; }

        [JsonProperty("staked")]
        public ulong? Staked { get; set; }
    }

    public class TotalResources
    {
        [JsonProperty("cpu_weight")]
        public string CpuWeight { get; set; }

        [JsonProperty("net_weight")]
        public string NetWeight { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("ram_bytes")]
        public ulong? RamBytes { get; set; }
    }

    public class Resource
    {
        [JsonProperty("used")]
        public long Used { get; set; }

        [JsonProperty("available")]
        public long Available { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }
    }

    public class Permission
    {
        [JsonProperty("perm_name")]
        public string PermName { get; set; }

        [JsonProperty("parent")]
        public string Parent { get; set; }

        [JsonProperty("required_auth")]
        public Authority RequiredAuth { get; set; }
    }

    public class Authority
    {
        [JsonProperty("threshold")]
        public uint Threshold { get; set; }

        [JsonProperty("keys")]
        public List<AuthorityKey> Keys { get; set; }

        [JsonProperty("accounts")]
        public List<AuthorityAccount> Accounts { get; set; }

        [JsonProperty("waits")]
        public List<AuthorityWait> Waits { get; set; }
    }

    public class AuthorityKey
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }

    public class AuthorityAccount
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }

    public class AuthorityWait
    {
        [JsonProperty("wait_sec")]
        public string WaitSec { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }
}
