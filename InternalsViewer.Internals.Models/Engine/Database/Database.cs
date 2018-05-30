using System.Collections.Generic;

namespace InternalsViewer.Internals.Models.Engine.Database
{
    public class Database
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

        public List<DatabaseFile> Files { get; set; } = new List<DatabaseFile>();

        public bool Compatible { get; set; }

        public byte CompatibilityLevel { get; set; }

        public string ConnectionString { get; set; }
    }
}