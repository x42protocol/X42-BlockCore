using Newtonsoft.Json;

namespace x42.Features.xServer.Models.DNS
{
    public class DnsRecord
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

    }
}
