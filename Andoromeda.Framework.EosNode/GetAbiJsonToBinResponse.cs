using Newtonsoft.Json;
using System;

namespace Andoromeda.Framework.EosNode
{
    [Serializable]
    public class GetAbiJsonToBinResponse
    {
        [JsonProperty("binargs")]
        public string Binargs { get; set; }
    }
}
