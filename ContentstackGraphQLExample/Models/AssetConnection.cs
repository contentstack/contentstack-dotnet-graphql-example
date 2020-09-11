using System.Collections.Generic;

namespace ContentstackGraphQLExample.Models
{
    public class AssetConnection
    {
        public int totalCount { get; set; }

        public List<AssetEdge> edges { get; set; }
    }
}
