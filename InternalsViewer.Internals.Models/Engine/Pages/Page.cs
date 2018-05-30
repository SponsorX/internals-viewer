using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Compression;
using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    /// <summary>
    /// Database Page
    /// </summary>
    public class Page : Markable
    {
        public const int Size = 8192;

        public CompressionType CompressionType { get; set; }

        public string DatabaseName { get; set; }

        public Database.Database Database { get; set; }

        public PageAddress PageAddress { get; set; }

        public int DatabaseId { get; set; }

        public byte[] PageData { get; set; }

        public Header Header { get; set; }

        public List<ushort> OffsetTable { get; } = new List<ushort>();

        public CompressionInformation CompressionInformation { get; set; }
    }
}
