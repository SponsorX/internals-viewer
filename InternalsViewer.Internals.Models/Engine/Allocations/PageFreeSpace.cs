using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Database;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Models.Engine.Allocations
{
    public class PageFreeSpace
    {
        public List<PageFreeSpacePage> Pages;

        public PageFreeSpace()
        {
            Pages = new List<PageFreeSpacePage>();
        }

        public PfsByte GetPagePfsByte(int page)
        {
            return Pages[page / DatabaseContainer.PfsInterval].PfsBytes[page % DatabaseContainer.PfsInterval];
        }
    }
}
