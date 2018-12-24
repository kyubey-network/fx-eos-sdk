using Newtonsoft.Json;

namespace Andoromeda.Framework.EosNode
{
    public class GetSymbolSupplyResponse
    {
        public double Supply => double.Parse(SupplyOrdinal.Split(' ')[0]);

        [JsonProperty(PropertyName = "supply")]
        public string SupplyOrdinal { get; set; }

        public double MaxSupply => double.Parse(MaxSupplyOrdinal.Split(' ')[0]);

        [JsonProperty(PropertyName = "max_supply")]
        public string MaxSupplyOrdinal { get; set; }

        public string Issuer { get; set; }
    }
}
