using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Models.Engine.Database
{
    /// <summary>
    /// An Allocation structure represented by a collection of allocation pages separated by an interval
    /// </summary>
    public class Allocation
    {
        public List<AllocationMapPage> Pages { get; } = new List<AllocationMapPage>();

        public List<PageAddress> SinglePageSlots { get; set; } = new List<PageAddress>();

        public int FileId { get; set; }

        /// <summary>
        /// Determines if the Allocation spans multiple files
        /// </summary>
        public bool MultiFile { get; set; }
    }
}
