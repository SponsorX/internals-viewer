using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    /// <summary>
    /// Allocation Page containing an allocation bitmap
    /// </summary>
    public class AllocationPage : Page
    {
        public const int AllocationArrayOffset = 194;
        public const int SinglePageSlotOffset = 142;
        public const int StartPageOffset = 136;
        public const int ExtentCount = 64000;

        public bool[] AllocationMap { get; } = new bool[ExtentCount];

        /// <summary>
        /// Gets the single page slots collection.
        /// </summary>
        /// <value>The single page slots collection.</value>
        public List<PageAddress> SinglePageSlots { get; } = new List<PageAddress>();

        public PageAddress StartPage { get; set; }
    }
}
