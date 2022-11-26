using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x42.Features.xServer.Models.DNS
{
    public class ZoneDataModel
    {
        public List<RrSet> Rrsets { get; set; }
    }
}
