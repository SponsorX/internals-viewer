using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Models.Engine.Database
{
    public class Pfs
    {
        private readonly List<PfsPage> pfsPages;

        public Pfs(PfsPage page)
        {
            pfsPages = new List<PfsPage> { page };
        }

        public PfsByte PagePfsByte(int page)
        {
            return pfsPages[page / Database.PfsInterval].PfsBytes[page % Database.PfsInterval];
        }
    }
}
