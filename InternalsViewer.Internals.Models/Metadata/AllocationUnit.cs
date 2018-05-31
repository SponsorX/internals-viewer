using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Metadata
{
    public class AllocationUnit
    {
        public long ObjectId { get; set; }

        public PageAddress FirstIamPage { get; set; }

        public string SchemaName { get; set; }

        public string TableName { get; set; }

        public string IndexName { get; set; }

        public bool IsSystemObject { get; set; }

        public long IndexId { get; set; }

        public string IndexType { get; set; }

        public AllocationUnitType AllocationUnitType { get; set; }

        public int UsedPages { get; set; }

        public int TotalPages { get; set; }
    }
}