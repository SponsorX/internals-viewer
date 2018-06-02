using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Allocations;
using InternalsViewer.Internals.Models.Metadata;

namespace InternalsViewer.Internals.Models.Engine.Database
{
    public class DatabaseContainer
    {
        public const int AllocationInterval = 511232;
        public const int PfsInterval = 8088;

        public int DatabaseId { get; set; }

        public string Name { get; set; }

        public Dictionary<int, Allocation> Gam { get; set; } = new Dictionary<int, Allocation>();

        public Dictionary<int, Allocation> SGam { get; set; } = new Dictionary<int, Allocation>();

        public Dictionary<int, Allocation> Dcm { get; set; } = new Dictionary<int, Allocation>();

        public Dictionary<int, Allocation> Bcm { get; set; } = new Dictionary<int, Allocation>();

        public Dictionary<int, PageFreeSpace> Pfs { get; set; } = new Dictionary<int, PageFreeSpace>();

        public IEnumerable<AllocationUnit> AllocationUnits = new List<AllocationUnit>();

        public IEnumerable<File> Files { get; set; }

        public bool Compatible { get; set; }

        public byte CompatibilityLevel { get; set; }
    }
}