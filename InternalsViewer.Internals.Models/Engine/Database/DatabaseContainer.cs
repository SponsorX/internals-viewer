using System.Collections.Generic;
using InternalsViewer.Internals.Models.Metadata;

namespace InternalsViewer.Internals.Models.Engine.Database
{
    public class DatabaseContainer
    {
        public const int AllocationInterval = 511232;
        public const int PfsInterval = 8088;

        public int DatabaseId { get; set; }

        public string Name { get; set; }

        public Dictionary<int, Allocation> Gam { get; set; }

        public Dictionary<int, Allocation> SGam { get; set; }

        public Dictionary<int, Allocation> Dcm { get; set; }

        public Dictionary<int, Allocation> Bcm { get; set; }

        public Dictionary<int, Pfs> Pfs { get; set; }

        public IEnumerable<File> Files { get; set; }

        public bool Compatible { get; set; }

        public byte CompatibilityLevel { get; set; }
    }
}