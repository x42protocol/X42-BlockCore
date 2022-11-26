using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace x42.Features.xServer.Models.DNS
{
    public class RrSet
    {
        [JsonProperty("changetype")]
        public string ChangeType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ttl")]
        public int Ttl { get; set; }

        [JsonProperty("records")]
        public List<DnsRecord> Records { get; set; }
    }
}
